using Open.Core;
using Open.Domain.Goods;

namespace Open.Facade.Goods
{
    public class GoodViewsList : PaginatedList<GoodView>
    {
        public GoodViewsList(IPaginatedList<Good> list)
        {
            if (list is null) return;
            PageIndex = list.PageIndex;
            TotalPages = list.TotalPages;
            foreach (var e in list) { Add(GoodViewFactory.Create(e)); }
        }
    }
}