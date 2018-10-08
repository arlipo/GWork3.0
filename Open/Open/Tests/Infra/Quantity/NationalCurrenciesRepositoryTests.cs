using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Party;
using Open.Data.Quantity;
using Open.Domain.Party;
using Open.Domain.Quantity;
using Open.Infra.Quantity;
namespace Open.Tests.Infra.Quantity {

    [TestClass] public class
        NationalCurrenciesRepositoryTests : BaseRepositoryTests<NationalCurrency,
            NationalCurrencyData> {
        private NationalCurrenciesRepository currencies;
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(NationalCurrenciesRepository);
            currencies = repository as NationalCurrenciesRepository;
        }
        protected override ICrudRepository<NationalCurrency> getRepository() =>
            new NationalCurrenciesRepository(db);
        protected override DbSet<NationalCurrencyData> getDbSet() => db.CountryCurrencies;
        protected override NationalCurrency createObject(NationalCurrencyData r) =>
            new NationalCurrency(r);
        protected override NationalCurrencyData getData(NationalCurrency o) => o.Data;
        protected override string getID(NationalCurrencyData r) => r.CountryID;
        protected override object[] getKey(NationalCurrencyData r) =>
            new object[] {r.CountryID, r.CurrencyID};
        [TestMethod] public async Task LoadCountriesTest() {
            var c = new Currency(GetRandom.Object<CurrencyData>());
            var l = createRandomCountries(c.ID);
            await currencies.LoadCountries(c);
            Assert.AreEqual(l.Count, c.UsedInCountries.Count);
            foreach (var x in c.UsedInCountries) Assert.IsTrue(l.Contains(x.Data.ID));
        }
        private List<string> createRandomCountries(string id) {
            NationalCurrencyData createCountry(string currencyId) {
                var country = GetRandom.Object<CountryData>();
                db.Countries.Add(country);
                return new NationalCurrencyData {CurrencyID = currencyId, CountryID = country.ID};
            }
            return createRecords(id, createCountry);
        }
        [TestMethod] public async Task LoadCurrenciesTest() {
            var c = new Country(GetRandom.Object<CountryData>());
            var l = createRandomCurrencies(c.Data.ID);
            await currencies.LoadCurrencies(c);
            Assert.AreEqual(l.Count, c.CurrenciesInUse.Count);
            foreach (var x in c.CurrenciesInUse) Assert.IsTrue(l.Contains(x.Data.ID));
        }
        private List<string> createRandomCurrencies(string id) {
            NationalCurrencyData createCurrency(string countryId) {
                var currency = GetRandom.Object<CurrencyData>();
                db.Currencies.Add(currency);
                return new NationalCurrencyData {CurrencyID = currency.ID, CountryID = countryId};
            }
            return createRecords(id, createCurrency);
        }
        private List<string> createRecords(string id,
            Func<string, NationalCurrencyData> createRecord) {
            var l = new List<string>();
            var c = GetRandom.UInt8(30);
            for (var i = 0; i < c; i++) {
                var cID = GetRandom.Bool() ? id : GetRandom.String();
                var countryCurrency = createRecord(cID);
                db.CountryCurrencies.Add(countryCurrency);
                db.SaveChanges();
                if (cID != id) continue;
                l.Add(getOtherId(countryCurrency, cID));
            }

            return l;
        }
        private string getOtherId(NationalCurrencyData d, string cID) {
            return d.CountryID == cID ? d.CurrencyID : d.CountryID;
        }
    }
}
