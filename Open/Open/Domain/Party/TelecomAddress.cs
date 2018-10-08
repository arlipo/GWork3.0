using System.Collections.Generic;
using Open.Core;
using Open.Data.Party;
namespace Open.Domain.Party {
    public sealed class TelecomAddress : Address<TelecomAddressData> {
        private readonly List<GeographicAddress> registeredInAddresses;

        public TelecomAddress(TelecomAddressData r) : base(
            r ?? new TelecomAddressData()) {
            registeredInAddresses = new List<GeographicAddress>();
        }
        public IReadOnlyList<GeographicAddress> RegisteredInAddresses =>
            registeredInAddresses.AsReadOnly();

        public void RegisteredInAddress(GeographicAddress geographicAddress) {
            if (geographicAddress is null) return;
            if (geographicAddress.Data.ID == Constants.Unspecified) return;
            if (registeredInAddresses.Find(x => x.Data.ID == geographicAddress.Data.ID) != null)
                return;
            registeredInAddresses.Add(geographicAddress);
        }
    }
}
