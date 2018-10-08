using System.Collections.Generic;
using Open.Core;
using Open.Data.Quantity;
namespace Open.Domain.Quantity {
    public class PaymentsList: PaginatedList<Payment> {
        public PaymentsList(IEnumerable<PaymentData> items, RepositoryPage page) : base(page) {
            if (items is null) return;
            foreach (var dbRecord in items) { Add(new Payment(dbRecord)); }
        }
    }
}