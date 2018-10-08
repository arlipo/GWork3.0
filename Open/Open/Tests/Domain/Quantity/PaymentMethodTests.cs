using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Quantity;
using Open.Domain.Common;
using Open.Domain.Quantity;
namespace Open.Tests.Domain.Quantity {
    [TestClass] public class PaymentMethodTests : ObjectTests<PaymentMethod<CreditCardData>> {
        private class testClass : PaymentMethod<CreditCardData> {
            public testClass(CreditCardData dbRecord) : base(dbRecord) { }
        }

        protected override PaymentMethod<CreditCardData> getRandomObject() {
            return GetRandom.Object<testClass>();
        }

        [TestMethod] public void ConstructorTest() {
            Assert.AreEqual(obj.GetType().BaseType.BaseType, typeof(Entity<CreditCardData>));
        }
        [TestMethod] public void IDTest() {
            Assert.AreEqual(obj.ID, obj.Data.ID);
        }
    }
}