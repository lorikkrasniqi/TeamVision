using VisionStore.Models;

namespace VisionStore.Services.IServices
{
    public interface ICategoryService
    {
        
            Task<IEnumerable<Category>> GetAll();
            Category GetById(int id);
            void Create(Category category);
            void Update(Category category);
            void Delete(int id);

    }
}
