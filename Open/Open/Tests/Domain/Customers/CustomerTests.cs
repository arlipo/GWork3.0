using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Customers;
using Open.Domain.Customers;

namespace Open.Tests.Domain.Customers
{
    [TestClass]
    public class CustomerTests : EntityBaseTests<Customer, CustomersData>
    {
        protected override Customer getRandomObject()
        {
            createdWithNullArg = new Customer(null);
            dbRecordType = typeof(CustomersData);
            return GetRandom.Object<Customer>();
        }
    }
}