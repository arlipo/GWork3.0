using Open.Core;
namespace Open.Data.Party {
    public class TelecomAddressData : AddressData {

        private string prefix;

        public string NationalDirectDialingPrefix {
            get => getString(ref prefix);
            set => prefix = value;
        }

        public TelecomDevice Device { get; set; }
    }
}


