using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Facade.Party;
namespace Open.Tests.Facade.Party {
    [TestClass]
    public class GeographicAddressViewTests : ObjectTests<GeographicAddressView> {

        protected override GeographicAddressView getRandomObject() {
            return GetRandom.Object<GeographicAddressView>();
        }

        [TestMethod] public void IsAddressViewModelTest() {
            Assert.AreEqual(obj.GetType().BaseType, typeof(AddressView));
        }

        [TestMethod] public void AddressLineTest() {
            canReadWrite(() => obj.AddressLine, x => obj.AddressLine = x);
        }

        [TestMethod] public void CityTest() {
            canReadWrite(() => obj.City, x => obj.City = x);
        }
        #region other tests ...
        
        [TestMethod] public void CountryTest() {
            canReadWrite(() => obj.Country, x => obj.Country = x);
        }

        [TestMethod] public void RegionOrStateTest() {
            canReadWrite(() => obj.RegionOrState, x => obj.RegionOrState = x);
        }

        [TestMethod] public void ZipOrPostalCodeTest() {
            canReadWrite(() => obj.ZipOrPostalCode, x => obj.ZipOrPostalCode = x);
        }

        [TestMethod] public void RegisteredTelecomAddressesTest() {
            Assert.IsInstanceOfType(obj.RegisteredTelecomAddresses,
                typeof(List<TelecomAddressView>));
            var name =
                GetMember.Name<GeographicAddressView>(x => x.RegisteredTelecomAddresses);
            Assert.IsTrue(IsReadOnly.Property<GeographicAddressView>(name));
        }

        [TestMethod] public void ToStringTest() {
            var s = obj.AddressLine;
            if (obj.City != Constants.Unspecified) s = $"{s} {obj.City}";
            if (obj.RegionOrState != Constants.Unspecified) s = $"{s} {obj.RegionOrState}";
            if (obj.ZipOrPostalCode != Constants.Unspecified) s = $"{s} {obj.ZipOrPostalCode}";
            if (obj.Country != Constants.Unspecified) s = $"{s} {obj.Country}";
            Assert.AreEqual(s, obj.ToString());
        }
        #endregion

    }
}






