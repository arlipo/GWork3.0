using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Open.Sentry.Data;
using Open.Sentry.Models;
using Open.Sentry.Models.AccountViewModels;

namespace Open.Sentry.Controllers
{
    public class CreditsController : Controller
    {
        private readonly ApplicationDbContext _dataContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public CreditsController(ApplicationDbContext dataContext, UserManager<ApplicationUser> userManager)
        {
            _dataContext = dataContext;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(CreditsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                user.Credits = model.Credits;

                _dataContext.Update(user);
                await _dataContext.SaveChangesAsync();                
            }
            return View(model);
        }

        //[HttpPost]
        //public async Task<IActionResult> DeleteCredits(ApplicationUser model)
        //{
        //    var user = await _userManager.FindByEmailAsync(model.Email);
        //    user.Credits = 0;

        //    return RedirectToAction("Edit", new { id = model.Email });
        //}
    }
}