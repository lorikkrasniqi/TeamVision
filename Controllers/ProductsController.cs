using Microsoft.AspNetCore.Mvc;
using VisionStore.Data;
using VisionStore.Models;
using VisionStore.Services.IServices;

namespace VisionStore.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService _service;

        public ProductsController(IProductsService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            var list = _service.GetAll();
            return View(list);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Products product)
        {
            _service.Add(product);  
            return RedirectToAction("Add");
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
