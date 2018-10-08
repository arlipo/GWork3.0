using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Quantity;
using Open.Domain.Quantity;
namespace Open.Tests.Domain.Quantity {
    [TestClass] public class ConvertMoneyTests : BaseTests {

        private class mockRatesRepository : MockRepository<Rate, RateData>, IRateRepository {
            protected override bool getObject(Rate obj, string id) {
                throw new NotImplementedException();
            }

            public Rate GetRate(string rateID) {
                return objects.Find(x => x.Data.ID == rateID);
            }

            public List<Rate> GetRates(Currency c) {
                return objects.FindAll(x => x.Data.ID.Contains(c.ID));
            }

            public async Task AddRate(string currencyID, decimal rate, DateTime? date = null,
                string rateType = null) {
                var r = RateFactory.Create(currencyID, rate, date, rateType);
                await AddObject(r);
            }
        }

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(ConvertMoney);
            ConvertMoney.rates = new mockRatesRepository();
        }


        [TestMethod] public void ToCurrencyTest() {

            var c = new Currency(GetRandom.Object<CurrencyData>());
            var m = new Money(c, GetRandom.Decimal(10, 1000));
            c = new Currency(GetRandom.Object<CurrencyData>());
            var r1 = GetRandom.Decimal(1, 1000);
            var r2 = GetRandom.Decimal(1, 1000);
            ConvertMoney.rates.AddRate(m.Currency.ID, r1);
            ConvertMoney.rates.AddRate(c.ID, r2);

            var o = ConvertMoney.ToCurrency(m, c);

            Assert.IsNotNull(o);
            Assert.AreEqual(o.Currency.ID, c.ID);
            Assert.AreEqual((m.Amount / r1) * r2 , o.Amount);
        }
    }
}