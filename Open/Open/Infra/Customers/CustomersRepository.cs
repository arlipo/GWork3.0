using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Open.Core;
using Open.Data.Customers;
using Open.Domain.Customers;

namespace Open.Infra.Customers
{
    public class CustomersRepository : Repository<Customer, CustomersData>,
        ICustomersRepository
    {
        protected internal override async Task<CustomersData> getObject(string id)
        {
            return await dbSet.AsNoTracking().SingleOrDefaultAsync(x => x.ID == id);
        }

        public CustomersRepository(SentryDbContext c) : base(c?.Customers, c) { }
        protected internal override Customer createObject(CustomersData r)
        {
            return new Customer(r);
        }
        protected internal override PaginatedList<Customer> createList(
            List<CustomersData> l, RepositoryPage p)
        {
            return new CustomersList(l, p);
        }
    }
}
