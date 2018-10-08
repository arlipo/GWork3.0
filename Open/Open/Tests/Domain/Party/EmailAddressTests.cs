using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Party;
using Open.Domain.Party;
namespace Open.Tests.Domain.Party {
    [TestClass]
    public class
        EmailAddressTests : EntityBaseTests<EmailAddress, EmailAddressData> {
        protected override EmailAddress getRandomObject() {
            createdWithNullArg = new EmailAddress(null);
            dbRecordType = typeof(EmailAddressData);
            return GetRandom.Object<EmailAddress>();
        }
    }
}


