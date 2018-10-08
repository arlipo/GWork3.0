using Open.Core;
using Open.Domain.Quantity;
namespace Open.Facade.Quantity {
    public class CurrencyViewsList : PaginatedList<CurrencyView> {
        public CurrencyViewsList(IPaginatedList<Currency> list) {
            if (list is null) return;
            PageIndex = list.PageIndex;
            TotalPages = list.TotalPages;
            foreach (var e in list) { Add(CurrencyViewFactory.Create(e)); }
        }
    }
}



