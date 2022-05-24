using Microsoft.EntityFrameworkCore;
using VisionStore.Data;
using VisionStore.Models;
using VisionStore.Services.IServices;

namespace VisionStore.Services
{
    public class CategoryServices : ICategoryService
    {
        private readonly AppDbContext _context;
        public CategoryServices(AppDbContext context)
        {
            _context = context;
        }
        public void Create(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var record = _context.Categories.Where(c => c.CategoryId == id).FirstOrDefault();
            if (record != null)
            {
                _context.Categories.Remove(record);
                _context.SaveChanges();
            }
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            var list = await _context.Categories.ToListAsync();
            return list;
        }

        public Category GetById(int id)
        {
            var Categories = _context.Categories.Where(c => c.CategoryId == id).FirstOrDefault();
            return Categories;
        }

        void ICategoryService.Update(Category category)
        {
            
            _context.Update(category);
            _context.SaveChanges();
        }
    }
}
