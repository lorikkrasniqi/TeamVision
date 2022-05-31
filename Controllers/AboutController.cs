using Microsoft.AspNetCore.Mvc;

namespace VisionStore.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
