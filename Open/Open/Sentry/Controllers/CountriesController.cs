using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Open.Aids;
using Open.Core;
using Open.Data.Party;
using Open.Domain.Party;
using Open.Domain.Quantity;
using Open.Facade.Party;
namespace Open.Sentry.Controllers {

    [Authorize] public class CountriesController : Controller, ISentryController {

        private readonly ICountriesRepository reporitory;
        private readonly INationalCurrenciesRepository currencyes;
        internal const string properties = "Alpha3Code, Alpha2Code, Name, ValidFrom, ValidTo";
        public CountriesController(ICountriesRepository r, INationalCurrenciesRepository c) {
            reporitory = r;
            currencyes = c;
        }

        public async Task<IActionResult> Index(string sortOrder = null, string currentFilter = null,
            string searchString = null, int? page = null) {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["SortName"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["SortAlpha3"] = sortOrder == "alpha3" ? "alpha3_desc" : "alpha3";
            ViewData["SortAlpha2"] = sortOrder == "alpha2" ? "alpha2_desc" : "alpha2";
            ViewData["SortValidFrom"] = sortOrder == "validFrom" ? "validFrom_desc" : "validFrom";
            ViewData["SortValidTo"] = sortOrder == "validTo" ? "validTo_desc" : "validTo";
            reporitory.SortOrder = sortOrder != null && sortOrder.EndsWith("_desc")
                ? SortOrder.Descending
                : SortOrder.Ascending;
            reporitory.SortFunction = getSortFunction(sortOrder);
            if (searchString != null) page = 1;
            else searchString = currentFilter;
            ViewData["CurrentFilter"] = searchString;
            reporitory.SearchString = searchString;
            reporitory.PageIndex = page ?? 1;
            var l = await reporitory.GetObjectsList();
            return View(new CountryViewsList(l));
        }
        private Func<CountryData, object> getSortFunction(string sortOrder) {
            if (string.IsNullOrWhiteSpace(sortOrder)) return x => x.Name;
            if (sortOrder.StartsWith("validTo")) return x => x.ValidTo;
            if (sortOrder.StartsWith("validFrom")) return x => x.ValidFrom;
            if (sortOrder.StartsWith("alpha3")) return x => x.ID;
            if (sortOrder.StartsWith("aplha2")) return x => x.Code;
            return x => x.Name;
        }

        public IActionResult Create() { return View(); }

        [HttpPost]
        public async Task<IActionResult> Create([Bind(properties)] CountryView c) {
            await validateId(c.Alpha3Code, ModelState);
            if (!ModelState.IsValid) return View(c);
            var o = CountryFactory.Create(c.Alpha3Code, c.Name, c.Alpha2Code, c.ValidFrom,
                c.ValidTo);
            await reporitory.AddObject(o);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(string id) {
            var c = await reporitory.GetObject(id);
            return View(CountryViewFactory.Create(c));
        }
        [HttpPost]
        public async Task<IActionResult> Edit([Bind(properties)] CountryView c) {
            if (!ModelState.IsValid) return View(c);
            var o = await reporitory.GetObject(c.Alpha3Code);
            o.Data.Name = c.Name;
            o.Data.Code = c.Alpha2Code;
            o.Data.ValidFrom = c.ValidFrom ?? DateTime.MinValue;
            o.Data.ValidTo = c.ValidTo ?? DateTime.MaxValue;
            await reporitory.UpdateObject(o);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(string id) {
            var c = await reporitory.GetObject(id);
            await currencyes.LoadCurrencies(c);
            return View(CountryViewFactory.Create(c));
        }

        public async Task<IActionResult> Delete(string id) {
            var c = await reporitory.GetObject(id);
            return View(CountryViewFactory.Create(c));
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id) {
            var c = await reporitory.GetObject(id);
            await reporitory.DeleteObject(c);
            return RedirectToAction("Index");
        }

        private async Task validateId(string id, ModelStateDictionary d) {
            if (await isIdInUse(id))
                d.AddModelError(string.Empty, idIsInUseMessage(id));
        }
        private async Task<bool> isIdInUse(string id) {
            return (await reporitory.GetObject(id))?.Data?.ID == id;
        }
        private static string idIsInUseMessage(string id) {
            var name = GetMember.DisplayName<CountryView>(c => c.Alpha3Code);
            return string.Format(Messages.ValueIsAlreadyInUse, id, name);
        }
    }
}




