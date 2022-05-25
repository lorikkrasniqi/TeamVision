using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VisionStore.Data;
using VisionStore.Models;
using VisionStore.Services.IServices;

namespace VisionStore.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService _service;
        private readonly ICategoryService _category;

        public ProductsController(IProductsService service, ICategoryService category)
        {
            _service = service;
            _category = category;
        }
        public IActionResult Index()
        {
            var list = _service.GetAll();
            return View(list);
        }
        public async Task<IActionResult> Add()
        {

            var category = await _category.GetAll();

            ViewData["CategoryId"] = new SelectList(category, "CategoryId", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Add(Products product)
        {
            _service.Add(product);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var product = _service.GetById(id);
            return View(product);
        }
        public IActionResult Edit(int id)
        {
            var product = _service.GetById(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Products product)
        {
            _service.Update(product);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}