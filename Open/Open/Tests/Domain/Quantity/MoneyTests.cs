using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Quantity;
using Open.Domain.Quantity;
using Open.Infra;
using Open.Infra.Quantity;
namespace Open.Tests.Domain.Quantity {
    [TestClass] public class MoneyTests : ObjectTests<Money> {
        protected override Money getRandomObject() {
            return GetRandom.Object<Money>();
        }

        private Currency eek;
        private Currency usd;
        private Currency eur;
        private DateTime dt1;
        private DateTime dt2;

        [TestInitialize] public override void TestInitialize() {
            var name = Guid.NewGuid()
                .ToString();
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();
            var builder = new DbContextOptionsBuilder<SentryDbContext>()
                .UseInMemoryDatabase(name)
                .UseInternalServiceProvider(serviceProvider);
            ConvertMoney.rates = new RatesRepository(new SentryDbContext(builder.Options));
            base.TestInitialize();
            usd = new Currency(new CurrencyData {Code = "USD"});
            eur = new Currency(new CurrencyData {Code = "EUR"});
            eek = new Currency(new CurrencyData {Code = "EEK"});
            dt1 = DateTime.Now.AddDays(-1);
            dt2 = DateTime.Now.AddDays(-2);
            var t = new RateType(new RateTypeData {Code = RateFactory.EuroRate});
            ConvertMoney.rates.AddObject(RateFactory.Create(eur, 1M, dt1, t));
            ConvertMoney.rates.AddObject(RateFactory.Create(usd, 2M, dt1, t));
            ConvertMoney.rates.AddObject(RateFactory.Create(usd, 3M, dt2, t));
            ConvertMoney.rates.AddObject(RateFactory.Create(eek, 10M, dt1, t));
            ConvertMoney.rates.AddObject(RateFactory.Create(eek, 15M, dt2, t));
        }

        [TestMethod] public void AddTest() {
            void test(Money a, Money b, decimal c, Currency d, DateTime e) {
                var q = a.Add(b);
                Assert.AreEqual(d.ID, q.Currency.ID);
                Assert.AreEqual(c, q.Amount);
                Assert.AreEqual(e, q.Date);
            }

            var q1 = new Money(eur, 10M, dt1);
            var q2 = new Money(usd, 2M, dt1);
            var q3 = new Money(eek, 100M, dt1);
            var q4 = new Money(eur, 1M, dt2);
            test(q1, q2, 22, usd, dt1);
            test(q2, q1, 11, eur, dt1);
            test(q1, q3, 200, eek, dt1);
            test(q3, q1, 20, eur, dt1);
            test(q3, q4, 11, eur, dt2);
            test(q4, q3, 115, eek, dt1);
        }

        [TestMethod] public void AmountTest() {
            canReadWrite(() => obj.Amount, x => obj.Amount = x);
        }

        [TestMethod] public void CompareToTest() {
            void test(Money a, Money b, int c) {
                var q = a.CompareTo(b);
                Assert.AreEqual(c, q);
            }

            var q1 = new Money(eur, 10M, dt1);
            var q2 = new Money(usd, 2M, dt1);
            var q3 = new Money(eek, 100M, dt1);
            test(q1, q2, 1);
            test(q2, q1, -1);
            test(q1, q3, 0);
            test(q3, q1, 0);
        }

        [TestMethod] public void ConvertToTest() {
            void test(Money a, Currency b, decimal c, DateTime d) {
                var x = a.ConvertTo(b);
                Assert.AreEqual(b.ID, x.Currency.ID);
                Assert.AreEqual(d, x.Date);
                Assert.AreEqual(c, x.Amount);
            }

            test(new Money(eur, 10M, dt1), eek, 100, dt1);
            test(new Money(eur, 10M, dt2), eek, 150, dt2);
            test(new Money(eek, 200M, dt1), eur, 20, dt1);
            test(new Money(eek, 300M, dt2), eur, 20, dt2);
            test(new Money(eur, 10M, dt1), usd, 20, dt1);
            test(new Money(eur, 10M, dt2), usd, 30, dt2);
        }

        [TestMethod] public void CurrencyTest() {
            var c = new Currency();
            var m = new Money(c);
            Assert.AreEqual(c, m.Currency);
        }

        [TestMethod] public void DateTest() {
            var dt = GetRandom.DateTime();
            var m = new Money(null, 0, dt);
            Assert.AreEqual(dt, m.Date);
        }

        [TestMethod] public void DivideTest() {
            void test(Money a, decimal b, decimal c, Currency d, DateTime e) {
                var q = a.Divide(b);
                Assert.AreEqual(d, q.Currency);
                Assert.AreEqual(e, q.Date);
                Assert.AreEqual(c, q.Amount);
            }

            var q1 = new Money(eur, 10M, dt1);
            var q2 = new Money(usd, 2M, dt1);
            var q3 = new Money(eek, 100M, dt1);
            var q4 = new Money(eur, 1M, dt2);
            var q5 = new Money(eur, 0, dt2);
            test(q1, -1, -10, eur, dt1);
            test(q2, 0, decimal.MaxValue, usd, dt1);
            test(q3, 1, 100, eek, dt1);
            test(q4, 2, 0.5M, eur, dt2);
            test(q5, 3, 0, eur, dt2);
        }

        [TestMethod] public void MultiplyTest() {
            void test(Money a, decimal b, decimal c, Currency d, DateTime e) {
                var q = a.Multiply(b);
                Assert.AreEqual(d.ID, q.Currency.ID);
                Assert.AreEqual(e, q.Date);
                Assert.AreEqual(c, q.Amount);
            }
            var q1 = new Money(eur, 10M, dt1);
            var q2 = new Money(usd, 2M, dt1);
            var q3 = new Money(eek, 100M, dt1);
            var q4 = new Money(eur, 1M, dt2);
            var q5 = new Money(eur, 0, dt2);
            test(q1, -1, -10, eur, dt1);
            test(q2, 0, 0, usd, dt1);
            test(q3, 1, 100, eek, dt1);
            test(q4, 2, 2M, eur, dt2);
            test(q5, 3, 0, eur, dt2);
        }

        [TestMethod] public void RoundTest() {
            decimal test(decimal x, RoundingStrategy strategy, sbyte percition, byte digits, double step) {
                var p = new RoundingPolicy(strategy, percition, digits, step);
                var v = new Money(usd, x, dt1);
                return v.Round(p).Amount;
            }

            Assert.AreEqual(4.5M, test(4.45M, RoundingStrategy.RoundUp, 1, GetRandom.UInt8(), GetRandom.Double()));
            Assert.AreEqual(-4.45M, test(-4.456M, RoundingStrategy.RoundDown, 2, GetRandom.UInt8(), GetRandom.Double()));
            Assert.AreEqual(-4.5M, test(-4.45M, RoundingStrategy.RoundUpByStep, GetRandom.Int8(), GetRandom.UInt8(), 0.25));
            Assert.AreEqual(4.25M, test(4.45M, RoundingStrategy.RoundDownByStep, GetRandom.Int8(), GetRandom.UInt8(), 0.25));
            Assert.AreEqual(-4.5M, test(-4.45M, RoundingStrategy.RoundTowardsNegative, 1, GetRandom.UInt8(), GetRandom.Double()));
            Assert.AreEqual(4.46M, test(4.456M, RoundingStrategy.RoundTowardsPositive, 2, GetRandom.UInt8(), GetRandom.Double()));
            Assert.AreEqual(4.45M, test(4.456M, RoundingStrategy.Round, 2, 7, GetRandom.Double()));
        }

        [TestMethod] public void SubtractTest() {
            void test(Money a, Money b, decimal c, Currency d, DateTime e) {
                var q = a.Subtract(b);
                Assert.AreEqual(d.ID, q.Currency.ID);
                Assert.AreEqual(e, q.Date);
                Assert.AreEqual(c, q.Amount);
            }
            var q1 = new Money(eur, 10M, dt1);
            var q2 = new Money(usd, 2M, dt1);
            var q3 = new Money(eek, 100M, dt1);
            var q4 = new Money(eur, 1M, dt2);
            test(q1, q2, 18, usd, dt1);
            test(q2, q1, -9, eur, dt1);
            test(q1, q3, 0, eek, dt1);
            test(q3, q1, 0, eur, dt1);
            test(q4, q3, -85, eek, dt1);
            test(q3, q4, 9, eur, dt2);
        }
    }
}