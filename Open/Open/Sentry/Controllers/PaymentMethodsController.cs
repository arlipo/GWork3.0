using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Open.Core;
using Open.Data.Quantity;
using Open.Domain.Quantity;
using Open.Facade.Quantity;
namespace Open.Sentry.Controllers {
    [Authorize] public class PaymentMethodsController : Controller, ISentryController {
        private readonly IPaymentMethodsRepository paymentMethods;
        internal const string checkProperties =
            "ID, AccountName,AccountNumber,CheckNumber,Payee,BankName, BankAddress,BankID, DateWritten, ValidTo";
        internal const string debitCardProperties =
            "ID, CardNumber, CardName, NameOnCard, BillingAddress, VerificationCode, IssueNumber, CurrencyID, DailyLimit, ValidFrom, ExpireDate";
        internal const string creditCardProperties = debitCardProperties + ", CreditLimit";

        public PaymentMethodsController(IPaymentMethodsRepository m,
            IPaymentsRepository p) {
            paymentMethods = m;
        }
        public async Task<IActionResult> Index(string sortOrder = null,
            string currentFilter = null,
            string searchString = null,
            int? page = null) {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["SortMethodType"] = string.IsNullOrEmpty(sortOrder) ? "type_desc" : "";
            ViewData["SortToString"] = sortOrder == "string" ? "string_desc" : "string";
            ViewData["SortValidFrom"] = sortOrder == "validFrom" ? "validFrom_desc" : "validFrom";
            ViewData["SortValidTo"] = sortOrder == "validTo" ? "validTo_desc" : "validTo";
            paymentMethods.SortOrder = sortOrder != null && sortOrder.EndsWith("_desc")
                ? SortOrder.Descending
                : SortOrder.Ascending;
            paymentMethods.SortFunction = getSortFunction(sortOrder);
            if (searchString != null) page = 1;
            else searchString = currentFilter;
            ViewData["CurrentFilter"] = searchString;
            paymentMethods.SearchString = searchString;
            paymentMethods.PageIndex = page ?? 1;
            var l = await paymentMethods.GetObjectsList();
            return View(new PaymentMethodViewsList(l));
        }
        private Func<PaymentMethodData, object> getSortFunction(string sortOrder) {
            if (string.IsNullOrWhiteSpace(sortOrder)) return x => x.GetType().Name;
            if (sortOrder.StartsWith("type")) return x => x.GetType().Name;
            if (sortOrder.StartsWith("validTo")) return x => x.ValidTo;
            if (sortOrder.StartsWith("validFrom")) return x => x.ValidFrom;
            return x => x.Number;
        }
        public async Task<IActionResult> Delete(string id) {
            var paymentMethod = await paymentMethods.GetObject(id);
            switch (paymentMethod) {
                case Check check:
                    return View("DeleteCheck",
                        PaymentMethodViewFactory.Create(check) as CheckView);
                case DebitCard debitCard:
                    return View("DeleteDebitCard",
                        PaymentMethodViewFactory.Create(debitCard) as DebitCardView);
                case CreditCard creditCard:
                    return View("DeleteCreditCard",
                        PaymentMethodViewFactory.Create(creditCard) as CreditCardView);
            }

            return RedirectToAction("Index");
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id) {
            var c = await paymentMethods.GetObject(id);
            await paymentMethods.DeleteObject(c);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(string id) {
            var paymentMethod = await paymentMethods.GetObject(id);
            switch (paymentMethod) {
                case Check _: return RedirectToAction("EditCheck", new {id});
                case CreditCard _: return RedirectToAction("EditCreditCard", new {id});
                case DebitCard _: return RedirectToAction("EditDebitCard", new {id});
                default: return RedirectToAction("Index");
            }
        }
        public async Task<IActionResult> EditCheck(string id) {
            var paymentMethod = await paymentMethods.GetObject(id) as Check;
            return View(PaymentMethodViewFactory.Create(paymentMethod) as CheckView);
        }
        public async Task<IActionResult> EditCreditCard(string id) {
            var paymentMethod = await paymentMethods.GetObject(id) as CreditCard;
            return View(PaymentMethodViewFactory.Create(paymentMethod) as CreditCardView);
        }
        public async Task<IActionResult> EditDebitCard(string id) {
            var paymentMethod = await paymentMethods.GetObject(id) as DebitCard;
            return View(PaymentMethodViewFactory.Create(paymentMethod) as DebitCardView);
        }
        public async Task<IActionResult> Details(string id) {
            var c = await paymentMethods.GetObject(id);

            switch (c) {
                case Check check:
                    return View("DetailsCheck",
                        PaymentMethodViewFactory.Create(check) as CheckView);
                case DebitCard debitCard:
                    return View("DetailsDebitCard",
                        PaymentMethodViewFactory.Create(debitCard) as DebitCardView);
                case CreditCard creditCard:
                    return View("DetailsCreditCard",
                        PaymentMethodViewFactory.Create(creditCard) as CreditCardView);
            }

            return RedirectToAction("Index");
        }

        public IActionResult CreateDebitCard() {
            return View(new DebitCardView());
        }
        public IActionResult CreateCreditCard() {
            return View(new CreditCardView());
        }
        public IActionResult Create() {
            return View(new CheckView());
        }

        [HttpPost] public async Task<IActionResult> Create(
            [Bind(checkProperties)] CheckView c) {
            if (!ModelState.IsValid) return View(c);
            c.ID = c.ID ?? Guid.NewGuid().ToString();
            var o = PaymentMethodViewFactory.Create(c);
            await paymentMethods.AddObject(o);
            return RedirectToAction("Index");
        }

        [HttpPost] public async Task<IActionResult> EditCheck([Bind(checkProperties)] CheckView c) {
            if (!ModelState.IsValid) return View(c);
            var o = await paymentMethods.GetObject(c.ID) as Check;
            var n = PaymentMethodViewFactory.Create(c);
            copyDbRecords(o.Data, n.Data);
            o.Data.Payee = n.Data.Payee;
            await paymentMethods.UpdateObject(o);
            return RedirectToAction("Index");
        }

        [HttpPost] public async Task<IActionResult> CreateDebitCard(
            [Bind(debitCardProperties)] DebitCardView c) {
            if (!ModelState.IsValid) return View(c);
            c.ID = c.ID ?? Guid.NewGuid().ToString();
            var o = PaymentMethodViewFactory.Create(c);
            await paymentMethods.AddObject(o);
            return RedirectToAction("Index");
        }

        [HttpPost] public async Task<IActionResult> EditDebitCard(
            [Bind(debitCardProperties)] DebitCardView c) {
            if (!ModelState.IsValid) return View(c);
            var o = await paymentMethods.GetObject(c.ID) as DebitCard;
            var n = PaymentMethodViewFactory.Create(c);
            copyDbRecords(o.Data, n.Data);
            await paymentMethods.UpdateObject(o);
            return RedirectToAction("Index");
        }


        [HttpPost] public async Task<IActionResult> CreateCreditCard(
            [Bind(creditCardProperties)] CreditCardView c) {
            if (!ModelState.IsValid) return View(c);
            c.ID = c.ID ?? Guid.NewGuid().ToString();
            var o = PaymentMethodViewFactory.Create(c);
            await paymentMethods.AddObject(o);
            return RedirectToAction("Index");
        }

        [HttpPost] public async Task<IActionResult> EditCreditCard(
            [Bind(creditCardProperties)] CreditCardView c) {
            if (!ModelState.IsValid) return View(c);
            var o = await paymentMethods.GetObject(c.ID) as CreditCard;
            var n = PaymentMethodViewFactory.Create(c);
            copyDbRecords(o?.Data, n?.Data);
            o.Data.CreditLimit = n.Data.CreditLimit;
            await paymentMethods.UpdateObject(o);
            return RedirectToAction("Index");
        }
        private static void copyDbRecords(PaymentMethodData to, PaymentMethodData from) {
            to.Address = from.Address;
            to.Code = from.Code;
            to.CurrencyID = from.CurrencyID;
            to.DailyLimit = from.DailyLimit;
            to.Issue = from.Issue;
            to.Name = from.Name;
            to.Number = from.Number;
            to.Organization = from.Organization;
            to.ValidFrom = from.ValidFrom;
            to.ValidTo = from.ValidTo;
        }
    }
}