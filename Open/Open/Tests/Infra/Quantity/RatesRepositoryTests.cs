using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Quantity;
using Open.Domain.Quantity;
using Open.Infra.Quantity;
namespace Open.Tests.Infra.Quantity {

    [TestClass] public class RatesRepositoryTests : PaginatedRepositoryTests<Rate, RateData> {

        private RatesRepository rates;
        private string currencyID;
        private string typeID;
        private DateTime date;
        private decimal rate;

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(RatesRepository);
            rates = repository as RatesRepository;
        }
        [TestMethod] public async Task AddRateTest() {
            var currencyRate = await createRandomRate();
            await rates.AddRate(currencyID, rate, date, typeID);
            var r = await rates.GetObject(currencyRate.Data.ID);
            validateRate(r, currencyRate.Data.ID);
        }
        [TestMethod] public async Task GetRateTest() {
            var currencyRate = await createRandomRate();
            await rates.AddRate(currencyID, rate, date, typeID);
            var r = rates.GetRate(currencyRate.Data.ID);
            validateRate(r, currencyRate.Data.ID);
        }
        [TestMethod] public async Task GetRatesTest() {
            var c = new Currency(GetRandom.Object<CurrencyData>());
            var l = await createRandomRates(c.ID);
            var r = rates.GetRates(c);
            Assert.AreEqual(l.Count, r.Count);
            foreach (var x in r) Assert.IsTrue(l.Contains(x.Data.Rate));
        }
        private async Task<List<decimal>> createRandomRates(string id) {
            var l = new List<decimal>();
            var c = GetRandom.UInt8(30);
            var d = DateTime.Today.AddDays(-c);
            for (var i = 0; i < c; i++) {
                var r = GetRandom.Decimal(0);
                var cID = GetRandom.Bool() ? id : GetRandom.String();
                await rates.AddRate(cID, r, d);
                d = d.AddDays(1);
                if (cID != id) continue;
                l.Add(r);
            }
            return l;
        }
        protected override Rate createObject(RateData r) => new Rate(r);

        protected override RateData getData(Rate o) => o.Data;

        protected override string getID(RateData r) => r.ID;

        protected override ICrudRepository<Rate> getRepository() => new RatesRepository(db);

        protected override DbSet<RateData> getDbSet() => db.Rates;

        protected override string getRandomMemberStringValue(RateData d) {
            var i = GetRandom.UInt32() % 5;
            if (i == 0) return d.CurrencyID;
            if (i == 1) return d.Rate.ToString(CultureInfo.CurrentCulture);
            if (i == 2) return d.ID;
            if (i == 3) return d.RateTypeID;
            return base.getRandomMemberStringValue(d);
        }
        protected override Func<RateData, object> getRandomSortFunction() {
            var i = GetRandom.UInt32() % 6;
            if (i == 0) return x => x.CurrencyID;
            if (i == 1) return x => x.Rate;
            if (i == 2) return x => x.ID;
            if (i == 3) return x => x.RateTypeID;
            if (i == 4) return x => x.ValidFrom;
            return x => x.ValidTo;
        }
        private void validateRate(Rate r, string id) {
            Assert.AreEqual(id, r.Data.ID);
            Assert.AreEqual(currencyID, r.Data.CurrencyID);
            Assert.AreEqual(rate, r.Data.Rate);
            Assert.AreEqual(typeID, r.Data.RateTypeID);
            Assert.AreEqual(toStr(date), toStr(r.Data.ValidFrom));
        }
        private async Task<Rate> createRandomRate() {
            currencyID = GetRandom.String();
            typeID = GetRandom.String();
            date = GetRandom.DateTime(DateTime.Today.AddYears(-20), DateTime.Today).Date;
            rate = GetRandom.Decimal(0, 100);
            var r = RateFactory.Create(currencyID, rate, date, typeID);
            await noObjectInRepository(r.Data.ID);
            noRateInRepository(r.Data.ID);
            return r;
        }
        private void noRateInRepository(string id) {
            var o = rates.GetRate(id);
            Assert.AreEqual(Constants.Unspecified, o.Data.ID);
        }
        private async Task noObjectInRepository(string id) {
            var o = await rates.GetObject(id);
            Assert.AreEqual(Constants.Unspecified, o.Data.ID);
        }
    }
}

