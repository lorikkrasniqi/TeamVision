using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VisionStore.Areas.Identity.Data;
using VisionStore.Models;

namespace VisionStore.Controllers
{
    //[Authorize(Roles = "Admin")]
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

        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _roleManager.Roles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            RoleViewModel rvm = new RoleViewModel();
            var role = await _roleManager.Roles.FindAsync(id);
            _roleManager.Roles.Remove(role);
            await _roleManager.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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
                var usersInRole = await _userManager.IsInRoleAsync(user, role.Name);
                if (usersInRole)
                {
                    model.Users.Add(user.UserName);
                }

            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult>EditRole(EditRolesViewModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.Id);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id ={model.Id} does not exist.";  
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

        [HttpGet]
        public async Task<IActionResult> EditUsersRole(string roleId)
        {
            ViewBag.roleId = roleId;

            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                return View("NotFound");
            }

            var model = new List<UserRoleViewModel>();

            foreach (var user in _userManager.Users)
            {
                var userRoleViewModel = new UserRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName,

                };

                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    userRoleViewModel.IsSelected = true;
                }
                else
                {
                    userRoleViewModel.IsSelected = false;
                }
                model.Add(userRoleViewModel);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUsersRole(List<UserRoleViewModel> model, string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            {
                if(role == null)
                {
                    return View("NotFound");
                }
                for (int i = 0; i < model.Count; i++)
                {
                    var user = await _userManager.FindByIdAsync(model[i].UserId);
                        
                    IdentityResult result = null;
                    if (model[i].IsSelected && !(await _userManager.IsInRoleAsync(user,role.Name)))
                    {
                       result = await _userManager.AddToRoleAsync(user, role.Name);
                    }
                    else if(!model[i].IsSelected && await _userManager.IsInRoleAsync(user, role.Name))
                    {
                        result = await _userManager.RemoveFromRoleAsync(user,role.Name);
                    }
                    else
                    {
                        continue;
                    }

                    if(result.Succeeded)
                    {
                        if(i < model.Count -1 )
                        {
                            continue;
                        }
                        else 
                            return RedirectToAction("EditRole", new {Id = roleId});
                    }

                }
                return RedirectToAction("EditRole", new { Id = roleId });
            }
        }
    }
}
