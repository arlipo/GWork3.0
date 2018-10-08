using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Party;
using Open.Domain.Party;
namespace Open.Tests.Domain.Party {

    [TestClass]
    public class WebPageAddressTests : EntityBaseTests<WebPageAddress, WebPageAddressData> {
        protected override WebPageAddress getRandomObject() {
            createdWithNullArg = new WebPageAddress(null);
            dbRecordType = typeof(WebPageAddressData);
            return GetRandom.Object<WebPageAddress>();
        }
    }
}


