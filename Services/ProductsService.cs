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
        public void Add(Products product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var record = _context.Products.Where(c => c.ProductId == id).FirstOrDefault();
            if(record != null)
            {
                _context.Products.Remove(record);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Products> GetAll()
        {
            var list = _context.Products;
            return list;
        }

        public Products GetById(int id)
        {
            var product = _context.Products.Where(c => c.ProductId == id).FirstOrDefault();
            return product;
        }
        public async Task Update(Products product)
        {
            var record = _context.Products.Where(c => c.ProductId == product.ProductId).FirstOrDefault();
            await _context.SaveChangesAsync();
        }
    }
}
