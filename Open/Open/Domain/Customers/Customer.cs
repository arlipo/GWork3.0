using Open.Data.Customers;
using Open.Domain.Common;

namespace Open.Domain.Customers {
    public class Customer : NamedEntity<CustomersData> {
        public Customer(CustomersData r) : base(r) { }
    }
}
