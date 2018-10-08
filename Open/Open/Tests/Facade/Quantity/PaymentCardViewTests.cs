using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Quantity;
namespace Open.Tests.Facade.Quantity {
    [TestClass] public class PaymentCardViewTests : ObjectTests<PaymentCardView> {
        private class testClass : PaymentCardView { }
        protected override PaymentCardView getRandomObject() {
            return GetRandom.Object<testClass>();
        }

        [TestMethod] public void IsAbstract() { Assert.IsTrue(typeof(PaymentCardView).IsAbstract); }

        [TestMethod] public void BaseTypeIsUniqueDbRecord() {
            Assert.AreEqual(typeof(PaymentMethodView), typeof(PaymentCardView).BaseType);
        }
        [TestMethod] public void CardNumberTest() {
            canReadWrite(() => obj.CardNumber, x => obj.CardNumber = x);
        }
        [TestMethod] public void CardNameTest() {
            canReadWrite(() => obj.CardName, x => obj.CardName = x);
        }
        [TestMethod] public void NameOnCardTest() {
            canReadWrite(() => obj.NameOnCard, x => obj.NameOnCard = x);
        }
        [TestMethod] public void ExpireDateTest() {
            Assert.AreEqual(obj.ExpireDate, obj.ValidTo);
            obj.ValidTo = GetRandom.DateTime(obj.ValidFrom);
            Assert.AreEqual(obj.ExpireDate, obj.ValidTo);

        }
        [TestMethod] public void BillingAddressTest() {
            canReadWrite(() => obj.BillingAddress, x => obj.BillingAddress = x);
        }
        [TestMethod] public void VerificationCodeTest() {
            canReadWrite(() => obj.VerificationCode, x => obj.VerificationCode = x);
        }
        [TestMethod] public void IssueNumberTest() {
            canReadWrite(() => obj.IssueNumber, x => obj.IssueNumber = x);
        }
        [TestMethod] public void DailyLimitTest() {
            canReadWrite(() => obj.DailyLimit, x => obj.DailyLimit = x);
        }
        [TestMethod]
        public void CurrencyIDTest()
        {
            canReadWrite(() => obj.CurrencyID, x => obj.CurrencyID = x);
        }
    }
}