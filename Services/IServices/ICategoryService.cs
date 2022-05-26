using VisionStore.Models;

namespace VisionStore.Services.IServices
{
    public interface ICategoryService
    {
        
            Task<IEnumerable<Category>> GetAllAsync();
            Task<Category> GetByIdAsync(int id);
            Task CreateAsync(Category category);
            Task<Category> UpdateAsync(int id,Category category);
            Task DeleteAsync(int id);

            //Task<IEnumerable<Products>> GetAllAsync();
            //Task<Products> GetByIdAsync(int id);
            //Task AddAsync(Products product);
            //Task<Products> UpdateAsync(int id, Products product);
            //Task DeleteAsync(int id);

    }
}
