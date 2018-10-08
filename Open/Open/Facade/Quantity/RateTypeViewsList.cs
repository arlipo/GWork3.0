using Open.Core;
using Open.Domain.Quantity;
namespace Open.Facade.Quantity {
    public class RateTypeViewsList : PaginatedList<RateTypeView> {
        public RateTypeViewsList(IPaginatedList<RateType> list) {
            if (list is null) return;
            PageIndex = list.PageIndex;
            TotalPages = list.TotalPages;
            foreach (var e in list) { Add(RateTypeViewFactory.Create(e)); }
        }
    }
}