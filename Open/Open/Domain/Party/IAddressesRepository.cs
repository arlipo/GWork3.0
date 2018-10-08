using System.Threading.Tasks;
using Open.Core;
using Open.Data.Party;
namespace Open.Domain.Party {
    public interface IAddressesRepository : IRepository<IAddress, AddressData> {
        Task<IPaginatedList<IAddress>> GetDevicesList();
    }
}



