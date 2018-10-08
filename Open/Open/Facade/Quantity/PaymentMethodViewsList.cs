using Open.Core;
using Open.Domain.Quantity;
namespace Open.Facade.Quantity {
    public class PaymentMethodViewsList : PaginatedList<PaymentMethodView> {
        public PaymentMethodViewsList(IPaginatedList<IPaymentMethod> list) {
            if (list is null) return;
            PageIndex = list.PageIndex;
            TotalPages = list.TotalPages;
            foreach (var e in list) { Add(PaymentMethodViewFactory.Create(e)); }
        }
    }
}