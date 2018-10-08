using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Open.Core;
using Open.Data.Quantity;
using Open.Domain.Quantity;
namespace Open.Infra.Quantity {
    public class RateTypesRepository : Repository<RateType, RateTypeData>, IRateTypeRepository {
        public RateTypesRepository(SentryDbContext c) : base(c?.RateTypes, c) { }
        protected internal override RateType createObject(RateTypeData r)
        {
            return new RateType(r);
        }
        protected internal override PaginatedList<RateType> createList(
            List<RateTypeData> l, RepositoryPage p)
        {
            return new RateTypeList(l, p);
        }
        protected internal override async Task<RateTypeData> getObject(string id)
        {
            return await dbSet.AsNoTracking().SingleOrDefaultAsync(x => x.ID == id);
        }

    }
}