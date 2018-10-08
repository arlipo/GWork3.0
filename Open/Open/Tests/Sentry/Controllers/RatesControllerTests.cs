using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Quantity;
using Open.Domain.Quantity;
using Open.Facade.Quantity;
using Open.Infra.Quantity;
using Open.Sentry.Controllers;
namespace Open.Tests.Sentry.Controllers {
    [TestClass] public class RatesControllerTests : BaseControllerTests<RatesController, Rate, RateData> {
        protected override List<string> specificStringsToTestInIndexView() {
            return new List<string> {
                "<h2>Rates</h2>",
                "<a href=\"/rates/Create\">Create New</a>"
            };
        }
        protected override string createDbRecord() {
            var r = GetRandom.Object<RateData>();
            db.Rates.Add(r);
            db.SaveChanges();
            specificStringsToTestInView = new List<string> {
                $"{r.CurrencyID}",
                $"{r.RateTypeID}",
                $"{r.Rate.ToString(CultureInfo.CurrentCulture)}"
            };
            return r.ID;
        }
        protected override async Task isNotInRepository(string id) {
            var r = await repository.GetObject(id);
            Assert.AreEqual(r.Data.ID, Constants.Unspecified);
        }
        protected override async Task validateEntityInRepository(object o) {
            var expected = o as RateView;
            var actual = await repository.GetObject(expected?.ID);
            Assert.IsNotNull(expected);
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.ID, actual.Data.ID);
            Assert.AreEqual(expected.CurrencyID, actual.Data.CurrencyID);
            Assert.AreEqual(expected.RateTypeID, actual.Data.RateTypeID);
            Assert.AreEqual(expected.Rate, actual.Data.Rate);
            validateDates(expected.ValidFrom, actual.Data.ValidFrom);
            validateDates(expected.ValidTo, actual.Data.ValidTo);
        }
        protected override IEnumerable<KeyValuePair<string, string>> createHttpPostContext(object o) {
            var c = o as RateView;
            var d = new Dictionary<string, string> {
                {GetMember.Name<RateView>(m => m.ID), c?.ID},
                {GetMember.Name<RateView>(m => m.CurrencyID), c?.CurrencyID},
                {GetMember.Name<RateView>(m => m.RateTypeID), c?.RateTypeID},
                {GetMember.Name<RateView>(m => m.Rate), c?.Rate.ToString(CultureInfo.InvariantCulture)},
                {GetMember.Name<RateView>(m => m.ValidFrom), c?.ValidFrom.ToString()},
                {GetMember.Name<RateView>(m => m.ValidTo), c?.ValidTo.ToString()}
            };
            return d;
        }
        protected override object createRandomViewModel() {
            var v = GetRandom.Object<RateView>();
            v.ID = RateFactory.CalculateID(v.CurrencyID, v.ValidFrom, v.RateTypeID);
            var dt = (v.ValidFrom ?? DateTime.Now).Date;
            v.ValidFrom = dt;
            v.ValidTo = dt.AddSeconds(24 * 60 * 60 - 1);
            addCurrency(v.CurrencyID);
            addRateType(v.RateTypeID);
            return v;
        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            repository = new RatesRepository(db);
            controller = "rates";
            detailsViewCaption = "Exchange Rate";
            editViewCaption = detailsViewCaption;
        }
    }
}
