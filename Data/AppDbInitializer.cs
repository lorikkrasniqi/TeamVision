using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using VisionStore.Areas.Identity.Data;

namespace VisionStore.Data
{
    public class AppDbInitializer
    {

        public static async Task SeedUserRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if(!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                var userManager = serviceScope.ServiceProvider.GetService<UserManager<ApplicationUser>>();
                string email = "admin@visionstore.com";
                var adminUser = await userManager.FindByEmailAsync(email);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FirstName = "Admin",
                        LastName = "Vision",
                        Email = email,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Abc.123");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string userEmail = "user@visionstore.com";
                var appUser = await userManager.FindByEmailAsync(userEmail);
                if (adminUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FirstName = "User",
                        LastName = "Vision",
                        Email = userEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Abc.123");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }

            }
        }
    }
}
