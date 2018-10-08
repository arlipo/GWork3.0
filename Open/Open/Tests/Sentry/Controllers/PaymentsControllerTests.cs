using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Quantity;
using Open.Domain.Quantity;
using Open.Facade.Quantity;
using Open.Infra.Quantity;
using Open.Sentry.Controllers;
namespace Open.Tests.Sentry.Controllers {

    [TestClass] public class
        PaymentsControllerTests : BaseControllerTests<PaymentsController, Payment, PaymentData> {

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            repository = new PaymentsRepository(db);
            controller = "payments";
            detailsViewCaption = "Payment";
            editViewCaption = detailsViewCaption;
        }

        protected override List<string> specificStringsToTestInIndexView()
        {
            return new List<string> {
                "<h2>Payments</h2>",
                "<a href=\"/payments/Create\">Create New</a>",
                "<th><a href=\"/payments?SortOrder=amount\">Amount</a></th>",
                "<th><a href=\"/payments?SortOrder=currency\">Currency</a></th>",
                "<th><a href=\"/payments?SortOrder=method\">Payment Method</a></th>",
                "<th><a href=\"/payments?SortOrder=due\">Date Due</a></th>",
                "<th><a href=\"/payments?SortOrder=validFrom_desc\">Date Made</a></th>",
                "<th><a href=\"/payments?SortOrder=validTo\">Valid To</a></th>"
            };
        }

        protected override async Task isNotInRepository(string id) {
            var r = await repository.GetObject(id);
            Assert.AreEqual(r.Data.ID, Constants.Unspecified);
        }

        protected override async Task validateEntityInRepository(object o) {
            var expected = o as PaymentView;
            var actual = await repository.GetObject(expected?.ID);
            Assert.IsNotNull(expected);
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.ID, actual.Data.ID);
            validateDates(expected.DateDue, actual.Data.DateDue);
            validateDates(expected.DateMade, actual.Data.DateMade);
            Assert.AreEqual(expected.PaymentMethodID, actual.Data.PaymentMethodID);
            Assert.AreEqual(expected.Amount, actual.Data.Amount);
            Assert.AreEqual(expected.CurrencyID, actual.Data.CurrencyID);
            validateDates(expected.ValidFrom, actual.Data.ValidFrom);
            validateDates(expected.ValidTo, actual.Data.ValidTo);
        }

        protected override IEnumerable<KeyValuePair<string, string>>
            createHttpPostContext(object o) {

            var c = o as PaymentView;
            var d = new Dictionary<string, string> {
                {GetMember.Name<PaymentView>(m => m.ID), c?.ID}, {
                    GetMember.Name<PaymentView>(m => m.Amount),
                    c?.Amount.ToString(CultureInfo.InvariantCulture)
                },
                {GetMember.Name<PaymentView>(m => m.CurrencyID), c?.CurrencyID},
                {GetMember.Name<PaymentView>(m => m.PaymentMethodID), c?.PaymentMethodID},
                {GetMember.Name<PaymentView>(m => m.DateDue), c?.DateDue.ToString()},
                {GetMember.Name<PaymentView>(m => m.DateMade), c?.DateMade.ToString()},
                {GetMember.Name<PaymentView>(m => m.ValidTo), c?.ValidTo.ToString()}
            };
            return d;
        }

        protected override object createRandomViewModel() {
            var v = GetRandom.Object<PaymentView>();
            v.ValidTo = GetRandom.DateTime(v.ValidFrom);
            addCurrency(v.CurrencyID);
            addPaymentMethod(v.PaymentMethodID);
            return v;
        }

        protected override string createDbRecord() {
            var r = GetRandom.Object<PaymentData>();
            db.Payments.Add(r);
            db.SaveChanges();
            specificStringsToTestInView = new List<string> {
                $"{r.CurrencyID}",
                $"{r.PaymentMethodID}",
                $"{r.Amount.ToString(CultureInfo.CurrentCulture)}"
            };
            return r.ID;
        }
    }
}
