using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Quantity;
using Open.Domain.Quantity;
namespace Open.Tests.Domain.Quantity {
    [TestClass] public class CreditCardTests : ObjectTests<CreditCard> {
        protected override CreditCard getRandomObject() { return GetRandom.Object<CreditCard>(); }

        [TestMethod] public void ConstructorTest() {
            Assert.AreEqual(obj.GetType().BaseType, typeof(CardPaymentMethod<CreditCardData>));
        }

        [TestMethod] public void CreditLimitTest() {
            Assert.AreEqual(obj.CreditLimit.Amount, obj.Data.CreditLimit);
            Assert.AreEqual(obj.CreditLimit.Currency.ID, obj.Data.Currency.ID);
        }
    }
}
