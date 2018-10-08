using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Quantity;
namespace Open.Tests.Facade.Quantity {
    [TestClass] public class PaymentViewTests : ViewTests<PaymentView, MoneyView> {
        protected override PaymentView getRandomObject() { return GetRandom.Object<PaymentView>(); }

        [TestMethod] public void PaymentMethodIDTest() {
            canReadWrite(() => obj.PaymentMethodID, x => obj.PaymentMethodID = x);
        }
        [TestMethod] public void PaymentMethodTest() {
            Assert.AreEqual(typeof(MoneyView), typeof(PaymentView).BaseType);
        }

        [TestMethod] public void DateDueTest() {
            DateTime? rnd() => GetRandom.DateTime(null, obj.DateMade?.AddYears(-1));
            canReadWrite(() => obj.DateDue, x => obj.DateDue = x, rnd);
        }
        [TestMethod] public void DateMadeTest() {
            Assert.AreEqual(obj.DateMade, obj.ValidFrom);

            var d = GetRandom.DateTime(maxValue: obj.ValidTo);
            obj.DateMade = d;
            Assert.AreEqual(d, obj.ValidFrom);
            Assert.AreEqual(d, obj.DateMade);

            d = GetRandom.DateTime(maxValue: obj.ValidTo);
            obj.ValidFrom = d;
            Assert.AreEqual(d, obj.ValidFrom);
            Assert.AreEqual(d, obj.DateMade);
        }
    }
}