using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Open.Core;
using Open.Domain.Goods;
using Open.Facade.Goods;

namespace Open.Sentry.Controllers
{
    public class AccessoriesController : Controller
    {
        private readonly IGoodsRepository goodRepository;

        public AccessoriesController(IGoodsRepository gR)
        {
            goodRepository = gR;
        }
        public async Task<IActionResult> Index()
        {
            var l = await goodRepository.GetWithSpecificType(GoodTypes.Accessories);
            return View(new GoodViewsList(l));
        }
    }
}