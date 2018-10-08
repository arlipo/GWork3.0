using System.Collections.Generic;
using Open.Core;
using Open.Data.Quantity;
namespace Open.Domain.Quantity {
    public class CurrenciesList : PaginatedList<Currency> {
        public CurrenciesList(IEnumerable<CurrencyData> items, RepositoryPage page) :
            base(page) {
            if (items is null) return;
            foreach (var dbRecord in items) { Add(new Currency(dbRecord)); }
        }
    }
}

