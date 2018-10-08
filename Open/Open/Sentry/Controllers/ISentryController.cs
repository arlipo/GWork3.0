using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace Open.Sentry.Controllers {
    public interface ISentryController {
        Task<IActionResult> Index(string sortOrder = null,
            string currentFilter = null,
            string searchString = null,
            int? page = null);
        IActionResult Create();
        Task<IActionResult> Edit(string id);
        Task<IActionResult> Details(string id);
        Task<IActionResult> Delete(string id);
        Task<IActionResult> DeleteConfirmed(string id);
    }
}