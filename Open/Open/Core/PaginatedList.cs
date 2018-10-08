using System.Collections.Generic;
namespace Open.Core {
    public abstract class PaginatedList<T> : List<T>, IPaginatedList<T> {
        public int PageIndex { get; protected set; }
        public int TotalPages { get; protected set; }
        protected PaginatedList(RepositoryPage page = null) {
            page = page ?? new RepositoryPage(0);
            PageIndex = page.PageIndex;
            TotalPages = page.TotalPages;
        }
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;
    }
}


