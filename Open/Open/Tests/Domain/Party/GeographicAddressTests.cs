using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Party;
using Open.Domain.Party;
namespace Open.Tests.Domain.Party {
    [TestClass]
    public class GeographicAddressTests : EntityBaseTests<GeographicAddress, GeographicAddressData> {
        protected override GeographicAddress getRandomObject() {
            createdWithNullArg = new GeographicAddress(null);
            dbRecordType = typeof(GeographicAddressData);
            return GetRandom.Object<GeographicAddress>();
        }
        [TestMethod] public void RegisteredTelecomDevicesTest() {
            Assert.IsNotNull(obj.RegisteredTelecomDevices);
            Assert.IsInstanceOfType(obj.RegisteredTelecomDevices,
                typeof(IReadOnlyList<TelecomAddress>));
        }

        [TestMethod] public void RegisteredTelecomDeviceTest() {
            var device = GetRandom.Object<TelecomAddress>();
            Assert.IsFalse(obj.RegisteredTelecomDevices.Contains(device));
            obj.RegisteredTelecomDevice(device);
            Assert.IsTrue(obj.RegisteredTelecomDevices.Contains(device));
        }
        [TestMethod] public void CountryTest() {
            Assert.AreEqual(obj.Country.Data, obj.Data.Country);
        }
        [TestMethod] public void WhenCreatedWithNullArgumentsTest() {
            obj = new GeographicAddress(null);
            Assert.IsNull(obj.Data.Country);
            Assert.IsNotNull(obj.Country.Data);
        }
    }
}

