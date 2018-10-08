
using Open.Data.Party;
namespace Open.Domain.Party {
    public sealed class EmailAddress : Address<EmailAddressData> {
        public EmailAddress(EmailAddressData r) : base(r?? new EmailAddressData()) { }
    }
}


