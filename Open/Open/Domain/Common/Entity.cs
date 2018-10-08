using Open.Data.Common;
namespace Open.Domain.Common {
    public abstract class Entity<T> : Period<T> where T : IdentifiedData, new() {
        protected Entity(T data) : base(data) { }
    }

}

