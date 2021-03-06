﻿using Open.Core;
using Open.Domain.Customers;

namespace Open.Facade.Customers
{
    public class CustomerViewsList : PaginatedList<CustomerView>
    {
        public CustomerViewsList(IPaginatedList<Customer> list)
        {
            if (list is null) return;
            PageIndex = list.PageIndex;
            TotalPages = list.TotalPages;
            foreach (var e in list) { Add(CustomerViewFactory.Create(e)); }
        }
    }
}
