using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VisionStore.Data;
using VisionStore.Models;
using VisionStore.Services.IServices;

namespace VisionStore.Services
{
    public class ProductsService : IProductsService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProductsService(AppDbContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            webHostEnvironment = webHost;
        }
        public async Task<IEnumerable<Products>> GetAllAsync()
        {
            var result = await _context.Products.ToListAsync();
            return result;
        }

        public async Task AddAsync(Products product)
        {
            string uniqueFileName = UploadedFile(product);
            product.ImageUrl = uniqueFileName;
            _context.Attach(product);
            _context.Entry(product).State = EntityState.Added;
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
        [HttpPost]
        private string UploadedFile(Products product)
        {
            string uniqueFileName = null;
            if (product.productImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "img");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + product.productImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    product.productImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

    }
}
