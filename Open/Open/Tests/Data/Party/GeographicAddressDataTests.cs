using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Party;
namespace Open.Tests.Data.Party {
    [TestClass]
    public class GeographicAddressDataTests : ObjectTests<GeographicAddressData> {
        protected override GeographicAddressData getRandomObject() {
            return GetRandom.Object<GeographicAddressData>();
        }

        [TestMethod] public void IsInstanceOfAddressDbRecord() {
            Assert.AreEqual(typeof(AddressData), obj.GetType().BaseType);
        }
        [TestMethod] public void CountryTest() {
            canReadWrite(() => obj.Country, x => obj.Country = x);
        }
        [TestMethod] public void CountryIDTest() {
            canReadWrite(() => obj.CountryID, x => obj.CountryID = x);
        }
    }
}


