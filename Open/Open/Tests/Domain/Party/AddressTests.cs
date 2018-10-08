using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Party;
using Open.Domain.Party;
namespace Open.Tests.Domain.Party {
    [TestClass]
    public class AddressTests : EntityBaseTests<Address<EmailAddressData>,
        EmailAddressData> {
        class testClass : Address<EmailAddressData> {
            public testClass(EmailAddressData r) : base(r) { }
        }
        protected override Address<EmailAddressData> getRandomObject() {
            createdWithNullArg = new testClass(null);
            dbRecordType = typeof(AddressData);
            return GetRandom.Object<testClass>();
        }

        [TestMethod] public void IsIAddressObjectTest() {
            Assert.IsInstanceOfType(obj, typeof(IAddress));
        }
    }
}


