using System;
using System.Collections.Generic;
using Open.Core;
using Open.Data.Customers;

namespace Open.Domain.Customers
{
   public class CustomersList : PaginatedList<Customer>
    {
        public CustomersList(IEnumerable<CustomersData> customers, RepositoryPage page) : base(page)
        {
            if (customers is null) return;
            foreach (var dbRecord in customers)
            {
                Add(CustomerFactory.Create(dbRecord));
            }
        }
    }
}
