using System.Threading.Tasks;
using Open.Core;
namespace Open.Domain.Party {

    public interface
        ITelecomDeviceRegistrationsRepository : ICrudRepository<
            TelecomDeviceRegistration> {
        Task LoadAddresses(TelecomAddress device);
        Task LoadDevices(GeographicAddress address);
        Task<TelecomDeviceRegistration> GetObject(string adr, string dev);
    }

}




