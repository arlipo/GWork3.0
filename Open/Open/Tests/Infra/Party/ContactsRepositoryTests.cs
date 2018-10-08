using System;
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
    public class ContactsRepositoryTests : PaginatedRepositoryTests<IAddress, AddressData> {
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(ContactsRepository);
        }
        protected override string getRandomMemberStringValue(AddressData d)
        {
            var i = GetRandom.UInt32() % 5;
            if (i == 0) return d.Address;
            if (i == 1) return d.CityOrAreaCode;
            if (i == 2) return d.RegionOrStateOrCountryCode;
            if (i == 3) return d.ZipOrPostCodeOrExtension;
            if (i == 4) return d.ID;
            return base.getRandomMemberStringValue(d);
        }
        protected override Func<AddressData, object> getRandomSortFunction()
        {
            var i = GetRandom.UInt32() % 6;
            if (i == 0) return x => x.Address;
            if (i == 1) return x => x.CityOrAreaCode;
            if (i == 2) return x => x.RegionOrStateOrCountryCode;
            if (i == 3) return x => x.ZipOrPostCodeOrExtension;
            if (i == 4) return x => x.ID;
            if (i == 5) return x => x.ValidFrom;
            return x => x.ValidTo;
        }
        protected override IAddress createObject(AddressData r) => AddressFactory.Create(r);
        protected override string getID(AddressData r) => r.ID;
        protected override ICrudRepository<IAddress> getRepository() => new ContactsRepository(db);
        protected override DbSet<AddressData> getDbSet() => db.Addresses;
        protected override AddressData getData(IAddress o) {
            switch (o) {
                case WebPageAddress web: return web.Data;
                case EmailAddress email: return email.Data;
                case TelecomAddress telco: return telco.Data;
                default: return (o as GeographicAddress)?.Data;
            }
        }
        protected override AddressData getRandomDbRecord() {
            var i = GetRandom.Int32() % 4;
            if (i == 0) return GetRandom.Object<WebPageAddressData>();
            if (i == 1) return GetRandom.Object<EmailAddressData>();
            if (i == 2) return GetRandom.Object<TelecomAddressData>();
            return GetRandom.Object<GeographicAddressData>();
        }
        protected override void validateDbRecords(AddressData e, AddressData a) {
            var eObj = AddressFactory.Create(e);
            var aObj = AddressFactory.Create(a);
            var eView = AddressViewFactory.Create(eObj);
            var aView = AddressViewFactory.Create(aObj);
            Assert.AreEqual(eView.Contact, aView.Contact);
            base.validateDbRecords(e, a);
        }

        [TestMethod] public void GetDevicesListTest() {
            Assert.Inconclusive();
        }
    }
}


