using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Quantity;
using Open.Domain.Quantity;
using Open.Infra.Quantity;
namespace Open.Tests.Infra.Quantity {
    [TestClass] public class EuroRatesInitializerTests : BaseTableInitializerTests<Rate,
        RateData> {
        private DateTime minDate;
        private DateTime maxDate;
        private int i;
        private void addRate(string currencyId, decimal rate, DateTime d) {
            minDate = d < minDate ? d : minDate;
            maxDate = d > maxDate ? d : maxDate;
            i++;
        }

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(EuroRatesInitializer);
            minDate = DateTime.MaxValue;
            maxDate = DateTime.MinValue;
            i = 0;
        }
        protected override ICrudRepository<Rate> getRepository() =>
            new RatesRepository(db);
        protected override DbSet<RateData> getDbSet() => db.Rates;
        protected override void initialize() => EuroRatesInitializer.Initialize(db);
        protected override void doBeforeCleanup() => clearDbSet(db.Rates);
        [TestMethod] public void LoadRatesHistoryTest() {
            EuroRatesInitializer.LoadRatesHistory(addRate, true);
            var firstDate = firstEuroRateDate();
            var lastDate = lastEuroRateDate();
            var minRates = numberOfRates(lastDate, firstDate);
            Assert.AreEqual(toStr(firstDate), toStr(minDate));
            Assert.IsTrue(lastDate <= maxDate.AddDays(3));
            Assert.IsTrue(i > minRates);
        }

        [TestMethod] public void LoadDailyRatesTest() {
            EuroRatesInitializer.LoadDailyRates(addRate, true);
            Assert.AreEqual(32, i);
        }
        [TestMethod] public void ReadXmlTest() {
            EuroRatesInitializer.ReadXml(testRates, DateTime.MinValue, addRate);
            Assert.AreEqual(31, i);
        }
        [TestMethod] public void AddRatesTest() {
            var date = GetRandom.DateTime();
            void action(XmlNode time) => EuroRatesInitializer.AddRates(time, date, addRate);
            doTest(action);
            Assert.AreEqual(31, i);
            Assert.AreEqual(toStr(date), toStr(minDate));
        }
        [TestMethod] public void AddRateTest() {
            var date = GetRandom.DateTime();
            void action(XmlNode time) {
                foreach (XmlNode rate in time.ChildNodes)
                    EuroRatesInitializer.AddRate(date, rate, addRate);
            }
            doTest(action);
            Assert.AreEqual(31, i);
            Assert.AreEqual(toStr(minDate), toStr(date));
        }
        [TestMethod] public void GetCurrencyTest() {
            var l = new List<string>();
            void action(XmlNode time) {
                foreach (XmlNode rate in time.ChildNodes) {
                    var c = EuroRatesInitializer.GetCurrency(rate);
                    if (l.Contains(c)) continue;
                    l.Add(c);
                }
            }
            doTest(action);
            Assert.AreEqual(31, l.Count);
        }
        [TestMethod] public void GetDateTest() {
            var date = DateTime.MinValue;
            void action(XmlNode time) => date = EuroRatesInitializer.GetDate(time);
            doTest(action);
            Assert.AreEqual("03/05/2015 00:00:00", toStr(date));
        }
        [TestMethod] public void GetRateTest() {
            var l = new List<string>();
            void action(XmlNode time) {
                foreach (XmlNode rate in time.ChildNodes) {
                    EuroRatesInitializer.GetRate(rate, out var r);
                    var c = r.ToString(CultureInfo.InvariantCulture);
                    if (l.Contains(c)) continue;
                    l.Add(c);
                }
            }
            doTest(action);
            Assert.AreEqual(31, l.Count);
        }
        [TestMethod] public void ToXmlDocumentTest() {
            Assert.IsNotNull(EuroRatesInitializer.ToXmlDocument(testRates));
            Assert.IsNotNull(EuroRatesInitializer.ToXmlDocument(null));
            Assert.IsNotNull(EuroRatesInitializer.ToXmlDocument(string.Empty));
            Assert.IsNotNull(EuroRatesInitializer.ToXmlDocument("      "));
        }
        [TestMethod] public void GetValueTest() {
            var date = string.Empty;
            void action(XmlNode time) =>
                date = EuroRatesInitializer.GetValue(time, EuroRatesInitializer.timeString);
            doTest(action);
            Assert.AreEqual("2015-03-05", date);
        }
        private static void doTest(Action<XmlNode> a) {
            var doc = EuroRatesInitializer.ToXmlDocument(testRates);
            foreach (XmlNode node in doc.ChildNodes) {
                foreach (XmlNode cube in node.ChildNodes) {
                    if (cube.Name != EuroRatesInitializer.cubeString) continue;
                    foreach (XmlNode time in cube.ChildNodes) { a(time); }
                }
            }
        }
        private static string testRates => EuroRatesInitializer.example;
        private static int numberOfRates(DateTime lastDate, DateTime firstDate) {
            var c = new DateTime(lastDate.Ticks - firstDate.Ticks);
            var days = (c.Year * 52 + c.Month * 4 + c.Day / 7) * 5;
            return days * 29;
        }
        private static  DateTime lastEuroRateDate() => DateTime.Today.Date;
        private static DateTime firstEuroRateDate() => new DateTime(1999, 01, 04).Date;
    }
}
