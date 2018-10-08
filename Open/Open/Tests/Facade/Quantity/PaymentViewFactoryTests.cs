using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Quantity;
using Open.Domain.Quantity;
using Open.Facade.Quantity;
namespace Open.Tests.Facade.Quantity {
    [TestClass] public class PaymentViewFactoryTests : BaseTests {
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(PaymentViewFactory);
        }

        [TestMethod] public void CreateTest() {
            var r = GetRandom.Object<PaymentData>();
            r.ValidTo = GetRandom.DateTime(r.ValidFrom);
            r.PaymentMethod = getRandomPaymentMethod();
            r.PaymentMethodID = r.PaymentMethod.ID;
            var o = new Payment(r);
            var v = PaymentViewFactory.Create(o);
            Assert.AreEqual(v.ID, o.Data.ID);
            Assert.AreEqual(v.Amount, o.Data.Amount);
            Assert.AreEqual(v.PaymentMethodID, o.Data.PaymentMethodID);
            Assert.AreEqual(v.CurrencyID, o.Data.CurrencyID);
            Assert.AreEqual(v.DateDue, o.Data.DateDue);
            Assert.AreEqual(v.DateMade, o.Data.DateMade);
            Assert.AreEqual(v.ValidFrom, o.Data.ValidFrom);
            Assert.AreEqual(v.ValidTo, o.Data.ValidTo);
        }

        private PaymentMethodData getRandomPaymentMethod() {
            var i = GetRandom.Int32() % 3;
            if (i == 0) return GetRandom.Object<CreditCardData>();
            if (i == 1) return GetRandom.Object<DebitCardData>();
            return GetRandom.Object<CheckData>();
        }
    }
}