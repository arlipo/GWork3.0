using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Open.Aids;
using Open.Core;
using Open.Data.Quantity;
using Open.Domain.Quantity;
using Open.Facade.Quantity;
namespace Open.Sentry.Controllers {
    [Authorize]
    public class RatesController : Controller, ISentryController {
        private readonly IRateRepository repository;
        internal const string properties = "ID, ValidFrom, ValidTo, CurrencyID, Rate, RateTypeID";
        public RatesController(IRateRepository r) {
            repository = r;
        }

        public async Task<IActionResult> Index(string sortOrder = null,
            string currentFilter = null,
            string searchString = null,
            int? page = null) {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["SortID"] = sortOrder == "id" ? "id_desc" : "id";
            ViewData["SortValidFrom"] = sortOrder == "validFrom" ? "validFrom_desc" : "validFrom";
            ViewData["SortValidTo"] = sortOrder == "validTo" ? "validTo_desc" : "validTo";
            ViewData["SortCurrencyID"] = sortOrder == "currencyID" ? "currencyID_desc" : "currencyID";
            ViewData["SortRate"] = string.IsNullOrEmpty(sortOrder) ? "rate_desc" : "";
            ViewData["SortRateTypeID"] = sortOrder == "ratetypeID" ? "ratetypeID_desc" : "ratetypeID";
            repository.SortOrder = sortOrder != null && sortOrder.EndsWith("_desc")
                ? SortOrder.Descending
                : SortOrder.Ascending;
            repository.SortFunction = getSortFunction(sortOrder);
            if (searchString != null) page = 1;
            else searchString = currentFilter;
            ViewData["CurrentFilter"] = searchString;
            repository.SearchString = searchString;
            repository.PageIndex = page ?? 1;
            var l = await repository.GetObjectsList();
            return View(new RateViewsList(l));
        }
        private Func<RateData, object> getSortFunction(string sortOrder) {
            if (string.IsNullOrWhiteSpace(sortOrder)) return x => x.Rate;
            if (sortOrder.StartsWith("validTo")) return x => x.ValidTo;
            if (sortOrder.StartsWith("validFrom")) return x => x.ValidFrom;
            if (sortOrder.StartsWith("id")) return x => x.ID;
            if (sortOrder.StartsWith("currencyID")) return x => x.CurrencyID;
            if (sortOrder.StartsWith("ratetypeID")) return x => x.RateTypeID;
            return x => x.Rate;
        }
        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind(properties)] RateView c) {
            await validateId(c.ID, ModelState);
            if (!ModelState.IsValid) return View(c);
            var o = RateFactory.Create(c.CurrencyID, c.Rate, c.ValidFrom, c.RateTypeID);
            await repository.AddObject(o);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(string id) {
            var c = await repository.GetObject(id);
            return View(RateViewFactory.Create(c));
        }
        [HttpPost]
        public async Task<IActionResult> Edit([Bind(properties)] RateView c) {
            if (!ModelState.IsValid) return View(c);
            var o = await repository.GetObject(c.ID);
            o.Data.Rate = c.Rate;
            o.Data.RateTypeID = c.RateTypeID;
            o.Data.ValidFrom = c.ValidFrom ?? DateTime.MinValue;
            o.Data.ValidTo = c.ValidTo ?? DateTime.MaxValue;
            await repository.UpdateObject(o);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(string id) {
            var c = await repository.GetObject(id);
            return View(RateViewFactory.Create(c));
        }

        public async Task<IActionResult> Delete(string id) {
            var c = await repository.GetObject(id);
            return View(RateViewFactory.Create(c));
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id) {
            var c = await repository.GetObject(id);
            await repository.DeleteObject(c);
            return RedirectToAction("Index");
        }

        private async Task validateId(string id, ModelStateDictionary d) {
            if (await isIdInUse(id))
                d.AddModelError(string.Empty, idIsInUseMessage(id));
        }
        private async Task<bool> isIdInUse(string id) {
            return (await repository.GetObject(id))?.Data?.ID == id;
        }
        private static string idIsInUseMessage(string id) {
            var name = GetMember.DisplayName<RateView>(c => c.ID);
            return string.Format(Messages.ValueIsAlreadyInUse, id, name);
        }
    }
}