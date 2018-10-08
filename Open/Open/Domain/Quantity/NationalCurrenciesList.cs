using System.Collections.Generic;
using Open.Core;
using Open.Data.Quantity;
namespace Open.Domain.Quantity {
    public class NationalCurrenciesList : PaginatedList<NationalCurrency> {
        public NationalCurrenciesList(IEnumerable<NationalCurrencyData> items,
            RepositoryPage page) :
            base(page) {
            if (items is null) return;
            foreach (var dbRecord in items) { Add(new NationalCurrency(dbRecord)); }
        }
    }
}

