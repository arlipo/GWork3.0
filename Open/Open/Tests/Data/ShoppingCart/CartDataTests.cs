using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Core;
using Open.Data.Common;
using Open.Data.ShoppingCart;

namespace Open.Tests.Data.ShoppingCart
{
    [TestClass]
    public class CartDataTests : ObjectTests<CartData>
    {
        [TestMethod]
        public void BaseTypeIsArchetype()
        {
            Assert.AreEqual(typeof(Archetype), typeof(CartData).BaseType);
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
    }
}
