using Open.Data.Common;
namespace Open.Domain.Common {
    public abstract class NamedEntity<T> : Entity<T>
        where T : NamedData, new() {
        protected NamedEntity(T dbRecord) : base(dbRecord) { }
    }
}



