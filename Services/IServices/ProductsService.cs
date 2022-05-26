using Microsoft.EntityFrameworkCore;
using VisionStore.Data;
using VisionStore.Models;
using VisionStore.Services.IServices;

namespace VisionStore.Services
{
    public class ProductsService : IProductsService
    {
        private readonly AppDbContext _context;
        public ProductsService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Products>> GetAllAsync()
        {
            var result = await _context.Products.ToListAsync();
            return result;
        }

        public async Task AddAsync(Products product)
        {
           await _context.Products.AddAsync(product);
           await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result  = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == id);  
             _context.Products.Remove(result);
            await _context.SaveChangesAsync();
        }
        public async Task<Products> GetByIdAsync(int id)
        {
          var result = await _context.Products.FirstOrDefaultAsync(x => x.ProductId  == id); 
            return result;
        }

        public async Task<Products>UpdateAsync(int id, Products product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
            return product;

        }
    }
}
