using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Quantity;
namespace Open.Tests.Data.Quantity {
    [TestClass] public class CreditCardDataTests : ObjectTests<CreditCardData> {
        protected override CreditCardData getRandomObject() {
            return GetRandom.Object<CreditCardData>();
        }

        [TestMethod] public void ConstructorTest() {
            Assert.AreEqual(obj.GetType().BaseType, typeof(PaymentMethodData));
        }

        [TestMethod] public void CreditLimitTest() {
            canReadWrite(() => obj.CreditLimit, x => obj.CreditLimit = x);
        }
    }
}