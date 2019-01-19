using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Facade.ShoppingCart;

namespace Open.Tests.Facade.ShoppingCart
{
    [TestClass]
    public class CartViewTests : ViewTests<CartView, Archetype>
    {
        protected override CartView getRandomObject()
        {
            return GetRandom.Object<CartView>();
        }

        [TestMethod]
        public void IDTest()
        {
            canReadWrite(() => obj.ID, x => obj.ID = x);
        }

        [TestMethod]
        public void NameTest()
        {
            Assert.IsNotNull(obj.Name);
        }

        [TestMethod]
        public void QuantityTest()
        {
            canReadWrite(() => obj.Quantity, x => obj.Quantity = x);
        }
    }
}
