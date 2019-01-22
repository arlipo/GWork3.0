using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Data.ShoppingCart;
using Open.Domain.ShoppingCart;

namespace Open.Tests.Domain.ShoppingCart
{
    [TestClass]
    public class CartItemTests : ObjectTests<CartItem>
    {
        [TestMethod]
        public void DataTest()
        {
            Assert.IsNotNull(obj.Data);
            Assert.IsInstanceOfType(obj.Data, typeof(CartData));
        }

        [TestMethod]
        public void CanCreateWithNullArgumentTest()
        {
            var createdWithNullArg = new CartItem(null);
            Assert.IsNotNull(createdWithNullArg.Data);
            Assert.IsInstanceOfType(createdWithNullArg.Data, typeof(CartData));
        }

        [TestMethod]
        public void EqualsTest()
        {
            Assert.IsTrue(obj.Equals(obj));
        }
    }
}