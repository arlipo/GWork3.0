using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Domain.Quantity;
namespace Open.Tests.Domain.Quantity {
    [TestClass] public class CashTests : ObjectTests<Cash> {
        protected override Cash getRandomObject() {
            return GetRandom.Object<Cash>();
        }
        [TestMethod] public void IDTest() {
            Assert.AreEqual("Cash", obj.ID);
        }
    }
}