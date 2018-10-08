using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Quantity;
using Open.Domain.Quantity;
namespace Open.Tests.Domain.Quantity {
    [TestClass] public class DebitCardTests : ObjectTests<DebitCard>
    {
        protected override DebitCard getRandomObject() { return GetRandom.Object<DebitCard>(); }

        [TestMethod] public void ConstructorTest() {
            Assert.AreEqual(obj.GetType().BaseType, typeof(CardPaymentMethod<DebitCardData>));
        }
    }
}
