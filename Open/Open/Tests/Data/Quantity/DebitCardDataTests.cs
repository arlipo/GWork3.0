using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Quantity;
namespace Open.Tests.Data.Quantity {
    [TestClass] public class DebitCardDataTests : ObjectTests<DebitCardData> {
        protected override DebitCardData getRandomObject() {
            return GetRandom.Object<DebitCardData>();
        }
        [TestMethod] public void IsPaymentMethodDbRecord() {
            Assert.AreEqual(obj.GetType().BaseType, typeof(PaymentMethodData));
        }
    }
}