using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Customers;
using Open.Domain.Customers;

namespace Open.Tests.Domain.Customers
{
    [TestClass]
    public class CustomersListTests : ListBaseTests<CustomersList, Customer>
    {
        protected override CustomersList getRandomObject()
        {
            createWithNullArgs = new CustomersList(null, null);
            var l = GetRandom.Object<List<CustomersData>>();
            return new CustomersList(l, GetRandom.Object<RepositoryPage>());
        }
    }
}