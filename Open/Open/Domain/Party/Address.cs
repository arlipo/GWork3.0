using Open.Data.Party;
using Open.Domain.Common;
namespace Open.Domain.Party {
    public abstract class Address<T> : Entity<T>, IAddress  where T : AddressData, new() {
        protected Address(T r) : base(r) { }
    }

}

