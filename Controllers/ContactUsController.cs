using Microsoft.AspNetCore.Mvc;

namespace VisionStore.Controllers
{
    public class ContactUsController : Controller
    {
        //private readonly ContactUsController _contact;

        //public ContactUsController(ContactUsController contact)
        //{
        //    _contact = contact;
        //}
        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Create([Bind("FullName", "Email", "Message")] ContactUsController contact)
        //{
        //    //if (!ModelState.IsValid)
        //    //{
        //    //    return View(category);
        //    //}
        //    //await _contact.CreateAsync(contact);
        //    return RedirectToAction("Index");

        //}
    }
}
