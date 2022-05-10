using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VisionStore.Data;
using VisionStore.Models;

namespace VisionStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private  AppDbContext _DbContext { get; set; }
        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _DbContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Product()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Product(Products model)
        {
            var record = new Products()
            {
                Title = model.Title,
                Description = model.Description,
                Quantity = model.Quantity,
                Price = model.Price
            };
            _DbContext.Products.Add(record);
            _DbContext.SaveChanges();
            return RedirectToAction("Product");
        }

        public IActionResult ListProducts()
        {
            var list = _DbContext.Products.ToList();
            return View(list);
        }

        public IActionResult DeleteProduct(int id)
        {
            var product = _DbContext.Products.Where(c => c.ProductId == id).FirstOrDefault();
            _DbContext.Products.Remove(product);
            _DbContext.SaveChanges();
            return RedirectToAction("ListProducts");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}