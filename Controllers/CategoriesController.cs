using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VisionStore.Data;
using VisionStore.Models;
using VisionStore.Services.IServices;

namespace VisionStore.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _category;
        private readonly AppDbContext _db;

        public CategoriesController(ICategoryService category, AppDbContext db)
        {
            _category = category;
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _category.GetAllAsync();
            return View(list);
        }

        [HttpGet]

        public async Task<IActionResult> Index(string CategorySearch)
        {
            ViewData["GetCategoryDetails"] = CategorySearch;

            var product = from x in _db.Products select x;
            if (!string.IsNullOrEmpty(CategorySearch))
            {
                product = product.Where(x => x.Description.Contains(CategorySearch) || x.Title.Contains(CategorySearch));
            }
            return View(await product.AsNoTracking().ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name", "Description")] Category category)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(category);
            //}
            await _category.CreateAsync(category);
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Details(int id)
        {
            var product = await _category.GetByIdAsync(id);
            if (product == null)
            { return View("NotFound"); }

            return View(product);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _category.GetByIdAsync(id);
            if (product == null)
            { return View("NotFound"); }

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryId", "Name", "Description")] Category category)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(category);
            //}
            await _category.UpdateAsync(id, category);
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _category.GetByIdAsync(id);
            if (product == null) { return View("NotFound"); }

            return View(product);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _category.GetByIdAsync(id);
            if (product == null) { return View("NotFound"); }

            await _category.DeleteAsync(id);
            return RedirectToAction("Index");

        }
    }
}
