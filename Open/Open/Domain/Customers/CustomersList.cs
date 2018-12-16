using System.Collections.Generic;
using Open.Core;
using Open.Data.Customers;

namespace Open.Domain.Customers
{
    public class CustomersList : PaginatedList<Customer>
    {
        public CustomersList(IEnumerable<CustomersData> items, RepositoryPage page) : base(page)
        {
            if (items is null) return;
            foreach (var dbRecord in items)
            {
                Add(CustomerFactory.Create(dbRecord));
            }
        }
    }
}
