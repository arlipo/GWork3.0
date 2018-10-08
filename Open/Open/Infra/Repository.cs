using Microsoft.EntityFrameworkCore;
using Open.Core;
using Open.Data.Common;
using Open.Domain.Common;
namespace Open.Infra {

    public abstract class
        Repository<TObject, TRecord> 
          : PaginatedRepository<TObject, TRecord>, IRepository<TObject, TRecord>
        where TObject : Entity<TRecord>
        where TRecord : IdentifiedData, new() {
        protected Repository(DbSet<TRecord> s, DbContext c) : base(s, c) { }

    }
}
