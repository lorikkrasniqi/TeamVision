using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VisionStore.Models;
using VisionStore.Areas.Identity.Data; 

namespace VisionStore.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public UserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }



        // GET: UserController1
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        //[Authorize(Roles = "User")]
        public IActionResult Profile()
        {
            var user = _userManager.Users.First(x=>x.Email == User.Identity.Name);
            return View( new UserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            });
        }

        [HttpPost]
        //[Authorize(Roles = "User")]
        public async Task<IActionResult> Profile(ApplicationUser model)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.Users.First(x=>x.Email == User.Identity.Name);
                
                   
                user.Email = model.Email;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.NormalizedEmail = model.Email.ToUpper();
                user.UserName =  model.Email;
                user.NormalizedUserName = model.Email.ToUpper();

                var result = await _userManager.UpdateAsync(user);


                if (result.Succeeded)
                {
                    await _signInManager.RefreshSignInAsync(user);
                    ViewData["message"] = "Succesfully Updated Profile";
                }
                else
                {
                    ViewData["message"] = "Profile Update Error";
                }
            }


            return View();
        }
        [HttpGet]
        //[Authorize(Roles = "User")]
        public IActionResult UserData()
        {
            var userid = _userManager.GetUserId(HttpContext.User);
            ApplicationUser user = _userManager.FindByIdAsync(userid).Result;

            return View(user);

        }


      

    }
}
