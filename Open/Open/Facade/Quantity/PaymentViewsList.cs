using Open.Core;
using Open.Domain.Quantity;
namespace Open.Facade.Quantity {
    public class PaymentViewsList : PaginatedList<PaymentView> {
        public PaymentViewsList(IPaginatedList<Payment> list) {
            if (list is null) return;
            PageIndex = list.PageIndex;
            TotalPages = list.TotalPages;
            foreach (var e in list) { Add(PaymentViewFactory.Create(e)); }
        }
    }
}