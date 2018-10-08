using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Quantity;
using Open.Domain.Quantity;
namespace Open.Tests.Domain.Quantity {
    [TestClass] public class CheckTests : ObjectTests<Check> {
        protected override Check getRandomObject() {
            return GetRandom.Object<Check>();
        }

        [TestMethod] public void ConstructorTest() {
            Assert.AreEqual(obj.GetType().BaseType, typeof(PaymentMethod<CheckData>));
        }
    }
}