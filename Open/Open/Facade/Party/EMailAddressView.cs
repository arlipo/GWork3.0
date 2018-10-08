using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Open.Facade.Party {

    public class EMailAddressView : AddressView {

        private string emailAddress;

        [Required]
        [DisplayName("Email")]
        [RegularExpression(@"(?!.*\.\.)(^[^\.][^@\s]+@[^@\s]+\.[^@\s\.]+$)")]
        public string EmailAddress {
            get => getString(ref emailAddress);
            set => emailAddress = value;
        }
        public override string ToString() {
            return EmailAddress;
        }
    }
}



