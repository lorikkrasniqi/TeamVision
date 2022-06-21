using Microsoft.EntityFrameworkCore;
using VisionStore.Data;
using VisionStore.Models;
using VisionStore.Services.IServices;

namespace VisionStore.Services
{
    public class ApplicationUser : IApplicationUser
    {
        private readonly AppDbContext _context;
        public ApplicationUser(AppDbContext context)
        {
            _context = context;
        }

    }
}
