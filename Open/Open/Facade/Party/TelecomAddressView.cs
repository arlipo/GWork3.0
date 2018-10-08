using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Open.Core;
namespace Open.Facade.Party {
    public class TelecomAddressView : AddressView {

        private string countryCode;
        private string areaCode;
        private string number;
        private string extension;
        private string nationalDirectDialingPrefix;

        [DisplayName("Country Code"), RegularExpression(@"^\d+$")]
        public string CountryCode {
            get => getString(ref countryCode);
            set => countryCode = value;
        }

        [DisplayName("Area Code"), RegularExpression(@"^\d+$")]
        public string AreaCode {
            get => getString(ref areaCode);
            set => areaCode = value;
        }

        [Required, RegularExpression(@"^\d+$")]
        public string Number {
            get => getString(ref number);
            set => number = value;
        }
        [RegularExpression(@"^\d+$")]
        public string Extension {
            get => getString(ref extension);
            set => extension = value;
        }

        [DisplayName("National Direct Dialing Prefix"), RegularExpression(@"^\d+$")]
        public string NationalDirectDialingPrefix {
            get => getString(ref nationalDirectDialingPrefix);
            set => nationalDirectDialingPrefix = value;
        }

        [DisplayName("Device Type")]
        public TelecomDevice DeviceType { get; set; }

        [DisplayName("Registered In")]
        public List<GeographicAddressView> RegisteredInAddresses { get; } =
            new List<GeographicAddressView>();
        public override string ToString() {
            var s = Number;
            if (AreaCode != Constants.Unspecified) s = $"{AreaCode} {s}";
            if (NationalDirectDialingPrefix != Constants.Unspecified)
                s = $"({NationalDirectDialingPrefix}){s}";
            if (CountryCode != Constants.Unspecified) s = $"{CountryCode} {s}";
            if (Extension != Constants.Unspecified) s = $"{s} ext. {Extension}";
            return s;
        }
    }
}

