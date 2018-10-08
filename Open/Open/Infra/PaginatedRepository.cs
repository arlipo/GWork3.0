using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Open.Core;
using Open.Data.Common;
using Open.Domain.Common;
namespace Open.Infra {
    public abstract class PaginatedRepository<TObject, TDbRecord> : BaseRepository<TObject, TDbRecord>,
        IPaginatedRepository<TObject, TDbRecord>
        where TObject : Entity<TDbRecord>
        where TDbRecord : IdentifiedData, new() {

        protected internal abstract PaginatedList<TObject> createList(List<TDbRecord> items,
            RepositoryPage p);

        protected PaginatedRepository(DbSet<TDbRecord> s, DbContext c) : base(s, c) { }

        public string SearchString { get; set; }
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
        public SortOrder SortOrder { get; set; }
        public Func<TDbRecord, object> SortFunction { get; set; }

        public async Task<PaginatedList<TObject>> GetObjectsList() {
            var countries = getSorted().Where(s => s.Contains(SearchString)).AsNoTracking();
            var count = await countries.CountAsync();
            var p = new RepositoryPage(count, PageIndex, PageSize);
            var items = await countries.Skip(p.FirstItemIndex).Take(p.PageSize).ToListAsync();
            return createList(items, p);
        }
        private IQueryable<TDbRecord> getSet() {
            return from s in dbSet select s;
        }
        private IQueryable<TDbRecord> getSorted() {
            if (SortFunction is null) return getSet();
            return SortOrder == SortOrder.Descending
                ? getSet().OrderByDescending(x => SortFunction(x))
                : getSet().OrderBy(x => SortFunction(x));
        }
    }
}




