using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Quantity;
using Open.Domain.Quantity;
using Open.Facade.Quantity;
namespace Open.Tests.Facade.Quantity {
    [TestClass] public class PaymentMethodViewFactoryTests : BaseTests {
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(PaymentMethodViewFactory);
        }

        [TestMethod] public void CreateTest() { }

        [TestMethod] public void CreateCashTest() {
            var view = GetRandom.Object<CashView>();
            var cash = PaymentMethodViewFactory.Create(view);
            Assert.IsInstanceOfType(cash, typeof(Cash));
        }
        [TestMethod] public void CreateCashViewTest() {
            var cash = GetRandom.Object<Cash>();
            var view = PaymentMethodViewFactory.Create(cash);
            Assert.IsInstanceOfType(view, typeof(CashView));
            Assert.AreEqual("Cash", view.ID);
            Assert.AreEqual(null, view.ValidFrom);
            Assert.AreEqual(null, view.ValidTo);
        }
        [TestMethod] public void CreateCheckTest() {
            var view = GetRandom.Object<CheckView>();
            view.ValidTo = GetRandom.DateTime(view.ValidFrom);
            var check = PaymentMethodViewFactory.Create(view);
            Assert.IsInstanceOfType(check, typeof(Check));
            validateCheck(view, check);
        }

        private void validateCheck(CheckView view, Check check) {
            Assert.AreEqual(view.AccountName, check.Data.Name);
            Assert.AreEqual(view.AccountNumber, check.Data.Number);
            Assert.AreEqual(view.BankAddress, check.Data.Address);
            Assert.AreEqual(view.BankID, check.Data.Issue);
            Assert.AreEqual(view.BankName, check.Data.Organization);
            Assert.AreEqual(view.Payee, check.Data.Payee);
            Assert.AreEqual(view.CheckNumber, check.Data.Code);
            Assert.AreEqual(view.ID, check.Data.ID);
            Assert.AreEqual(view.ValidFrom, check.Data.ValidFrom);
            Assert.AreEqual(view.ValidTo, check.Data.ValidTo);
        }
        [TestMethod] public void CreateCheckViewTest() {
            var check = GetRandom.Object<Check>();
            var view = PaymentMethodViewFactory.Create(check) as CheckView;
            Assert.IsInstanceOfType(view, typeof(CheckView));
            validateCheck(view, check);
        }
        [TestMethod] public void CreateCreditCardTest() {
            var view = GetRandom.Object<CreditCardView>();
            view.ValidTo = GetRandom.DateTime(view.ValidFrom);
            var card = PaymentMethodViewFactory.Create(view);
            Assert.IsInstanceOfType(card, typeof(CreditCard));
            validateCreditCard(view, card);
        }
        [TestMethod] public void CreateCreditCardViewTest() {
            var data = GetRandom.Object<CreditCardData>();
            data.CurrencyID = data.Currency.ID;
            var card = new CreditCard(data);
            var view = PaymentMethodViewFactory.Create(card) as CreditCardView;
            Assert.IsInstanceOfType(view, typeof(CreditCardView));
            validateCreditCard(view, card);
        }
        private void validateCreditCard(CreditCardView view, CreditCard card) {
            Assert.AreEqual(view.CardNumber, card.Data.Number);
            Assert.AreEqual(view.CreditLimit, card.CreditLimit.Amount);
            Assert.AreEqual(view.CurrencyID, card.CreditLimit.Currency.ID);
            Assert.AreEqual(view.DailyLimit, card.DailyLimit.Amount);
            Assert.AreEqual(view.CurrencyID, card.DailyLimit.Currency.ID);
            Assert.AreEqual(view.BillingAddress, card.Data.Address);
            Assert.AreEqual(view.CardName, card.Data.Organization);
            Assert.AreEqual(view.NameOnCard, card.Data.Name);
            Assert.AreEqual(view.VerificationCode, card.Data.Code);
            Assert.AreEqual(view.IssueNumber, card.Data.Issue);
            Assert.AreEqual(view.ID, card.Data.ID);
            Assert.AreEqual(view.ValidFrom, card.Data.ValidFrom);
            Assert.AreEqual(view.ValidTo, card.Data.ValidTo);
        }

        [TestMethod] public void CreateDebitCardTest() {
            var view = GetRandom.Object<DebitCardView>();
            view.ValidTo = GetRandom.DateTime(view.ValidFrom);
            var card = PaymentMethodViewFactory.Create(view);
            Assert.IsInstanceOfType(card, typeof(DebitCard));
            validateDebitCard(view, card);
        }
        [TestMethod] public void CreateDebitCardViewTest() {
            var data = GetRandom.Object<DebitCardData>();
            data.CurrencyID = data.Currency.ID;
            var card = new DebitCard(data);
            var view = PaymentMethodViewFactory.Create(card) as DebitCardView;
            Assert.IsInstanceOfType(view, typeof(DebitCardView));
            validateDebitCard(view, card);
        }
        private void validateDebitCard(DebitCardView view, DebitCard card) {
            Assert.AreEqual(view.CardNumber, card.Data.Number);
            Assert.AreEqual(view.DailyLimit, card.DailyLimit.Amount);
            Assert.AreEqual(view.CurrencyID, card.DailyLimit.Currency.ID);
            Assert.AreEqual(view.BillingAddress, card.Data.Address);
            Assert.AreEqual(view.CardName, card.Data.Organization);
            Assert.AreEqual(view.NameOnCard, card.Data.Name);
            Assert.AreEqual(view.VerificationCode, card.Data.Code);
            Assert.AreEqual(view.IssueNumber, card.Data.Issue);
            Assert.AreEqual(view.ID, card.Data.ID);
            Assert.AreEqual(view.ValidFrom, card.Data.ValidFrom);
            Assert.AreEqual(view.ValidTo, card.Data.ValidTo);
        }
    }
}