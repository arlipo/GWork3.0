using System.Collections.Generic;
using Open.Core;
using Open.Data.Party;
namespace Open.Domain.Party {

    public sealed class GeographicAddress : Address<GeographicAddressData> {
        public readonly Country Country;
        private readonly List<TelecomAddress> registeredDevices;
        public GeographicAddress(GeographicAddressData r) : base(
            r ?? new GeographicAddressData()) {
            Country = new Country(Data.Country);
            registeredDevices = new List<TelecomAddress>();
        }
        public IReadOnlyList<TelecomAddress> RegisteredTelecomDevices =>
            registeredDevices.AsReadOnly();

        public void RegisteredTelecomDevice(TelecomAddress adr) {
            if (adr is null) return;
            if (adr.Data.ID == Constants.Unspecified) return;
            if (registeredDevices.Find(
                    x => x.Data.ID == adr.Data.ID) != null)
                return;
            registeredDevices.Add(adr);
        }
    }
}


