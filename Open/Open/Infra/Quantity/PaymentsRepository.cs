using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Open.Core;
using Open.Data.Quantity;
using Open.Domain.Quantity;
namespace Open.Infra.Quantity {
    public class PaymentsRepository : Repository<Payment, PaymentData>, IPaymentsRepository {
        public PaymentsRepository(SentryDbContext c) : base(c?.Payments, c) { }

        protected internal override Payment createObject(PaymentData r) { return new Payment(r); }

        protected internal override PaginatedList<Payment> createList(List<PaymentData> l,
            RepositoryPage p) {
            return new PaymentsList(l, p);
        }

        protected internal override async Task<PaymentData> getObject(string id) {
            return await dbSet.AsNoTracking()
                .SingleOrDefaultAsync(x => x.ID == id);
        }
    }
}