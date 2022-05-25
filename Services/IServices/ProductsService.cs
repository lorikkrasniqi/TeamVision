using Microsoft.EntityFrameworkCore;
using VisionStore.Data;
using VisionStore.Models;
using VisionStore.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public void Add(Products product)
        {
            string uniqueFileName = UploadedFile(product);
            product.ImageUrl = uniqueFileName;
            _context.Attach(product);
            _context.Entry(product).State = EntityState.Added;
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
