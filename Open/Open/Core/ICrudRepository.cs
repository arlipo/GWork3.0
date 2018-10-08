﻿using System.Threading.Tasks;
namespace Open.Core {
    public interface ICrudRepository<TObject> {
        Task<TObject> GetObject(string id);
        Task AddObject(TObject o);
        Task UpdateObject(TObject o);
        Task DeleteObject(TObject o);
        bool IsInitialized();
    }
}


