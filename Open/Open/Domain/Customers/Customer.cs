using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Open.Data.Customers;
using Open.Domain.Common;

namespace Open.Domain.Customers
{
    public class Customer : NamedEntity<CustomersData>
    {
        public Customer(CustomersData r) : base(r) { }
    }
}
