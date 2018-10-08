using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Quantity;
using Open.Domain.Quantity;
using Open.Infra.Quantity;
namespace Open.Tests.Infra.Quantity {
    [TestClass]
    public class CurrenciesRepositoryTests 
        : PaginatedRepositoryTests<Currency, CurrencyData> {
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(CurrenciesRepository);
        }
        protected override string getRandomMemberStringValue(CurrencyData d)
        {
            var i = GetRandom.UInt32() % 4;
            if (i == 0) return d.Code;
            if (i == 1) return d.Name;
            if (i == 2) return d.ID;
            if (i == 3) return d.Definition;
            return base.getRandomMemberStringValue(d);
        }
        protected override Func<CurrencyData, object> getRandomSortFunction() {
            var i = GetRandom.UInt32() % 5;
            if (i == 0) return x=>x.Code;
            if (i == 1) return x => x.Definition;
            if (i == 2) return x => x.ID;
            if (i == 3) return x => x.Name;
            if (i == 4) return x => x.ValidFrom;
            return x => x.ValidTo;
        }
        protected override ICrudRepository<Currency> getRepository() => new CurrenciesRepository(db);
        protected override DbSet<CurrencyData> getDbSet() => db.Currencies;
        protected override CurrencyData getData(Currency o) => o.Data;
        protected override string getID(CurrencyData r) => r.ID;
        protected override Currency createObject(CurrencyData r) => new Currency(r);
        protected override void setRandomValues(Currency o) {
            o.Data.Name = GetRandom.String();
            o.Data.Code = GetRandom.String();
            base.setRandomValues(o);
        }
        protected override void validateDbRecords(CurrencyData e, CurrencyData a) {
            Assert.AreEqual(e.Name, a.Name);
            Assert.AreEqual(e.Code, a.Code);
            base.validateDbRecords(e, a);
        }
        [TestMethod] public void CanCreateWithNullTest() {
            Assert.IsNotNull(new CurrenciesRepository(null));
        }
    }
}



