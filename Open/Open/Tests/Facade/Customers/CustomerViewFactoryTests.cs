using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Customers;
using Open.Domain.Customers;
using Open.Facade.Customers;

namespace Open.Tests.Facade.Customers
{
    [TestClass]
    public class CustomerViewFactoryTests : BaseTests
    {
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(CustomerViewFactory);
        }

        [TestMethod] public void CreateTest() {
            var r = GetRandom.Object<CustomersData>();
            var o = new Customer(r);
            var v = CustomerViewFactory.Create(o);
            Assert.AreEqual(v.Name, o.Data.Name);
            Assert.AreEqual(v.ValidFrom, o.Data.ValidFrom);
            Assert.AreEqual(v.ValidTo, o.Data.ValidTo);
            Assert.AreEqual(v.ID, o.Data.ID);
        }
    }
}
