using System.Collections.Generic;
using Open.Core;
using Open.Data.Quantity;
namespace Open.Domain.Quantity {
    public class RatesList : PaginatedList<Rate> {
        public RatesList(IEnumerable<RateData> items,
            RepositoryPage page) :
            base(page) {
            if (items is null) return;
            foreach (var dbRecord in items) { Add(new Rate(dbRecord)); }
        }
    }
}