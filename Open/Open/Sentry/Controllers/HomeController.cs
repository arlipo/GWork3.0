using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Open.Sentry.Models;
namespace Open.Sentry.Controllers {
    public class HomeController : Controller {
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
    }
}
