using System.Collections.Generic;
using Open.Core;
using Open.Data.Goods;

namespace Open.Domain.Goods
{
    public class GoodsList : PaginatedList<Good>
    {
        public GoodsList(IEnumerable<GoodsData> items, RepositoryPage page) : base(page)
        {
            if (items is null) return;
            foreach (var dbRecord in items)
            {
                Add(GoodFactory.Create(dbRecord));
            }
        }
    }
}