using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Party;
namespace Open.Tests.Data.Party {
    [TestClass] public class WebPageAddressDataTests : ObjectTests<WebPageAddressData> {
        protected override WebPageAddressData getRandomObject() {
            return GetRandom.Object<WebPageAddressData>();
        }

        [TestMethod] public void IsInstanceOfAddressDbRecord() {
            Assert.AreEqual(typeof(AddressData), obj.GetType().BaseType);
        }

    }
}

