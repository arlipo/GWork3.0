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

        public HomeController(IServiceProvider s, UserManager<ApplicationUser> userManager)
        {
            services = s;
            _userManager = userManager;
            CreateUserRoles(services).Wait();
        }
        private async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var userr = new ApplicationUser();
            userr.Id = Guid.NewGuid().ToString();
            userr.UserName = "Admin@admin.com";
            userr.Email = "Admin@admin.com";
            var result = await _userManager.CreateAsync(userr, "1!Aabcsef");

            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();


            IdentityResult roleResult;
            //Adding Addmin Role  
            var roleCheck = await RoleManager.RoleExistsAsync("Admin");
            if (!roleCheck)
            {
                //create the roles and seed them to the database  
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Admin"));
            }
           
            //Assign Admin role to the main User here we have given our newly loregistered login id for Admin management  
            ApplicationUser user = await UserManager.FindByEmailAsync("Admin@admin.com");
            var User = new ApplicationUser();
            await UserManager.AddToRoleAsync(user, "Admin");

        }
        public IActionResult Index() { return View(); }

        public IActionResult About() {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact() {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error() {
            return View(new ErrorViewModel {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
        public IActionResult Money() {
            ViewData["Message"] = "Money related stuff.";

            return View();
        }
        public IActionResult Contacts() {
            ViewData["Message"] = "Contacts related stuff.";

            return View();
        }
       
        public IActionResult SpareParts()
        {
            ViewData["Message"] = "Contacts related stuff.";

            return View();
        }
        public IActionResult Accessories()
        {
            ViewData["Message"] = "Contacts related stuff.";

            return View();
        }
        public IActionResult Chemistry()
        {
            ViewData["Message"] = "Contacts related stuff.";

            return View();
        }
        public IActionResult Team()
        {
            ViewData["Message"] = "Contacts related stuff.";

            return View();
        }
    }
}
