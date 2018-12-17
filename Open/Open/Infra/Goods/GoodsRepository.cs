using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Open.Core;
using Open.Data.Goods;
using Open.Domain.Goods;

namespace Open.Infra.Goods {
    public class GoodsRepository : Repository<Good, GoodsData>,
        IGoodsRepository {
        public GoodsRepository(SentryDbContext c) : base(c?.Goods, c) { }
        protected internal override async Task<GoodsData> getObject(string id) {
            return await dbSet.AsNoTracking().SingleOrDefaultAsync(x => x.ID == id);
        }
        protected internal override async Task<GoodsData> getObjectByCode(string code) {
            return await dbSet.AsNoTracking().SingleOrDefaultAsync(x => x.Code == code);
        }
        protected internal override Good createObject(GoodsData r) {
            return new Good(r);
        }
        protected internal override PaginatedList<Good> createList(
            List<GoodsData> l, RepositoryPage p) {
            return new GoodsList(l, p);
        }
        public async Task<PaginatedList<Good>> GetWithSpecificType(GoodTypes type) {
            var countries = getSorted().Where(s => s.Contains(SearchString)).AsNoTracking();
            var count = await countries.CountAsync();
            var p = new RepositoryPage(count, PageIndex, PageSize);
            var items = await countries.Skip(p.FirstItemIndex).Take(p.PageSize).ToListAsync();
            var newList = items.Where(x => x.Type == type).ToList();
            return createList(newList, p);
        }
    }
}