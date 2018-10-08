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

    [Authorize] public class RateTypesController : Controller, ISentryController {
        private readonly IRateTypeRepository reporitory;

        internal const string properties = "ID, Code, Name, Description, ValidFrom, ValidTo";

        public RateTypesController(IRateTypeRepository r) {
            reporitory = r;
        }

        public async Task<IActionResult> Index(string sortOrder = null,
            string currentFilter = null,
            string searchString = null,
            int? page = null) {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["SortName"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["SortId"] = sortOrder == "id" ? "id_desc" : "id";
            ViewData["SortCode"] = sortOrder == "code" ? "code_desc" : "code";
            ViewData["SortDescription"] = sortOrder == "descr" ? "descr_desc" : "descr";
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
            return View(new RateTypeViewsList(l));
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost] public async Task<IActionResult> Create([Bind(properties)] RateTypeView c) {
            await validateId(c.ID, ModelState);
            if (!ModelState.IsValid) return View(c);
            var o = RateTypeViewFactory.Create(c);
            await reporitory.AddObject(o);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(string id) {
            var c = await reporitory.GetObject(id);
            return View(RateTypeViewFactory.Create(c));
        }

        [HttpPost] public async Task<IActionResult> Edit([Bind(properties)] RateTypeView c) {
            if (!ModelState.IsValid) return View(c);
            var o = await reporitory.GetObject(c.ID);
            o.Data.Name = c.Name;
            o.Data.Code = c.Code;
            o.Data.ValidFrom = c.ValidFrom ?? DateTime.MinValue;
            o.Data.ValidTo = c.ValidTo ?? DateTime.MaxValue;
            await reporitory.UpdateObject(o);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(string id) {
            var c = await reporitory.GetObject(id);
            return View(RateTypeViewFactory.Create(c));
        }

        public async Task<IActionResult> Delete(string id) {
            var c = await reporitory.GetObject(id);
            return View(RateTypeViewFactory.Create(c));
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id) {
            var c = await reporitory.GetObject(id);
            await reporitory.DeleteObject(c);
            return RedirectToAction("Index");
        }

        private Func<RateTypeData, object> getSortFunction(string sortOrder) {
            if (string.IsNullOrWhiteSpace(sortOrder)) return x => x.Name;
            if (sortOrder.StartsWith("validTo")) return x => x.ValidTo;
            if (sortOrder.StartsWith("validFrom")) return x => x.ValidFrom;
            if (sortOrder.StartsWith("id")) return x => x.ID;
            if (sortOrder.StartsWith("code")) return x => x.Code;
            if (sortOrder.StartsWith("descr")) return x => x.Description;
            return x => x.Name;
        }

        private async Task validateId(string id, ModelStateDictionary d) {
            if (await isIdInUse(id))
                d.AddModelError(string.Empty, idIsInUseMessage(id));
        }

        private async Task<bool> isIdInUse(string id) {
            return (await reporitory.GetObject(id))?.Data?.ID == id;
        }

        private static string idIsInUseMessage(string id) {
            var name = GetMember.DisplayName<RateTypeView>(c => c.ID);
            return string.Format(Messages.ValueIsAlreadyInUse, id, name);
        }
    }
}