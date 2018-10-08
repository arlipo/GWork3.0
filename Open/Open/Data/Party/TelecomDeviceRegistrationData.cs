using Open.Data.Common;
namespace Open.Data.Party {
    public class TelecomDeviceRegistrationData : PeriodData {
        private string addressID;
        private string deviceID;
        public string AddressID {
            get => getString(ref addressID);
            set => addressID = value;
        }
        public string DeviceID {
            get => getString(ref deviceID);
            set => deviceID = value;
        }
        public virtual GeographicAddressData Address { get; set; }
        public virtual TelecomAddressData Device { get; set; }
    }
}
