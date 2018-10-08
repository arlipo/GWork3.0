using System.Collections.Generic;
namespace Open.Core {
    public interface IPaginatedList<T> : IList<T> {
        int PageIndex { get; }
        int TotalPages { get; }
        bool HasPreviousPage { get; }
        bool HasNextPage { get; }
    }
}


