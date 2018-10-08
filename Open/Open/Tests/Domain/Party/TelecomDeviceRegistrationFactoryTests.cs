using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Party;
using Open.Domain.Party;
namespace Open.Tests.Domain.Party {
    [TestClass] public class TelecomDeviceRegistrationFactoryTests : BaseTests {

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(TelecomDeviceRegistrationFactory);
        }

        [TestMethod] public void CreateTest() {
            var r = GetRandom.Object<TelecomDeviceRegistrationData>();
            var address = new GeographicAddress(r.Address);
            var device = new TelecomAddress(r.Device);

            var o = TelecomDeviceRegistrationFactory.Create(address, device, r.ValidFrom,
                r.ValidTo);

            Assert.AreEqual(o.Data.ValidFrom, r.ValidFrom);
            Assert.AreEqual(o.Data.ValidTo, r.ValidTo);
            Assert.AreEqual(o.Address.Data, r.Address);
            Assert.AreEqual(o.Device.Data, r.Device);
            Assert.AreEqual(o.Data.AddressID, r.Address.ID);
            Assert.AreEqual(o.Data.DeviceID, r.Device.ID);
            Assert.AreEqual(o.Data.Address, r.Address);
            Assert.AreEqual(o.Data.Device, r.Device);
        }

        [TestMethod] public void CreateWithNullArgumentsTest() {

            var o = TelecomDeviceRegistrationFactory.Create(null, null);

            Assert.AreEqual(o.Data.ValidFrom, DateTime.MinValue);
            Assert.AreEqual(o.Data.ValidTo, DateTime.MaxValue);
            Assert.AreEqual(o.Address.Data, o.Data.Address);
            Assert.AreEqual(o.Device.Data, o.Data.Device);
            Assert.AreEqual(o.Data.AddressID, Constants.Unspecified);
            Assert.AreEqual(o.Data.DeviceID, Constants.Unspecified);
        }

    }
}




