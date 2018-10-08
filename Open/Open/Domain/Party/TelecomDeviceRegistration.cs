using Open.Data.Party;
using Open.Domain.Common;
namespace Open.Domain.Party {
    public class
        TelecomDeviceRegistration : Period<TelecomDeviceRegistrationData> {
        public readonly TelecomAddress Device;
        public readonly GeographicAddress Address;
        public TelecomDeviceRegistration(TelecomDeviceRegistrationData dbRecord) :
            base(dbRecord) {
            Data.Address = Data.Address ?? new GeographicAddressData();
            Data.Device = Data.Device ?? new TelecomAddressData();
            Address = AddressFactory.Create(Data.Address) as GeographicAddress;
            Device = AddressFactory.Create(Data.Device) as TelecomAddress;
        }
    }
}



