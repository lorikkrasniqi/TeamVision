using Microsoft.EntityFrameworkCore;
using VisionStore.Data;
using VisionStore.Models;
using VisionStore.Services.IServices;

namespace VisionStore.Services
{
    public class UnitWork : IUnitWork 
    {
        private readonly AppDbContext _context;
        public UnitWork(AppDbContext context)
        {
            _context = context;
          
            CategoryService = new CategoryServices(_context);
            ApplicationUser = new ApplicationUser(_context);
            ShoppingCart = new ShoppingCart(_context);
        }


        public IShoppingCart ShoppingCart { get; private set; }

        public IApplicationUser ApplicationUser { get; private set; }

        public ICategoryService CategoryService { get; private set; }

        public IProductsService ProductsService { get; private set; }

        public void Save()
        {
            _context.SaveChanges();
        }

     
       
    }
}
