using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Open.Core;
namespace Open.Tests
{
    public abstract class MockRepository<TObject, TData>: IRepository<TObject, TData>
    {
        protected List<TObject> objects { get; } = new List<TObject>();
        public string SearchString { get; set; }

        public int? PageIndex { get; set; }

        public int? PageSize { get; set; }

        public SortOrder SortOrder { get; set; }

        public Func<TData, object> SortFunction { get; set; }

        public Task<PaginatedList<TObject>> GetObjectsList() { throw new NotImplementedException(); }

        public async Task<TObject> GetObject(string id) {
            return await Task.Run(()=> objects.Find(x => getObject(x, id)));
        }
        public async Task<TObject> GetObjectByCode(string code)
        {
            return await Task.Run(() => objects.Find(x => getObjectByCode(x, code)));
        }

        protected abstract bool getObject(TObject obj, string id);
        protected abstract bool getObjectByCode(TObject obj, string code);

        public async Task AddObject(TObject o) {
            await Task.Run(() =>objects.Add(o));
        }

        public Task UpdateObject(TObject o) { throw new NotImplementedException(); }

        public Task DeleteObject(TObject o) { throw new NotImplementedException(); }

        public bool IsInitialized() { throw new NotImplementedException(); }
    }
}
