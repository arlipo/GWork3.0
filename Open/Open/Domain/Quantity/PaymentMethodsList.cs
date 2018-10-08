using System.Collections.Generic;
using Open.Core;
using Open.Data.Quantity;
namespace Open.Domain.Quantity {
    public class PaymentMethodsList : PaginatedList<IPaymentMethod> {
        public PaymentMethodsList(IEnumerable<PaymentMethodData> items, RepositoryPage page) : base(page) {
            if (items is null) return;
            foreach (var paymentMethodDbRecord in items) {
                Add(PaymentMethodFactory.Create(paymentMethodDbRecord));
            }
        }
    }
}