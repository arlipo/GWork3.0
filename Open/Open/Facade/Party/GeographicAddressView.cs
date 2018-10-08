using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Open.Core;
namespace Open.Facade.Party {
    public class GeographicAddressView : AddressView {

        private string addressLine;
        private string city;
        private string regionOrState;
        private string zipOrPostalCode;
        private string country;

        [DisplayName("Address Line"), Required]
        public string AddressLine {
            get => getString(ref addressLine);
            set => addressLine = value;
        }

        public string City {
            get => getString(ref city);
            set => city = value;
        }

        [DisplayName("Region or State")]
        public string RegionOrState {
            get => getString(ref regionOrState);
            set => regionOrState = value;
        }

        [DisplayName("Zip or Postal Code")]
        public string ZipOrPostalCode {
            get => getString(ref zipOrPostalCode);
            set => zipOrPostalCode = value;
        }

        public string Country {
            get => getString(ref country);
            set => country = value;
        }

        [DisplayName("Registered Telecom Devices")]
        public List<TelecomAddressView> RegisteredTelecomAddresses { get; } =
            new List<TelecomAddressView>();

        public override string ToString() {
            var s = AddressLine;
            if (City != Constants.Unspecified) s = $"{s} {City}";
            if (RegionOrState != Constants.Unspecified) s = $"{s} {RegionOrState}";
            if (ZipOrPostalCode != Constants.Unspecified) s = $"{s} {ZipOrPostalCode}";
            if (Country != Constants.Unspecified) s = $"{s} {Country}";
            return s;
        }
    }
}


