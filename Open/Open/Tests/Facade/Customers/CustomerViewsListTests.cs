using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Domain.Customers;
using Open.Facade.Customers;

namespace Open.Tests.Facade.Customers
{
    [TestClass]
    public class CustomerViewsListTests : ObjectTests<CustomerViewsList>
    {
        protected override CustomerViewsList getRandomObject() {
            var l = new CustomersList(null, null);
            SetRandom.Values(l);
            return new CustomerViewsList(l);
        }

        [TestMethod] public void CanCreateWithNullArgumentTest() {
            Assert.IsNotNull(new CustomerViewsList(null));
        }
    }
}
