using Microsoft.AspNetCore.Mvc;
using VisionStore.Data;
using VisionStore.Models;

namespace VisionStore.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;
        private AppDbContext _DbContext { get; set; }
        public ProductsController(ILogger<ProductsController> logger, AppDbContext context)
        {
            _logger = logger;
            _DbContext = context;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Products product)
        {
            _DbContext.Products.Add(product);
            _DbContext.SaveChanges();
            return RedirectToAction("Add");
        }

        public IActionResult All()
        {
            var list = _DbContext.Products;
            return View(list);
        }

        public IActionResult Delete(int id)
        {
            var product = _DbContext.Products.Where(c => c.ProductId == id).FirstOrDefault();
            _DbContext.Products.Remove(product);
            _DbContext.SaveChanges();
            return RedirectToAction("All");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = _DbContext.Products.Where(c => c.ProductId == id).FirstOrDefault();
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Products product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            await _DbContext.SaveChangesAsync();
            return RedirectToAction("All");
        }
    }
}
