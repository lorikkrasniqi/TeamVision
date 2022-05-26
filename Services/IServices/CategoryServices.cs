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
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var result = await _context.Categories.ToListAsync();
            return result;
        }

        public async Task CreateAsync(Category categories)
        {
            await _context.Categories.AddAsync(categories);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);
            _context.Categories.Remove(result);
            await _context.SaveChangesAsync();
        }
        public async Task<Category> GetByIdAsync(int id)
        {
            var result = await _context.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);
            return result;
        }

        public async Task<Category> UpdateAsync(int id, Category categories)
        {
            _context.Update(categories);
            await _context.SaveChangesAsync();
            return categories;

        }
    }
}
