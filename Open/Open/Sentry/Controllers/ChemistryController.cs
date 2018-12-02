using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Open.Core;
using Open.Domain.Goods;
using Open.Facade.Goods;

namespace Open.Sentry.Controllers
{
    public class ChemistryController : Controller
    {
        private readonly IGoodsRepository goodRepository;

        public ChemistryController(IGoodsRepository gR)
        {
            goodRepository = gR;
        }
        public async Task<IActionResult> Index(string sortOrder = null, string currentFilter = null,
            string searchString = null, int? page = null)
        {
            if (searchString != null) page = 1;
            else searchString = currentFilter;
            ViewData["CurrentFilter"] = searchString;
            goodRepository.SearchString = searchString;
            goodRepository.PageIndex = page ?? 1;
            var l = await goodRepository.GetWithSpecificType(GoodTypes.Chemistry);
            return View(new GoodViewsList(l));
        }
    }
}