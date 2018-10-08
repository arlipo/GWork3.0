using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Open.Core;
using Open.Data.Quantity;
using Open.Domain.Quantity;
using Open.Facade.Quantity;
namespace Open.Sentry.Controllers {

    [Authorize] public class PaymentsController : Controller, ISentryController {
        private readonly IPaymentsRepository payments;
        private readonly ICurrencyRepository currencyes;
        private readonly IPaymentMethodsRepository paymentMethods;
        internal const string properties = "ID, Amount, CurrencyID, PaymentMethodID, DateDue, DateMade, ValidTo";
        public PaymentsController(IPaymentsRepository p, ICurrencyRepository c,
            IPaymentMethodsRepository m) {
            payments = p;
            currencyes = c;
            paymentMethods = m;
        }
        public async Task<IActionResult> Index(string sortOrder = null, string currentFilter = null,
            string searchString = null, int? page = null) {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["SortValidFrom"] = string.IsNullOrEmpty(sortOrder) ? "validFrom_desc" : "";
            ViewData["SortAmount"] = sortOrder == "amount" ? "amount_desc" : "amount";
            ViewData["SortDateDue"] = sortOrder == "due" ? "due_desc" : "due";
            ViewData["SortCurrency"] = sortOrder == "currency" ? "currency_desc" : "currency";
            ViewData["SortMethod"] = sortOrder == "method" ? "method_desc" : "method";
            ViewData["SortValidTo"] = sortOrder == "validTo" ? "validTo_desc" : "validTo";
            payments.SortOrder = sortOrder != null && sortOrder.EndsWith("_desc")
                ? SortOrder.Descending
                : SortOrder.Ascending;
            payments.SortFunction = getSortFunction(sortOrder);
            if (searchString != null) page = 1;
            else searchString = currentFilter;
            ViewData["CurrentFilter"] = searchString;
            payments.SearchString = searchString;
            payments.PageIndex = page ?? 1;
            var l = await payments.GetObjectsList();
            return View(new PaymentViewsList(l));
        }
        private Func<PaymentData, object> getSortFunction(string sortOrder) {
            if (string.IsNullOrWhiteSpace(sortOrder)) return x => x.DateMade;
            if (sortOrder.StartsWith("validFrom")) return x => x.DateMade;
            if (sortOrder.StartsWith("validTo")) return x => x.ValidTo;
            if (sortOrder.StartsWith("due")) return x => x.DateDue;
            if (sortOrder.StartsWith("amount")) return x => x.Amount;
            if (sortOrder.StartsWith("curreency")) return x => x.CurrencyID;
            if (sortOrder.StartsWith("method")) return x => x.PaymentMethod;
            return x => x.DateMade;
        }

        public IActionResult Create() { return View(); }

        [HttpPost] 
        public async Task<IActionResult> Create([Bind(properties)] PaymentView c) {
            if (!ModelState.IsValid) return View(c);
            c.ID = c.ID ?? Guid.NewGuid().ToString();
            var o = PaymentViewFactory.Create(c);
            await payments.AddObject(o);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(string id) {
            var c = await payments.GetObject(id);
            return View(PaymentViewFactory.Create(c));
        }
        [HttpPost] 
        public async Task<IActionResult> Edit([Bind(properties)] PaymentView c) {
            if (!ModelState.IsValid) return View(c);
            var o = await payments.GetObject(c.ID);
            o.Data.Amount = c.Amount;
            o.Data.CurrencyID = c.CurrencyID;
            o.Data.PaymentMethodID = c.PaymentMethodID;
            o.Data.DateMade = c.DateMade ?? DateTime.MinValue;
            o.Data.DateDue = c.DateDue ?? DateTime.MinValue;
            o.Data.ValidTo = c.ValidTo ?? DateTime.MaxValue;
            await payments.UpdateObject(o);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(string id) {
            var c = await payments.GetObject(id);
            return View(PaymentViewFactory.Create(c));
        }

        public async Task<IActionResult> Delete(string id) {
            var c = await payments.GetObject(id);
            return View(PaymentViewFactory.Create(c));
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id) {
            var c = await payments.GetObject(id);
            await payments.DeleteObject(c);
            return RedirectToAction("Index");
        }
    }
}