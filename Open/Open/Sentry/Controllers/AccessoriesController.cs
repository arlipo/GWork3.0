using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Open.Aids;
using Open.Core;
using Open.Domain.Goods;
using Open.Facade.Goods;

namespace Open.Sentry.Controllers
{
    public class AccessoriesController : Controller
    {
        private readonly IGoodsRepository repository;

        public AccessoriesController(IGoodsRepository r) {
            repository = r;
        }

        
        public async Task<IActionResult> Index(string sortOrder = null, string currentFilter = null,
            string searchString = null, int? page = null)
        {
            if (searchString != null) page = 1;
            else searchString = currentFilter;
            ViewData["CurrentFilter"] = searchString;
            repository.SearchString = searchString;
            repository.PageIndex = page ?? 1;
            var l = await repository.GetWithSpecificType(GoodTypes.Accessories);
            return View(new GoodViewsList(l));

        }
    }
}