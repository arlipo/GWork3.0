using System;
using Open.Data.Party;
namespace Open.Domain.Party {
    public static class TelecomDeviceRegistrationFactory {
        public static TelecomDeviceRegistration Create(GeographicAddress address,
            TelecomAddress device,
            DateTime? validFrom = null, DateTime? validTo = null) {
            var o = new TelecomDeviceRegistrationData {
                Address = address?.Data?? new GeographicAddressData(),
                Device = device?.Data?? new TelecomAddressData(),
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue
            };
            o.AddressID = o.Address?.ID;
            o.DeviceID = o.Device?.ID;
            return new TelecomDeviceRegistration(o);
        }
    }
}



