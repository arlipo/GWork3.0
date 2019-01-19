using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Common;
using Open.Facade.Customers;

namespace Open.Tests.Facade.Customers
{
    [TestClass]
    public class CustomerViewTests : ViewTests<CustomerView, EntityView>
    {
        protected override CustomerView getRandomObject()
        {
            return GetRandom.Object<CustomerView>();
        }

        [TestMethod]
        public void NameTest()
        {
            canReadWrite(() => obj.Name, x => obj.Name = x);
        }
    }
}
