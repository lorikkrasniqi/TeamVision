using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VisionStore.Data;
using VisionStore.Services.IServices;
using VisionStore.Models;
using Microsoft.EntityFrameworkCore;

namespace VisionStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IProductsService _service;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IProductsService service, AppDbContext context)
        {
            _service = service;
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var allProducts = await _context.Products.ToListAsync();
            return View(allProducts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}