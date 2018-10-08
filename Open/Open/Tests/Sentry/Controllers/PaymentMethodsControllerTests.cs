using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Quantity;
using Open.Domain.Quantity;
using Open.Facade.Common;
using Open.Facade.Quantity;
using Open.Infra.Quantity;
using Open.Sentry.Controllers;
using Open.Tests.Domain.Quantity;
namespace Open.Tests.Sentry.Controllers {
    [TestClass]
    public class PaymentMethodsControllerTests : BaseControllerTests<PaymentMethodsController,
        IPaymentMethod, PaymentMethodData> {
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            repository = new PaymentMethodsRepository(db);
            controller = "paymentmethods";
            detailsViewCaption = "Check";
        }
        protected override string createDbRecord() {
            var r = PaymentMethodsListTests.getRandomPaymentMethodDbRecord();
            db.PaymentMethods.Add(r);
            db.SaveChanges();
            specificStringsToTestInView = createSpecificStrings(r);
            detailsViewCaption = $"{getType(r)}";
            editViewCaption = detailsViewCaption;
            actualEditAction = getEditAction(r);
            return r.ID;
        }
        private static string getEditAction(PaymentMethodData d) {
            switch (d) {
                case DebitCardData _: return "EditDebitCard";
                case CreditCardData _: return "EditCreditCard";
            }
            return "EditCheck";
        }
        private static List<string> createSpecificStrings(PaymentMethodData r) {
            var l = new List<string> {
                $"{r.Code}",
                $"{r.Address}",
                $"{r.Issue}",
                $"{r.Number}",
                $"{r.Organization}",
                $"{r.Name}"
            };
            if (r is CheckData) return l;
            l.Add($"{r.CurrencyID}");
            return l;
        }
        private static string getType(PaymentMethodData p) {
            switch (p) {
                case DebitCardData _: return "DebitCard";
                case CreditCardData _: return "CreditCard";
            }
            return "Check";
        }

        protected override List<string> specificStringsToTestInIndexView()
        {
            return new List<string> {
                "<h2>Payment Methods</h2>",
                "<t>Create new </t>",
                "<a href=\"/paymentmethods/Create\">Check</a>",
                "<a href=\"/paymentmethods/CreateCreditCard\">Credit Card</a>",
                "<a href=\"/paymentmethods/CreateDebitCard\">Debit Card</a>",
                "<th><a href=\"/paymentmethods?SortOrder=type_desc\">PaymentType</a></th>",
                "<th><a href=\"/paymentmethods?SortOrder=string\">Content</a></th>",
                "<th><a href=\"/paymentmethods?SortOrder=validFrom\">Valid From</a></th>",
                "<th><a href=\"/paymentmethods?SortOrder=validFrom\">Valid To</a></th>"
            };
        }

        protected override async Task isNotInRepository(string id) {
            var r = await repository.GetObject(id);
            id = getID(r);
            Assert.AreEqual(id, new Cash().ID);
        }
        protected override async Task validateEntityInRepository(object o) {
            var expected = o as EntityView;
            var actual = await repository.GetObject(expected?.ID);
            switch (o) {
                case CheckView check:
                    validateEntity(check, (actual as Check)?.Data);
                    break;
                case CreditCardView credit:
                    validateEntity(credit, (actual as CreditCard)?.Data);
                    break;
                case DebitCardView debit:
                    validateEntity(debit, (actual as DebitCard)?.Data);
                    break;
                default:
                    Assert.Fail($"Wrong type {o.GetType()}");
                    break;
            }
        }
        private void validateEntity(PaymentCardView expected, PaymentMethodData actual) {
            Assert.IsNotNull(expected);
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.ID, actual.ID);
            Assert.AreEqual(expected.BillingAddress, actual.Address);
            Assert.AreEqual(expected.CardName, actual.Organization);
            Assert.AreEqual(expected.CardNumber, actual.Number);
            Assert.AreEqual(expected.CurrencyID, actual.CurrencyID);
            Assert.AreEqual(expected.DailyLimit, actual.DailyLimit);
            Assert.AreEqual(expected.IssueNumber, actual.Issue);
            Assert.AreEqual(expected.NameOnCard, actual.Name);
            validateDates(expected.ExpireDate, actual.ValidTo);
            validateDates(expected.ValidFrom, actual.ValidFrom);
            validateDates(expected.ValidTo, actual.ValidTo);
        }
        private void validateEntity(CreditCardView expected, CreditCardData actual) {
            validateEntity(expected, actual as PaymentMethodData);
            Assert.AreEqual(expected.CreditLimit, actual.CreditLimit);
        }
        private void validateEntity(CheckView expected, CheckData actual) {
            Assert.IsNotNull(expected);
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.ID, actual.ID);
            Assert.AreEqual(expected.AccountName, actual.Name);
            Assert.AreEqual(expected.AccountNumber, actual.Number);
            Assert.AreEqual(expected.BankAddress, actual.Address);
            Assert.AreEqual(expected.BankID, actual.Issue);
            Assert.AreEqual(expected.BankName, actual.Organization);
            Assert.AreEqual(expected.CheckNumber, actual.Code);
            Assert.AreEqual(expected.Payee, actual.Payee);
            validateDates(expected.DateWritten, actual.ValidFrom);
            validateDates(expected.ValidFrom, actual.ValidFrom);
            validateDates(expected.ValidTo, actual.ValidTo);
        }
        protected override IEnumerable<KeyValuePair<string, string>>
            createHttpPostContext(object o) {
            switch (o) {
                case CheckView check: return httpPostContext(check);
                case CreditCardView credit: return httpPostContext(credit);
                case DebitCardView debit: return httpPostContext(debit);
                default: return new Dictionary<string, string>();
            }
        }

        private static Dictionary<string, string> httpPostContext(PaymentCardView o) {
            var d = new Dictionary<string, string> {
                {GetMember.Name<PaymentCardView>(m => m.ID), o?.ID},
                {GetMember.Name<PaymentCardView>(m => m.BillingAddress), o?.BillingAddress},
                {GetMember.Name<PaymentCardView>(m => m.CardName), o?.CardName},
                {GetMember.Name<PaymentCardView>(m => m.CardNumber), o?.CardNumber},
                {GetMember.Name<PaymentCardView>(m => m.CurrencyID), o?.CurrencyID}, {
                    GetMember.Name<PaymentCardView>(m => m.DailyLimit),
                    o?.DailyLimit.ToString(CultureInfo.CurrentCulture)
                },
                {GetMember.Name<PaymentCardView>(m => m.IssueNumber), o?.IssueNumber},
                {GetMember.Name<PaymentCardView>(m => m.NameOnCard), o?.NameOnCard},
                {GetMember.Name<PaymentCardView>(m => m.ExpireDate), o?.ExpireDate.ToString()},
                {GetMember.Name<PaymentCardView>(m => m.ValidFrom), o?.ValidFrom.ToString()}
            };
            return d;
        }

        private static Dictionary<string, string> httpPostContext(CreditCardView o) {
            var d = httpPostContext(o as PaymentCardView);
            d.Add(GetMember.Name<CreditCardView>(m => m.CreditLimit),
                o?.CreditLimit.ToString(CultureInfo.CurrentCulture));
            return d;
        }

        private static Dictionary<string, string> httpPostContext(CheckView o) {
            var d = new Dictionary<string, string> {
                {GetMember.Name<CheckView>(m => m.ID), o?.ID},
                {GetMember.Name<CheckView>(m => m.AccountName), o?.AccountName},
                {GetMember.Name<CheckView>(m => m.AccountNumber), o?.AccountNumber},
                {GetMember.Name<CheckView>(m => m.CheckNumber), o?.CheckNumber},
                {GetMember.Name<CheckView>(m => m.Payee), o?.Payee},
                {GetMember.Name<CheckView>(m => m.BankName), o?.BankName},
                {GetMember.Name<CheckView>(m => m.BankAddress), o?.BankAddress},
                {GetMember.Name<CheckView>(m => m.BankID), o?.BankID},
                {GetMember.Name<CheckView>(m => m.DateWritten), o?.DateWritten.ToString()},
                {GetMember.Name<CheckView>(m => m.ValidTo), o?.ValidTo.ToString()}
            };
            return d;
        }

        protected override object createRandomViewModel() {
            var v = GetRandom.Object<CheckView>();
            v.ValidTo = GetRandom.DateTime(v.ValidFrom);
            return v;
        }
        protected object createRandomCreditCardViewModel() {
            var v = GetRandom.Object<CreditCardView>();
            v.ValidTo = GetRandom.DateTime(v.ValidFrom);
            return v;
        }
        protected object createRandomDebitCardViewModel() {
            var v = GetRandom.Object<DebitCardView>();
            v.ValidTo = GetRandom.DateTime(v.ValidFrom);
            return v;
        }
        private string getID(IPaymentMethod m) {
            switch (m) {
                case Check check: return check.Data.ID;
                case CreditCard credit: return credit.Data.ID;
                case DebitCard debit: return debit.Data.ID;
                case Cash cash: return cash.ID;
                default: return string.Empty;
            }
        }

        [TestMethod] public void EditCheckTest() { Assert.Inconclusive(); }

        [TestMethod] public void EditCreditCardTest() { Assert.Inconclusive(); }

        [TestMethod] public void EditDebitCardTest() { Assert.Inconclusive(); }

        [TestMethod] public async Task CreateCreditCardTest() {
            await createTest(x => x.CreateCreditCard(), controller, "CreditCard",
                "createcreditcard");
        }

        [TestMethod] public async Task CreateDebitCardTest() {
            await createTest(x => x.CreateDebitCard(), controller, "DebitCard", "createdebitcard");
        }
        [TestMethod] public async Task CreateCreditCardAllGivenTest() {
            await createAllGivenTest<PaymentMethodsController>(createRandomCreditCardViewModel,
                x => x.CreateCreditCard());
        }

        [TestMethod] public async Task CreateDebitCardAllGivenTest() {
            await createAllGivenTest<PaymentMethodsController>(createRandomDebitCardViewModel,
                x => x.CreateDebitCard());
        }

    }
}
