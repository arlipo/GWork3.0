using System.Collections.Generic;
using Open.Core;
using Open.Data.Quantity;
namespace Open.Domain.Quantity {
    public class RateTypeList : PaginatedList<RateType> {
        public RateTypeList(IEnumerable<RateTypeData> items,
            RepositoryPage page) :
            base(page) {
            if (items is null) return;
            foreach (var dbRecord in items) { Add(new RateType(dbRecord)); }
        }
    }
}