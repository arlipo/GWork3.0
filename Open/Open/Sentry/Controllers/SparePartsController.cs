using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Open.Core;
using Open.Domain.Goods;
using Open.Facade.Goods;

namespace Open.Sentry.Controllers
{
    public class SparePartsController : Controller
    {
        private readonly IGoodsRepository goodRepository;

        public SparePartsController(IGoodsRepository gR)
        {
            goodRepository = gR;
        }
        public async Task<IActionResult> Index()
        {
            var l = await goodRepository.GetWithSpecificType(GoodTypes.SpareParts);
            return View(new GoodViewsList(l));
        }
    }
}