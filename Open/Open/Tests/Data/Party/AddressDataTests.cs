using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Common;
using Open.Data.Party;
namespace Open.Tests.Data.Party {
    [TestClass] public class AddressDataTests : ObjectTests<AddressData> {
        class testClass : AddressData { }
        protected override AddressData getRandomObject() {
            return GetRandom.Object<testClass>();
        }
        [TestMethod] public void IsNotAbstract() {
            Assert.IsFalse(typeof(AddressData).IsAbstract);
        }
        [TestMethod] public void IsInstanceOfUniqueDbRecord() {
            Assert.AreEqual(typeof(IdentifiedData), typeof(AddressData).BaseType);
        }
        [TestMethod] public void AddressTest() {
            canReadWrite(() => obj.Address, x => obj.Address = x);
        }
        [TestMethod] public void CityOrAreaCodeTest() {
            canReadWrite(() => obj.CityOrAreaCode, x => obj.CityOrAreaCode = x);
        }
        [TestMethod] public void RegionOrStateOrCountryCodeTest() {
            canReadWrite(() => obj.RegionOrStateOrCountryCode,
                x => obj.RegionOrStateOrCountryCode = x);
        }
        [TestMethod] public void ZipOrPostCodeOrExtensionTest() {
            canReadWrite(() => obj.ZipOrPostCodeOrExtension,
                x => obj.ZipOrPostCodeOrExtension = x);
        }
    }
}


