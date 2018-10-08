using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Open.Core;
using Open.Data.Quantity;
using Open.Domain.Quantity;
namespace Open.Infra.Quantity {
    public class CurrenciesRepository : Repository<Currency, CurrencyData>,
        ICurrencyRepository {

        protected internal override async Task<CurrencyData> getObject(string id)
        {
            return await dbSet.AsNoTracking().SingleOrDefaultAsync(x => x.ID == id);
        }

        public CurrenciesRepository(SentryDbContext c) : base(c?.Currencies, c) { }
        protected internal override Currency createObject(CurrencyData r) {
            return new Currency(r);
        }
        protected internal override PaginatedList<Currency> createList(
            List<CurrencyData> l, RepositoryPage p) {
            return new CurrenciesList(l, p);
        }
    }
}

