using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Domain.ShoppingCart;
using Open.Facade.ShoppingCart;

namespace Open.Tests.Facade.ShoppingCart
{
    [TestClass]
    public class CartViewsListTests : ObjectTests<CartViewsList>
    {
        protected override CartViewsList getRandomObject() {
            var l = new Cart();
            SetRandom.Values(l);
            return new CartViewsList(l);
        }

        [TestMethod] public void CanCreateWithNullArgumentTest() {
            Assert.IsNotNull(new CartViewsList(null));
        }
        [TestMethod] public void SubTotalTest() {
            Assert.Inconclusive();
        }
    }
}
