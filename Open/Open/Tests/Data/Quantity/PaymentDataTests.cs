using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Common;
using Open.Data.Quantity;
namespace Open.Tests.Data.Quantity {
    [TestClass] public class PaymentDataTests : ObjectTests<PaymentData> {
        protected override PaymentData getRandomObject() {
            var p = GetRandom.Object<PaymentData>();
            p.PaymentMethod = getRandomPaymentMethod();
            return p;
        }
        [TestMethod] public void ConstructorTest() {
            Assert.AreEqual(obj.GetType().BaseType, typeof(IdentifiedData));
        }

        [TestMethod] public void AmountTest() {
            canReadWrite(() => obj.Amount, x => obj.Amount = x);
        }

        [TestMethod] public void DateDueTest() {
            canReadWrite(() => obj.DateDue, x => obj.DateDue = x);
        }

        [TestMethod] public void DateMadeTest() {
            Assert.AreEqual(obj.DateMade, obj.ValidFrom);
            var d = GetRandom.DateTime(maxValue: obj.ValidTo);
            obj.DateMade = d;
            Assert.AreEqual(obj.DateMade, obj.ValidFrom);
            d = GetRandom.DateTime(maxValue: obj.ValidTo);
            obj.ValidFrom = d;
            Assert.AreEqual(obj.DateMade, obj.ValidFrom);
        }

        [TestMethod] public void PaymentMethodTest() {
            canReadWrite(() => obj.PaymentMethod, x => obj.PaymentMethod = x,
                getRandomPaymentMethod);
        }

        private PaymentMethodData getRandomPaymentMethod() {
            var b = GetRandom.Int32()%3;
            if (b==0) return GetRandom.Object<CreditCardData>();
            if (b == 1) return GetRandom.Object<CheckData>();
            return GetRandom.Object<DebitCardData>();
        }

        [TestMethod] public void PaymentMethodIDTest() {
            canReadWrite(() => obj.PaymentMethodID, x => obj.PaymentMethodID = x);
        }

        [TestMethod]
        public void CurrencyIDTest() {
            canReadWrite(() => obj.CurrencyID, x => obj.CurrencyID = x);
        }

        [TestMethod]
        public void CurrencyTest() {
            canReadWrite(() => obj.Currency, x => obj.Currency = x);
        }
    }
}