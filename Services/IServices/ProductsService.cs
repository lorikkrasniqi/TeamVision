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
            _context.Attach(product);
            _context.Entry(product).State = EntityState.Added;
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            string uniqueFileName = UploadedFile(product);
            product.ImageUrl = uniqueFileName;
            _context.SaveChanges();
            
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
            var imageToShow = string.Empty;
            if (product.Images != null)
            {
                foreach(var image in product.Images)
                {
                    string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "img");
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        image.CopyTo(fileStream);
                    }
                    
                    imageToShow = uniqueFileName;
                    var productImage = new ProductImages()
                    {
                        ProductId = product.ProductId,
                        Url = uniqueFileName
                    };

                    AddProductImage(productImage);
                }
            }

            return imageToShow;
        }

        public void AddProductImage(ProductImages image)
        {
            _context.ProductImages.Add(image);
            _context.SaveChanges();
        }

        public List<ProductImages> GetProductImages(int productId)
        {
            return _context.ProductImages.Where(x => x.ProductId == productId).ToList();
        }
    }
}
