using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Party;
using Open.Domain.Party;
using Open.Infra.Party;
namespace Open.Tests.Infra.Party {
    [TestClass]
    public class ContactsInitializerTests : 
        BaseTableInitializerTests<IAddress, AddressData> {
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(ContactsInitializer);
        }
        protected override ICrudRepository<IAddress> getRepository() 
            => new ContactsRepository(db);
        protected override DbSet<AddressData> getDbSet() => db.Addresses;
        protected override AddressData getRandomDbRecord()
        {
            var i = GetRandom.Int32() % 4;
            if (i == 0) return GetRandom.Object<WebPageAddressData>();
            if (i == 1) return GetRandom.Object<EmailAddressData>();
            if (i == 2) return GetRandom.Object<TelecomAddressData>();
            return GetRandom.Object<GeographicAddressData>();
        }
        protected override void initialize() => ContactsInitializer.Initialize(db); 

        protected override void doBeforeCleanup() => clearDbSet(db.TelecomDeviceRegistrations);
    }
}



