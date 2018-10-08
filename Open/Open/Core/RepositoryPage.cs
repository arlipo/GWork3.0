
using System;
namespace Open.Core {
    public class RepositoryPage {
        public const int DefaultSize = 10;
        public RepositoryPage(int itemsCount, int? pageIndex = null, int? pageSize = null) {
            if (itemsCount == 0) pageIndex = 0;
            else if (itemsCount <= pageSize) pageIndex = 1;
            PageIndex = pageIndex ?? 1;
            PageSize = pageSize ?? DefaultSize;
            TotalPages = (int)Math.Ceiling(itemsCount / (double)PageSize);
            FirstItemIndex = (PageIndex - 1) * PageSize;
        }
        public int PageIndex { get; }
        public int PageSize { get; }
        public int TotalPages { get; }
        public int FirstItemIndex { get; }

    }
}


