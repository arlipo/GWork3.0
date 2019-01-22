using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Customers;
using Open.Domain.Customers;

namespace Open.Tests.Domain.Customers
{
    [TestClass]
    public class CustomerFactoryTests : BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(CustomerFactory);
        }

        [TestMethod]
        public void CreateTest()
        {
            var r = GetRandom.Object<CustomersData>();

            var o = CustomerFactory.Create(r.ID, r.Name, r.ValidFrom, r.ValidTo);

            Assert.AreEqual(r.Name, o.Data.Name);
            Assert.AreEqual(r.ID, o.Data.ID);
            Assert.AreEqual(r.ValidFrom, o.Data.ValidFrom);
            Assert.AreEqual(r.ValidTo, o.Data.ValidTo);
        }

        [TestMethod]
        public void CreateWithNullTest()
        {
            var o = CustomerFactory.Create(null);
            Assert.IsNotNull(o);
        }
    }
}