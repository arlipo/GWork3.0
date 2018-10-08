using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Quantity;
using Open.Domain.Quantity;
namespace Open.Tests.Domain.Quantity {
    [TestClass] public class PaymentTests : EntityBaseTests<Payment, PaymentData> {
        protected override Payment getRandomObject() {
            createdWithNullArg = new Payment(null);
            dbRecordType = typeof(PaymentData);
            var paymentmethod = getRandomPaymentMethod();
            var payment = GetRandom.Object<PaymentData>();
            payment.PaymentMethod = paymentmethod;
            return new Payment(payment);
        }

        private PaymentMethodData getRandomPaymentMethod() {
            var i = GetRandom.Int32() % 4;
            if (i == 0) return GetRandom.Object<CheckData>();
            if (i == 1) return GetRandom.Object<CreditCardData>();
            if (i == 2) return GetRandom.Object<DebitCardData>();
            return null;
        }

        [TestMethod] public void AmountTest() {
            Assert.AreEqual(obj.Amount.Amount, obj.Data.Amount);
            Assert.AreEqual(obj.Amount.Currency.ID, obj.Data.Currency.ID);
        }

        [TestMethod] public void PaymentMethodTest() {
            Assert.AreEqual(obj.PaymentMethod.ID, obj.Data.PaymentMethod?.ID??"Cash");
        }
    }
}