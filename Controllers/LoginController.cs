using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisionStore.Models;

namespace VisionStore.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public List<UserModel> PutValue()
        {
            var users = new List<UserModel>
            {
               new UserModel{UserId = 1, FullName="DrenMaxhera",Password="abc123" },
               new UserModel {UserId = 2, FullName="LabinotGjoka",Password="abc123"}
            };

            return users;
        }

        [HttpPost]

        public IActionResult Verify(UserModel usr)
        {
            var u = PutValue();

            var ue = u.Where(u => u.FullName.Equals(usr.FullName));

            var up = ue.Where(p => p.Password.Equals(usr.Password));

            if (up.Count()==1)
            {
                ViewBag.message = "Login Success";
                return View("LoginSucces");
            }
            else
            {
                ViewBag.message = "Login Failed";
                return View("Login");
            }
        }
    }
}
