using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Party;
using Open.Domain.Party;
using Open.Facade.Party;
using Open.Infra.Party;
namespace Open.Tests.Infra.Party {
    [TestClass]
    public class
        TelecomDeviceRegistrationsRepositoryTests : BaseRepositoryTests<
            TelecomDeviceRegistration,
            TelecomDeviceRegistrationData> {
        private TelecomDeviceRegistrationsRepository registrations;
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(TelecomDeviceRegistrationsRepository);
            registrations = repository as TelecomDeviceRegistrationsRepository;
        }
        [TestMethod] public void CanCreate() {
            Assert.IsNotNull(new TelecomDeviceRegistrationsRepository(null));
        }
        [TestMethod] public async Task LoadAddressesTest() {
            var c = new TelecomAddress(GetRandom.Object<TelecomAddressData>());
            var l = createRandomAddresses(c.Data.ID);
            await registrations.LoadAddresses(c);
            Assert.AreEqual(l.Count, c.RegisteredInAddresses.Count);
            foreach (var x in c.RegisteredInAddresses) Assert.IsTrue(l.Contains(x.Data.ID));
        }
        [TestMethod] public async Task LoadDevicesTest() {
            var c = new GeographicAddress(GetRandom.Object<GeographicAddressData>());
            var l = createRandomDevices(c.Data.ID);
            await registrations.LoadDevices(c);
            Assert.AreEqual(l.Count, c.RegisteredTelecomDevices.Count);
            foreach (var x in c.RegisteredTelecomDevices) Assert.IsTrue(l.Contains(x.Data.ID));
        }
        protected override TelecomDeviceRegistration createObject(TelecomDeviceRegistrationData r) =>
            new TelecomDeviceRegistration(r);
        protected override TelecomDeviceRegistrationData getData(TelecomDeviceRegistration o) => o.Data;
        protected override string getID(TelecomDeviceRegistrationData r) => r.AddressID;
        protected override object[] getKey(TelecomDeviceRegistrationData r) => new object[] { r.AddressID, r.DeviceID };
        protected override ICrudRepository<TelecomDeviceRegistration> getRepository() =>
            new TelecomDeviceRegistrationsRepository(db);
        protected override DbSet<TelecomDeviceRegistrationData> getDbSet() => db.TelecomDeviceRegistrations;
        private List<string> createRandomAddresses(string id)
        {
            TelecomDeviceRegistrationData createAddress(string deviceId)
            {
                var view = GetRandom.Object<GeographicAddressView>();
                var adr = AddressViewFactory.Create(view);
                db.Addresses.Add(adr.Data);
                return new TelecomDeviceRegistrationData { AddressID = adr.Data.ID, DeviceID = deviceId };
            }
            return createRecords(id, createAddress);
        }
        private List<string> createRandomDevices(string id)
        {
            TelecomDeviceRegistrationData createDevice(string addressId)
            {
                var view = GetRandom.Object<TelecomAddressView>();
                var device = AddressViewFactory.Create(view);
                db.Addresses.Add(device.Data);
                return new TelecomDeviceRegistrationData { AddressID = addressId, DeviceID = device.Data.ID };
            }
            return createRecords(id, createDevice);
        }
        private List<string> createRecords(string id,
            Func<string, TelecomDeviceRegistrationData> createRecord)
        {
            var l = new List<string>();
            var c = GetRandom.UInt8(30);
            for (var i = 0; i < c; i++)
            {
                var cID = GetRandom.Bool() ? id : GetRandom.String();
                var deviceRegistration = createRecord(cID);
                db.TelecomDeviceRegistrations.Add(deviceRegistration);
                db.SaveChanges();
                if (cID != id) continue;
                l.Add(getOtherId(deviceRegistration, cID));
            }

            return l;
        }
        private string getOtherId(TelecomDeviceRegistrationData d, string cID)
        {
            return d.AddressID == cID ? d.DeviceID : d.AddressID;
        }
    }
}




