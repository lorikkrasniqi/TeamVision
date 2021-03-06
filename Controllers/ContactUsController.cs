using Microsoft.AspNetCore.Mvc;
using VisionStore.Data;
using VisionStore.Models;

namespace VisionStore.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly AppDbContext _context;
        public ContactUsController(AppDbContext context)
        {
            _context = context;
        }       
        public IActionResult Index()
        {
            return View();
        }
 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index([Bind("FullName","Email","Message" )]ContactUs msg)
        {
            if (ModelState.IsValid)
            {
                _context.ContactUs.Add(msg);
                _context.SaveChanges();
                return View("Index");
            }
            return View(msg);
        }
    }
}
