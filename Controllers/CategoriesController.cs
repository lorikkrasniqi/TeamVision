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
        public CategoriesController(ICategoryService category)
        {
            _category = category;
        }
        public async Task<IActionResult> Index()
        {

            var data = await _category.GetAll();
            return View(data);
        }
        public IActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            _category.Create(category);  
            return RedirectToAction("Create");
        }
        public IActionResult Details(int id)
        {
            var category = _category.GetById(id);
            return View(category);
        }
        public IActionResult Edit(int id)
        {
            var category = _category.GetById(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            _category.Update(category);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _category.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
