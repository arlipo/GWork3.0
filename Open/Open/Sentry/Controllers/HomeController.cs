using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Open.Sentry.Models;
namespace Open.Sentry.Controllers {
    public class HomeController : Controller
    {
        private readonly IServiceProvider services;
        private UserManager<ApplicationUser> _userManager;

        public HomeController(IServiceProvider s, UserManager<ApplicationUser> userManager) {
            services = s;
            _userManager = userManager;
            CreateUserRoles(services).Wait();
        }
        private async Task CreateUserRoles(IServiceProvider serviceProvider) {
            var userr = new ApplicationUser();
            userr.Id = Guid.NewGuid().ToString();
            userr.UserName = "Admin@admin.com";
            userr.Email = "Admin@admin.com";
            await _userManager.CreateAsync(userr, "1!Aabcsef");

            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            //Adding Admin Role  
            var roleCheck = await RoleManager.RoleExistsAsync("Admin");
            if (!roleCheck) {
                //create the roles and seed them to the database  
                await RoleManager.CreateAsync(new IdentityRole("Admin"));
            }

            //Assign Admin role to the main User here we have given our newly registered login id for Admin management  
            ApplicationUser user = await UserManager.FindByEmailAsync("Admin@admin.com");
            await UserManager.AddToRoleAsync(user, "Admin");

        }
        public IActionResult Index() {
            return View();
        }

        public IActionResult About() {
            return View();
        }
        public IActionResult Error() {
            return View(new ErrorViewModel {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
        public IActionResult Team() {
            return View();
        }
    }
}
