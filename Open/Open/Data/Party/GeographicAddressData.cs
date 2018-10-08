//TODO look for identifiedData and its tests and implement this foa all data classes
namespace Open.Data.Party {

    public class GeographicAddressData : AddressData {
        private string countryID;

        public string CountryID {
            get => getString(ref countryID);
            set => countryID = value;
        }

        public virtual CountryData Country { get; set; }
    }
}




