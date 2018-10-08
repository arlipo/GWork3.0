using Open.Core;
using Open.Domain.Quantity;
namespace Open.Facade.Quantity {
    public class RateViewsList : PaginatedList<RateView> {
        public RateViewsList(IPaginatedList<Rate> list) {
            if (list is null) return;
            PageIndex = list.PageIndex;
            TotalPages = list.TotalPages;
            foreach (var e in list) { Add(RateViewFactory.Create(e)); }
        }
    }
}