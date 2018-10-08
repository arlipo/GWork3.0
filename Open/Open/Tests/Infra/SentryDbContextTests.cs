using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Party;
using Open.Data.Quantity;
using Open.Infra;
namespace Open.Tests.Infra {

public class SentryDbContextTests : BaseIntegrationTests<SentryDbContext> {

        private class testClass : SentryDbContext {
            public testClass(DbContextOptions<SentryDbContext> o) : base(o) { }
            public ModelBuilder RunOnModelCreating() {
                var set = new ConventionSet();
                var mb = new ModelBuilder(set);
                OnModelCreating(mb);
                return mb;
            }
        }

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(SentryDbContext);
        }
    protected override SentryDbContext getRandomObject() {
        return db;
    }
    [TestMethod] public void CountriesTest() {
            Assert.IsNotNull(db.Countries);
        }

        [TestMethod] public void CurrenciesTest() {
            Assert.IsNotNull(db.Currencies);
        }
        [TestMethod] public void CountryCurrenciesTest() {
            Assert.IsNotNull(db.CountryCurrencies);
        }
        [TestMethod] public void AddressesTest() {
            Assert.IsNotNull(db.Addresses);
        }
        [TestMethod] public void TelecomDeviceRegistrationsTest() {
            Assert.IsNotNull(db.TelecomDeviceRegistrations);
        }
        [TestMethod] public void CreateAddressTableTest() {
            var set = new ConventionSet();
            var mb = new ModelBuilder(set);
            SentryDbContext.createAddressTable(mb);
            testHasAdressEntities(mb);
        }
        private static void testHasAdressEntities(ModelBuilder mb) {
            testEntity<CountryData>(mb);
            testEntity<AddressData>(mb);
            var entity = testEntity<GeographicAddressData>(mb, false, 1);
            var countryID = GetMember.Name<GeographicAddressData>(x => x.CountryID);
            testForeignKey(entity,countryID, typeof(CountryData));
            testEntity<WebPageAddressData>(mb);
            testEntity<EmailAddressData>(mb);
            testEntity<TelecomAddressData>(mb);
        }
        [TestMethod] public void CreateNationalCurrencyTableTest() {
            var set = new ConventionSet();
            var mb = new ModelBuilder(set);
            SentryDbContext.createNationalCurrencyTable(mb);
            testHasNationalCurrencyEntities(mb);
        }
        private static void testHasNationalCurrencyEntities(ModelBuilder mb) {
            testEntity<CountryData>(mb);
            testEntity<CurrencyData>(mb);
            var entity = testEntity<NationalCurrencyData>(mb, true, 2);
            var countryID = GetMember.Name<NationalCurrencyData>(x => x.CountryID);
            var currencyID = GetMember.Name<NationalCurrencyData>(x => x.CurrencyID);
            testPrimaryKey(entity, countryID, currencyID);
            testForeignKey(entity, countryID, typeof(CountryData));
            testForeignKey(entity, currencyID, typeof(CurrencyData));
        }
        [TestMethod] public void CreateTelecomAddressRegistrationTableTest() {
            var set = new ConventionSet();
            var mb = new ModelBuilder(set);
            SentryDbContext.createTelecomAddressRegistrationTable(mb);
            testHasTelecomRegistrationEntities(mb);
        }
        private static void testHasTelecomRegistrationEntities(ModelBuilder mb) {
            testEntity<GeographicAddressData>(mb);
            testOtherTelecomRegistrationEntities(mb);
        }
        private static void testOtherTelecomRegistrationEntities(ModelBuilder mb) {
            testEntity<TelecomAddressData>(mb);
            var entity = testEntity<TelecomDeviceRegistrationData>(mb, true, 2);
            var adrID = GetMember.Name<TelecomDeviceRegistrationData>(x => x.AddressID);
            var devID = GetMember.Name<TelecomDeviceRegistrationData>(x => x.DeviceID);
            testPrimaryKey(entity, adrID, devID);
            testForeignKey(entity, adrID, typeof(GeographicAddressData));
            testForeignKey(entity, devID, typeof(TelecomAddressData));
        }
        private static IMutableEntityType testEntity<T>(ModelBuilder mb, bool hasPrimaryKey = false, int foreignKeysCount = 0) {
            var name = typeof(T).FullName;
            var entity = mb.Model.FindEntityType(name);
            Assert.IsNotNull(entity, name );
            testPrimaryKey(entity, hasPrimaryKey);
            testForeignKey(entity, foreignKeysCount);
            return entity;
        }

        private static void testForeignKey(IMutableEntityType entity, int foreignKeysCount) {
            Assert.AreEqual(foreignKeysCount, entity.GetForeignKeys().Count());
        }

        private static void testPrimaryKey(IMutableEntityType entity, bool hasPrimaryKey) {
            if (hasPrimaryKey) Assert.IsNotNull(entity.FindPrimaryKey());
            else Assert.IsNull(entity.FindPrimaryKey());
        }

        private static void testForeignKey(IMutableEntityType entity, string name = null, Type t = null) {
            var keys = entity.GetForeignKeys();
            foreach (var k in keys) {
                var key = k.Properties.FirstOrDefault(x => x.Name == name);
                if (key is null) continue;
                Assert.AreEqual(k.PrincipalEntityType.Name, t?.FullName);
                return;
            }
            Assert.Fail("No foreign key found");
        }
        private static void testPrimaryKey(IMutableEntityType entity, params string[] values) {
            var key = entity.FindPrimaryKey();
            if (values is null) Assert.IsNull(key);
            else
                foreach (var v in values) {
                    Assert.IsNotNull(key.Properties.FirstOrDefault(x => x.Name == v));
                }
        }
        [TestMethod] public void OnModelCreatingTest() {
            var o = new DbContextOptions<SentryDbContext>();
            var context = new testClass(o);
            var mb = context.RunOnModelCreating();
            testHasAdressEntities(mb);
            testHasNationalCurrencyEntities(mb);
            testOtherTelecomRegistrationEntities(mb);
        }
    }
}







