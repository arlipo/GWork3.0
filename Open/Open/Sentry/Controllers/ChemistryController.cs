using System.Threading.Tasks;
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
        public async Task<IActionResult> Index()
        {
            var l = await goodRepository.GetWithSpecificType(GoodTypes.Chemistry);
            return View(new GoodViewsList(l));
        }
    }
}