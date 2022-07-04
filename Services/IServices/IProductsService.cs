using VisionStore.Models;

namespace VisionStore.Services.IServices
{
    public interface IProductsService
    {
        Task<IEnumerable<Products>> GetAllAsync();
        Task<Products> GetByIdAsync(int id);   
        Task AddAsync(Products product);
        Task<Products> UpdateAsync(int id,Products product);
        Task DeleteAsync(int id);
        List<ProductImages> GetProductImages(int productId);
    }
}
