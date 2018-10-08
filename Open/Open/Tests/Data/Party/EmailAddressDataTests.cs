using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Party;
namespace Open.Tests.Data.Party {
    [TestClass] public class EmailAddressDataTests : ObjectTests<EmailAddressData> {
        protected override EmailAddressData getRandomObject() {
            return GetRandom.Object<EmailAddressData>();
        }

        [TestMethod] public void IsInstanceOfAddressDbRecord() {
            Assert.AreEqual(typeof(AddressData), typeof(EmailAddressData).BaseType);
        }

    }
}
