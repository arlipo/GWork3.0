using Open.Core;
using Open.Data.Customers;

namespace Open.Domain.Customers
{
    public interface ICustomersRepository : IRepository<Customer, CustomersData>
    {

    }
}
