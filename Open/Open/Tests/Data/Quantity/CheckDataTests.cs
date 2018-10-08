using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Quantity;
namespace Open.Tests.Data.Quantity {
    [TestClass] public class CheckDataTests : ObjectTests<CheckData> {
        protected override CheckData getRandomObject() {
            return GetRandom.Object<CheckData>();
        }

        [TestMethod] public void IsPaymentMethodDbRecord() {
            Assert.AreEqual(obj.GetType().BaseType, typeof(PaymentMethodData));
        }

        [TestMethod] public void PayeeTest() {
            canReadWrite(() => obj.Payee, x => obj.Payee = x);
        }
    }
}