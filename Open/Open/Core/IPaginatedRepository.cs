using System;
using System.Threading.Tasks;
namespace Open.Core {
    public interface IPaginatedRepository<TObject, TRecord> : ICrudRepository<TObject> {
        string SearchString { get; set; }
        int? PageIndex { get; set; }
        int? PageSize { get; set; }
        SortOrder SortOrder { get; set; }
        Func<TRecord, object> SortFunction { get; set; }
        Task<PaginatedList<TObject>> GetObjectsList();
    }
}
