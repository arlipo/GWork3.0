using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Data.Common;
using Open.Data.Customers;

namespace Open.Tests.Data.Customers
{
    [TestClass]
    public class CustomersDataTests : ObjectTests<CustomersData>
    {
        [TestMethod]
        public void BaseTypeIsNamedData()
        {
            Assert.AreEqual(typeof(NamedData), typeof(CustomersData).BaseType);
        }
    }
}
