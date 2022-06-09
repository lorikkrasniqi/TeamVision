using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VisionStore.Areas.Identity.Data;
using VisionStore.Models;

namespace VisionStore.Controllers
{
    public class AdministrationController : Controller
    {
        public readonly RoleManager<IdentityRole> _roleManager;
        public readonly UserManager<ApplicationUser> _userManager;
        public AdministrationController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;

        }
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRoleAsync(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };
                IdentityResult result = await _roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "home");
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult ListRoles()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return View("Not found");
            }
            var model = new EditRolesViewModel
            {
                Id = role.Id,
                RoleName = role.Name,

            };

            foreach (var user in _userManager.Users)
            {
               if(await _userManager.IsInRoleAsync(user, role.Id))
                {
                    model.Users.Add(user.UserName);
                }

            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(EditRolesViewModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.Id);
            if (role == null)
            {
                return View("Not found");
            }
            else
            {
                role.Name = model.RoleName;
                var result = await _roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }     
                return View(model);
            }
       
        }
    }
}
