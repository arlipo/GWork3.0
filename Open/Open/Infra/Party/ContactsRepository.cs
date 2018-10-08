using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Open.Core;
using Open.Data.Party;
using Open.Domain.Party;
namespace Open.Infra.Party {
    public class ContactsRepository : IAddressesRepository {
        private readonly DbSet<AddressData> dbSet;
        private readonly DbContext db;
        public ContactsRepository(SentryDbContext c) {
            db = c;
            dbSet = c?.Addresses;
        }
        public string SearchString { get; set; }
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
        public SortOrder SortOrder { get; set; }
        public Func<AddressData, object> SortFunction { get; set; }
        public async Task<PaginatedList<IAddress>> GetObjectsList() {
            var countries = getSorted().Where(s => s.Contains(SearchString)).AsNoTracking();
            var count = await countries.CountAsync();
            var p = new RepositoryPage(count, PageIndex, PageSize);
            var items = await countries.Skip(p.FirstItemIndex).Take(p.PageSize).ToListAsync();
            return createList(items, p);
        }
        protected internal PaginatedList<IAddress> createList(
            List<AddressData> l, RepositoryPage p) {
            return new AddressesList(l, p);
        }
        private IQueryable<AddressData> getSet() {
            return from s in dbSet select s;
        }
        private IQueryable<AddressData> getSorted() {
            if (SortFunction is null) return getSet();
            return SortOrder == SortOrder.Descending
                ? getSet().OrderByDescending(x => SortFunction(x))
                : getSet().OrderBy(x => SortFunction(x));
        }
        protected internal async Task<AddressData> getObject(string id)
        {
            return await dbSet.AsNoTracking().SingleOrDefaultAsync(x => x.ID == id);
        }
        public async Task<IAddress> GetObject(string id) {
            var r = await getObject(id);
            return AddressFactory.Create(r);
        }
        public async Task AddObject(IAddress o) {
            if (o is WebPageAddress web) dbSet.Add(web.Data);
            if (o is EmailAddress email) dbSet.Add(email.Data);
            if (o is GeographicAddress adr) dbSet.Add(adr.Data);
            if (o is TelecomAddress tel) dbSet.Add(tel.Data);
            await db.SaveChangesAsync();
        }
        public async Task UpdateObject(IAddress o) {
            if (o is WebPageAddress web) dbSet.Update(web.Data);
            if (o is EmailAddress email) dbSet.Update(email.Data);
            if (o is GeographicAddress adr) dbSet.Update(adr.Data);
            if (o is TelecomAddress tel) dbSet.Update(tel.Data);
            await db.SaveChangesAsync();
        }
        public async Task DeleteObject(IAddress o) {
            if (o is WebPageAddress web) dbSet.Remove(web.Data);
            if (o is EmailAddress email) dbSet.Remove(email.Data);
            if (o is GeographicAddress adr) dbSet.Remove(adr.Data);
            if (o is TelecomAddress tel) dbSet.Remove(tel.Data);
            await db.SaveChangesAsync();
        }
        public bool IsInitialized() {
            db.Database.EnsureCreated();
            return dbSet.Any();
        }
        public async Task<IPaginatedList<IAddress>> GetDevicesList() {
            var countries = getSorted().Where(s => s is TelecomAddressData && s.Contains(SearchString)).AsNoTracking();
            var count = await countries.CountAsync();
            var p = new RepositoryPage(count, PageIndex, PageSize);
            var items = await countries.Skip(p.FirstItemIndex).Take(p.PageSize).ToListAsync();
            return createList(items, p);
        }
    }
}


