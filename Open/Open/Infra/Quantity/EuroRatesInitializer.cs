using System;
using System.IO;
using System.Linq;
using System.Xml;
using Open.Aids;
using Open.Domain.Quantity;
namespace Open.Infra.Quantity {
    public static class EuroRatesInitializer {
        internal const string example = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                                        "<gesmes:Envelope xmlns=\"http://www.ecb.int/vocabulary/2002-08-01/eurofxref\" " +
                                        "xmlns:gesmes=\"http://www.gesmes.org/xml/2002-08-01\">" +
                                        "<gesmes:subject>Reference rates</gesmes:subject><gesmes:Sender>" +
                                        "<gesmes:name>European Central Bank</gesmes:name></gesmes:Sender>" +
                                        "<Cube><Cube time=\"2015-03-05\"><Cube rate=\"1.1069\" currency=\"USD\"/>" +
                                        "<Cube rate=\"133.10\" currency=\"JPY\"/><Cube rate=\"1.9558\" currency=\"BGN\"/>" +
                                        "<Cube rate=\"27.422\" currency=\"CZK\"/><Cube rate=\"7.4542\" currency=\"DKK\"/>" +
                                        "<Cube rate=\"0.72510\" currency=\"GBP\"/><Cube rate=\"305.36\" currency=\"HUF\"/>" +
                                        "<Cube rate=\"4.1397\" currency=\"PLN\"/><Cube rate=\"4.4453\" currency=\"RON\"/>" +
                                        "<Cube rate=\"9.2140\" currency=\"SEK\"/><Cube rate=\"1.0697\" currency=\"CHF\"/>" +
                                        "<Cube rate=\"8.5460\" currency=\"NOK\"/><Cube rate=\"7.6585\" currency=\"HRK\"/>" +
                                        "<Cube rate=\"67.6095\" currency=\"RUB\"/><Cube rate=\"2.8663\" currency=\"TRY\"/>" +
                                        "<Cube rate=\"1.4205\" currency=\"AUD\"/><Cube rate=\"3.3009\" currency=\"BRL\"/>" +
                                        "<Cube rate=\"1.3770\" currency=\"CAD\"/><Cube rate=\"6.9382\" currency=\"CNY\"/>" +
                                        "<Cube rate=\"8.5847\" currency=\"HKD\"/><Cube rate=\"14363.07\" currency=\"IDR\"/>" +
                                        "<Cube rate=\"4.4270\" currency=\"ILS\"/><Cube rate=\"68.9098\" currency=\"INR\"/>" +
                                        "<Cube rate=\"1218.84\" currency=\"KRW\"/><Cube rate=\"16.6566\" currency=\"MXN\"/>" +
                                        "<Cube rate=\"4.0416\" currency=\"MYR\"/><Cube rate=\"1.4777\" currency=\"NZD\"/>" +
                                        "<Cube rate=\"48.848\" currency=\"PHP\"/><Cube rate=\"1.5156\" currency=\"SGD\"/>" +
                                        "<Cube rate=\"35.885\" currency=\"THB\"/><Cube rate=\"13.0163\" currency=\"ZAR\"/>" +
                                        "</Cube></Cube></gesmes:Envelope>";
        internal const string historyUrl =
            "http://www.ecb.europa.eu/stats/eurofxref/eurofxref-hist.xml";
        internal const string dailyUrl =
            "http://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml";
        internal const string cubeString = "Cube";
        internal const string timeString = "time";
        internal const string rateString = "rate";
        internal const string currencyString = "currency";
        public static void LoadRatesHistory(Action<string, decimal, DateTime> addRate,
            bool readFromEcb = false, DateTime? toDate = null) {
            var date = toDate ?? DateTime.MinValue;
            var isTesting = IsRunning.Tests(readFromEcb);
            var s = isTesting ? example : WebService.Load(historyUrl);
            ReadXml(s, date, addRate);
        }
        public static void LoadDailyRates(Action<string, decimal, DateTime> addRate,
            bool readFromEcb = false) {
            var s = IsRunning.Tests(readFromEcb) ? example : WebService.Load(dailyUrl);
            ReadXml(s, DateTime.MinValue, addRate);
        }
        public static void ReadXml(string s, DateTime toDate,
            Action<string, decimal, DateTime> addRate) {
            var doc = ToXmlDocument(s);
            foreach (XmlNode node in doc.ChildNodes) {
                foreach (XmlNode cube in node.ChildNodes) {
                    if (cube.Name != cubeString) continue;
                    var i = 0;
                    foreach (XmlNode time in cube.ChildNodes) {
                        i++;
                        if (i > 10000) return;
                        var date = GetDate(time);
                        if (date < toDate) break;
                        AddRates(time, date, addRate);
                    }
                }
            }
        }
        public static void AddRates(XmlNode time, DateTime date,
            Action<string, decimal, DateTime> addRate) {
            foreach (XmlNode rate in time.ChildNodes) { AddRate(date, rate, addRate); }
        }
        public static void AddRate(DateTime date, XmlNode rate,
            Action<string, decimal, DateTime> addRate) {
            if (!GetRate(rate, out var value)) return;
            var currency = GetCurrency(rate);
            addRate(currency, value, date);
        }

        public static string GetCurrency(XmlNode node) {
            return GetValue(node, currencyString);
        }

        public static DateTime GetDate(XmlNode node) {
            var date = GetValue(node, timeString);
            return DateTime.ParseExact(date, "yyyy-MM-dd", UseCulture.Invariant);
        }
        public static bool GetRate(XmlNode node, out decimal rate) {
            var v = GetValue(node, rateString);
            return decimal.TryParse(v, out rate);
        }
        public static XmlDocument ToXmlDocument(string s) {
            return Safe.Run(() => {
                var stream = new StringReader(s);
                var r = XmlReader.Create(stream);
                var d = new XmlDocument();
                d.Load(r);
                return d;
            }, new XmlDocument());

        }
        public static string GetValue(XmlNode n, string name) {
            return Safe.Run(() => {
                var a = n.Attributes[name];
                return a.Value;
            }, string.Empty);
        }

        public static void Initialize(SentryDbContext c) {
            var i = 0;
            void addRate(string currencyId, decimal rate, DateTime date) {
                var r = RateFactory.Create(currencyId, rate, date, RateFactory.EuroRate);
                c.Rates.Add(r.Data);
                if (i++ < 1000) return;
                c.SaveChanges();
                i = 0;
            }

            c.Database.EnsureCreated();
            if (c.Rates.Any()) return;
            LoadRatesHistory(addRate);
            c.SaveChanges();
        }
    }
}