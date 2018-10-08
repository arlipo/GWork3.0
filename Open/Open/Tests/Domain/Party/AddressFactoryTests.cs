using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Party;
using Open.Domain.Party;
namespace Open.Tests.Domain.Party {
    [TestClass] public class AddressFactoryTests : BaseTests {
        private const string u = Constants.Unspecified;
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(AddressFactory);
        }

        [TestMethod] public void CreateEmailTest() {
            var r = GetRandom.Object<EmailAddressData>();
            var o = AddressFactory.CreateEmail(r.ID, r.Address, r.ValidFrom, r.ValidTo);
            Assert.IsInstanceOfType(o, typeof(EmailAddress));
            testVariables(o.Data, r.ID, r.Address, r.ValidFrom, r.ValidTo);
        }
        private void testVariables(AddressData o, string id, string adr, DateTime vFrom,
            DateTime vTo, string city = u, string region = u, string zip = u) {
            Assert.AreEqual(id, o.ID);
            Assert.AreEqual(adr, o.Address);
            Assert.AreEqual(vFrom, o.ValidFrom);
            Assert.AreEqual(vTo, o.ValidTo);
            Assert.AreEqual(city, o.CityOrAreaCode);
            Assert.AreEqual(region, o.RegionOrStateOrCountryCode);
            Assert.AreEqual(zip, o.ZipOrPostCodeOrExtension);
        }
        [TestMethod] public void CreateWebTest() {
            var r = GetRandom.Object<WebPageAddressData>();
            var o = AddressFactory.CreateWeb(
                r.ID,
                r.Address,
                r.ValidFrom,
                r.ValidTo);
            Assert.IsInstanceOfType(o, typeof(WebPageAddress));
            testVariables(o.Data, r.ID, r.Address, r.ValidFrom, r.ValidTo);
        }
        [TestMethod] public void CreateDeviceTest() {
            var r = GetRandom.Object<TelecomAddressData>();
            var o = AddressFactory.CreateDevice(
                r.ID,
                r.RegionOrStateOrCountryCode,
                r.CityOrAreaCode,
                r.Address,
                r.ZipOrPostCodeOrExtension,
                r.NationalDirectDialingPrefix,
                r.Device,
                r.ValidFrom,
                r.ValidTo);
            Assert.IsInstanceOfType(o, typeof(TelecomAddress));
            testVariables(o.Data, r.ID, r.Address, r.ValidFrom, r.ValidTo, r.CityOrAreaCode,
                r.RegionOrStateOrCountryCode, o.Data.ZipOrPostCodeOrExtension);
            Assert.AreEqual(r.NationalDirectDialingPrefix, o.Data.NationalDirectDialingPrefix);
            Assert.AreEqual(r.Device, o.Data.Device);
        }
        [TestMethod] public void CreateAddressTest() {
            var r = GetRandom.Object<GeographicAddressData>();
            var o = AddressFactory.CreateAddress(
                r.ID, 
                r.Address, 
                r.CityOrAreaCode, 
                r.RegionOrStateOrCountryCode, 
                r.ZipOrPostCodeOrExtension, 
                r.CountryID,
                r.ValidFrom, 
                r.ValidTo);
            Assert.IsInstanceOfType(o, typeof(GeographicAddress));
            testVariables(o.Data, r.ID, r.Address, r.ValidFrom, r.ValidTo, r.CityOrAreaCode,
                r.RegionOrStateOrCountryCode, o.Data.ZipOrPostCodeOrExtension);
            Assert.AreEqual(r.CountryID, o.Data.CountryID);
        }
        [TestMethod] public void CreateTest() {
            void test<T>(AddressData r) {
                var o = AddressFactory.Create(r);
                Assert.IsInstanceOfType(o, typeof(T));
            }
            test<WebPageAddress>(GetRandom.Object<WebPageAddressData>());
            test<EmailAddress>(GetRandom.Object<EmailAddressData>());
            test<TelecomAddress>(GetRandom.Object<TelecomAddressData>());
            test<GeographicAddress>(GetRandom.Object<GeographicAddressData>());
            test<GeographicAddress>(GetRandom.Object<AddressData>());
            test<GeographicAddress>(null);
        }
    }
}
