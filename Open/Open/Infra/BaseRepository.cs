using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Open.Core;
using Open.Data.Common;
using Open.Domain.Common;
namespace Open.Infra {
    public abstract class BaseRepository<TObject, TDbRecord> : ICrudRepository<TObject>
        where TObject : Period<TDbRecord>
        where TDbRecord : PeriodData, new() {

        protected internal readonly DbSet<TDbRecord> dbSet;
        protected internal readonly DbContext db;

        protected internal abstract TObject createObject(TDbRecord r);

        protected internal abstract Task<TDbRecord> getObject(string id);
        protected internal abstract Task<TDbRecord> getObjectByCode(string code);
        protected BaseRepository(DbSet<TDbRecord> s, DbContext c) {
            dbSet = s;
            db = c;
        }
        
        public async Task<TObject> GetObject(string id) {
            var r = await getObject(id);
            return createObject(r);
        }
        public async Task<TObject> GetObjectByCode(string code)
        {
            var r = await getObjectByCode(code);
            return createObject(r);
        }
        public async Task AddObject(TObject o) {
            dbSet.Add(o.Data);
            await db.SaveChangesAsync();
        }
        public async Task UpdateObject(TObject o) {
            dbSet.Update(o.Data);
            await db.SaveChangesAsync();
        }
        public async Task DeleteObject(TObject o) {
            dbSet.Remove(o.Data);
            await db.SaveChangesAsync();
        }
        public bool IsInitialized()
        {
            db.Database.EnsureCreated();
            return dbSet.Any();
        }
    }
}


