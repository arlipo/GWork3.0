using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Quantity;
using Open.Domain.Quantity;
using Open.Facade.Quantity;
using Open.Infra.Quantity;
using Open.Sentry.Controllers;
namespace Open.Tests.Sentry.Controllers
{
    [TestClass] public class CurrenciesControllerTests : BaseControllerTests<CurrenciesController, Currency, CurrencyData>
    {
        protected override List<string> specificStringsToTestInIndexView()
        {
            return new List<string> {
                "<h2>Currencies</h2>",
                "<a href=\"/currencies/Create\">Create New</a>",
                "<th><a href=\"/currencies\">ISO Currency Code</a></th>",
                "<th><a href=\"/currencies\">Currency symbol</a></th>",
                "<th><a href=\"/currencies?SortOrder=name_desc\">Name</a></th>",
                "<th><a href=\"/currencies?SortOrder=validFrom\">Valid From</a></th>",
                "<th><a href=\"/currencies?SortOrder=validFrom\">Valid To</a></th>",
                "<th></th>",
                "<td>AFN</td>",
                "<td>&#x60B;</td>",
                "<td>Afghan Afghani</td>",
                "<td></td>",
                "<td></td>",
                "<th><a href=\"/currencies/Edit/AFN\">Edit</a>",
                "<a href=\"/currencies/Details/AFN\">Details</a>",
                "<a href=\"/currencies/Delete/AFN\">Delete</a>"};
        }
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            repository = new CurrenciesRepository(db);
            controller = "currencies";
            detailsViewCaption = "Currency";
        }

        protected override string createDbRecord() {
            var r = GetRandom.Object<CurrencyData>();
            db.Currencies.Add(r);
            db.SaveChanges();
            specificStringsToTestInView = new List<string> {
                $"{r.ID}",
                $"{r.Code}",
                $"{r.Name}"
            };
            editViewCaption = $"Currency ({r.ID})";
            return r.ID;
        }
        protected override async Task isNotInRepository(string id)
        {
            var r = await repository.GetObject(id);
            Assert.AreEqual(r.Data.ID, Constants.Unspecified);
        }
        protected override async Task validateEntityInRepository(object o) {
            var expected = o as CurrencyView;
            var actual = await repository.GetObject(expected?.IsoCode);
            Assert.IsNotNull(expected);
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.IsoCode, actual.Data.ID);
            Assert.AreEqual(expected.Symbol, actual.Data.Code);
            Assert.AreEqual(expected.Name, actual.Data.Name);
            validateDates(expected.ValidFrom, actual.Data.ValidFrom);
            validateDates(expected.ValidTo, actual.Data.ValidTo);
        }
        protected override IEnumerable<KeyValuePair<string, string>> createHttpPostContext(object o) {
            var c = o as CurrencyView;
            var d = new Dictionary<string, string> {
                {GetMember.Name<CurrencyView>(m => m.IsoCode), c?.IsoCode},
                {GetMember.Name<CurrencyView>(m => m.Symbol), c?.Symbol},
                {GetMember.Name<CurrencyView>(m => m.Name), c?.Name},
                {GetMember.Name<CurrencyView>(m => m.ValidFrom), c?.ValidFrom.ToString()},
                {GetMember.Name<CurrencyView>(m => m.ValidTo), c?.ValidTo.ToString()}
            };
            return d;
        }
        protected override object createRandomViewModel() {
            var r = GetRandom.Object<CurrencyView>();
            r.IsoCode = GetRandom.String(3, 3).ToUpper();
            r.Symbol = GetRandom.String();
            r.Name = GetRandom.String(1, 1).ToUpper() + GetRandom.String();
            r.ValidTo = GetRandom.DateTime(r.ValidFrom);
            return r;
        }
    }
}
