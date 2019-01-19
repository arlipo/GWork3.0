using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.ShoppingCart;
using Open.Domain.ShoppingCart;
using Open.Facade.ShoppingCart;

namespace Open.Tests.Facade.ShoppingCart
{
    [TestClass]
    public class CartViewFactoryTests : BaseTests
    {
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(CartViewFactory);
        }

        [TestMethod] public void CreateTest() {
            var r = GetRandom.Object<CartData>();
            var o = new CartItem(r);
            var v = CartViewFactory.Create(o);
            Assert.AreEqual(v.Name, o.Data.Name);
            Assert.AreEqual(v.ID, o.Data.ID);
            Assert.AreEqual(v.Quantity, o.Data.Quantity);
            Assert.AreEqual(v.GoodsData, o.Data.GoodsData);
        }
    }
}
