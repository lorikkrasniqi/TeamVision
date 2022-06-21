using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VisionStore.Data;
using VisionStore.Models;
using VisionStore.Services.IServices;
using System.Collections;

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
        public async Task<IActionResult> Index()
        {
            var list = await _service.GetAllAsync();
        
            return View(list);
        }

        public async Task<IActionResult> Add()
        {

            var category = await _category.GetAllAsync();
            ViewData["CategoryID"] = new SelectList(category, "CategoryId", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add([Bind("CategoryId","Title","Description","Price","Quantity", "productImage")]Products product)
        {
            //if(!ModelState.IsValid)
            //{
            //  return View(product); 
            //}
                await _service.AddAsync(product);  
                return RedirectToAction("Index");
           
        }
        public async Task <IActionResult> Details(int id)
        {
            var product = await _service.GetByIdAsync(id);
            if (product == null)
            { return View("NotFound"); }

            return View(product);
        }
        public async Task <IActionResult> Edit(int id)
        {
            var category = await _category.GetAllAsync();
            ViewData["CategoryID"] = new SelectList(category, "CategoryId", "Name");

            var product = await _service.GetByIdAsync(id);
            if (product == null)
            { return View("NotFound"); }

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("CategoryId","ProductId", "Title", "Description", "Price", "Quantity", "productImage")] Products product)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(product);
            //}
            await _service.UpdateAsync(id,product);
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _service.GetByIdAsync(id);
            if (product == null) { return View("NotFound"); }           
            
            return View(product);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult>DeleteConfirmed(int id)
        {
            var product = await _service.GetByIdAsync(id);
            if (product == null) { return View("NotFound"); }

            await _service.DeleteAsync(id);  
            return RedirectToAction("Index");

        }
    }
}
