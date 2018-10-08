using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Open.Core;
using Open.Data.Quantity;
using Open.Domain.Quantity;
namespace Open.Infra.Quantity {
    public class PaymentMethodsRepository : IPaymentMethodsRepository {
        private readonly DbSet<PaymentMethodData> dbSet;
        private readonly DbContext db;
        public PaymentMethodsRepository(SentryDbContext c) {
            db = c;
            dbSet = c?.PaymentMethods;
        }
        public string SearchString { get; set; }
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
        public SortOrder SortOrder { get; set; }
        public Func<PaymentMethodData, object> SortFunction { get; set; }
        public async Task<PaginatedList<IPaymentMethod>> GetObjectsList() {
            var countries = getSorted().Where(s => s.Contains(SearchString)).AsNoTracking();
            var count = await countries.CountAsync();
            var p = new RepositoryPage(count, PageIndex, PageSize);
            var items = await countries.Skip(p.FirstItemIndex).Take(p.PageSize).ToListAsync();
            return createList(items, p);
        }
        protected internal PaginatedList<IPaymentMethod> createList(List<PaymentMethodData> l, RepositoryPage p) {
            return new PaymentMethodsList(l, p);
        }
        private IQueryable<PaymentMethodData> getSet() {
            return from s in dbSet select s;
        }
        private IQueryable<PaymentMethodData> getSorted() {
            if (SortFunction is null) return getSet();
            return SortOrder == SortOrder.Descending
                ? getSet().OrderByDescending(x => SortFunction(x))
                : getSet().OrderBy(x => SortFunction(x));
        }
        protected internal async Task<PaymentMethodData> getObject(string id) {
            return await dbSet.AsNoTracking().SingleOrDefaultAsync(x => x.ID == id);
        }
        public async Task<IPaymentMethod> GetObject(string id) {
            var r = await getObject(id);
            return PaymentMethodFactory.Create(r);
        }
        public async Task AddObject(IPaymentMethod m) {
            if (m is Check check) dbSet.Add(check.Data);
            if (m is DebitCard debitCard) dbSet.Add(debitCard.Data);
            if (m is CreditCard creditCard) dbSet.Add(creditCard.Data);
            await db.SaveChangesAsync();
        }
        public async Task UpdateObject(IPaymentMethod m) {
            if (m is Check check) dbSet.Update(check.Data);
            if (m is DebitCard debitCard) dbSet.Update(debitCard.Data);
            if (m is CreditCard creditCard) dbSet.Update(creditCard.Data);
            await db.SaveChangesAsync();
        }
        public async Task DeleteObject(IPaymentMethod m) {
            if (m is Check check) dbSet.Remove(check.Data);
            if (m is DebitCard debitCard) dbSet.Remove(debitCard.Data);
            if (m is CreditCard creditCard) dbSet.Remove(creditCard.Data);
            await db.SaveChangesAsync();
        }
        public bool IsInitialized() {
            db.Database.EnsureCreated();
            return dbSet.Any();
        }
    }
}