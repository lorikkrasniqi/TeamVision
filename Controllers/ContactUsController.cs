using Microsoft.AspNetCore.Mvc;

namespace VisionStore.Controllers
{
    public class ContactUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
