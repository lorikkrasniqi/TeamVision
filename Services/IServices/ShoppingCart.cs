using Microsoft.EntityFrameworkCore;
using VisionStore.Data;
using VisionStore.Models;
using VisionStore.Services.IServices;

namespace VisionStore.Services
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly AppDbContext _context;
        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }
      
    }
}
