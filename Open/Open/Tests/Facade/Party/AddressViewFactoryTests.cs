using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Common;
using Open.Data.Party;
using Open.Domain.Party;
using Open.Facade.Common;
using Open.Facade.Party;
namespace Open.Tests.Facade.Party {
    [TestClass] public class AddressViewFactoryTests : BaseTests {
        private const string u = Constants.Unspecified;
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(AddressViewFactory);
        }
        [TestMethod] public void CreateTest() {
            var v = AddressViewFactory.Create((GeographicAddress)null) as GeographicAddressView;
            Assert.IsNotNull(v);
            Assert.AreEqual(v.ID, u);
            Assert.AreEqual(v.ValidFrom, null);
            Assert.AreEqual(v.ValidTo, null);
            Assert.AreEqual(v.AddressLine, u);
            Assert.AreEqual(v.City, u);
            Assert.AreEqual(v.RegionOrState, u);
            Assert.AreEqual(v.ZipOrPostalCode, u);
            Assert.AreEqual(v.Country, u);
            Assert.AreEqual(v.RegisteredTelecomAddresses.Count, 0);
        }

        [TestMethod] public void CreateWebAddressViewModelTest() {
            var o = GetRandom.Object<WebPageAddress>();
            var v = AddressViewFactory.Create(o) as WebPageAddressView;
            validateWeb(o.Data, v);
        }
        private void validateWeb(AddressData d, WebPageAddressView v) {
            Assert.AreEqual(v.Url, d.Address);
            validateCommon(d, v);
        }
        private void validateCommon(IdentifiedData d, EntityView v) {
            Assert.AreEqual(v.ID, d.ID);
            Assert.AreEqual(v.ValidFrom, d.ValidFrom);
            Assert.AreEqual(v.ValidTo, d.ValidTo);
        }
        [TestMethod] public void CreateEMailAddressViewModelTest() {
            var o = GetRandom.Object<EmailAddress>();
            var v = AddressViewFactory.Create(o) as EMailAddressView;
            validateEmail(o.Data, v);
        }
        private void validateEmail(AddressData d, EMailAddressView v) {
            Assert.AreEqual(v.EmailAddress, d.Address);
            validateCommon(d, v);
        }
        [TestMethod] public void CreateGeographicAddressViewModelTest() {
            var o = GetRandom.Object<GeographicAddress>();
            var v = AddressViewFactory.Create(o) as GeographicAddressView;
            Assert.AreEqual(v?.RegisteredTelecomAddresses?.Count, o.RegisteredTelecomDevices.Count);
            validateAdr(o.Data, v);
        }
        private void validateAdr(GeographicAddressData d, GeographicAddressView v) {
            Assert.AreEqual(v.AddressLine, d.Address);
            Assert.AreEqual(v.City, d.CityOrAreaCode);
            Assert.AreEqual(v.RegionOrState, d.RegionOrStateOrCountryCode);
            Assert.AreEqual(v.ZipOrPostalCode, d.ZipOrPostCodeOrExtension);
            Assert.AreEqual(v.Country, d.CountryID);
            validateCommon(d, v);
        }
        [TestMethod] public void CreateTelecomAddressViewModelTest() {
            var o = GetRandom.Object<TelecomAddress>();
            var v = AddressViewFactory.Create(o) as TelecomAddressView;
            Assert.AreEqual(v?.RegisteredInAddresses?.Count, o.RegisteredInAddresses.Count);
            validateTelco(o.Data, v);
        }
        private void validateTelco(TelecomAddressData d, TelecomAddressView v) {
            Assert.AreEqual(v.Number, d.Address);
            Assert.AreEqual(v.AreaCode, d.CityOrAreaCode);
            Assert.AreEqual(v.CountryCode, d.RegionOrStateOrCountryCode);
            Assert.AreEqual(v.Extension, d.ZipOrPostCodeOrExtension);
            Assert.AreEqual(v.DeviceType, d.Device);
            validateCommon(d, v);
        }
        [TestMethod] public void CreateWithExtremumDatesTest() {
            var o = GetRandom.Object<WebPageAddress>();
            o.Data.ValidFrom = DateTime.MinValue;
            o.Data.ValidTo = DateTime.MaxValue;
            var v = AddressViewFactory.Create(o);
            Assert.AreEqual(v.ID, o.Data.ID);
            Assert.AreEqual(v.ValidFrom, null);
            Assert.AreEqual(v.ValidTo, null);
        }
        [TestMethod]
        public void CreateTelecomAddressTest()
        {
            var v = GetRandom.Object<TelecomAddressView>();
            v.ValidTo = GetRandom.DateTime(v.ValidFrom);
            var o = AddressViewFactory.Create(v);
            validateTelco(o.Data, v);
        }
        [TestMethod]
        public void CreateGeographicAddressTest()
        {
            var v = GetRandom.Object<GeographicAddressView>();
            v.ValidTo = GetRandom.DateTime(v.ValidFrom);
            var o = AddressViewFactory.Create(v);
            validateAdr(o.Data, v);
        }
        [TestMethod]
        public void CreateEmailAddressTest()
        {
            var v = GetRandom.Object<EMailAddressView>();
            v.ValidTo = GetRandom.DateTime(v.ValidFrom);
            var o = AddressViewFactory.Create(v);
            validateEmail(o.Data, v);
        }
        [TestMethod]
        public void CreateWebPageAddressTest()
        {
            var v = GetRandom.Object<WebPageAddressView>();
            v.ValidTo = GetRandom.DateTime(v.ValidFrom);
            var o = AddressViewFactory.Create(v);
            validateWeb(o.Data, v);
        }

    }
}
