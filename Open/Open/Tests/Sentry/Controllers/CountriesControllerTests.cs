using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Party;
using Open.Domain.Party;
using Open.Facade.Party;
using Open.Infra.Party;
using Open.Sentry.Controllers;
namespace Open.Tests.Sentry.Controllers {

    [TestClass]
    public class CountriesControllerTests : BaseControllerTests<CountriesController, Country, CountryData> {
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            repository = new CountriesRepository(db);
            controller = "countries";
            detailsViewCaption = "Country";
        }
        protected override string createDbRecord() {
            var r = GetRandom.Object<CountryData>();
            db.Countries.Add(r);
            db.SaveChanges();
            specificStringsToTestInView = new List<string> {
                $"{r.ID}",
                $"{r.Code}",
                $"{r.Name}"
            };
            editViewCaption = $"Country ({r.ID})";
            return r.ID;
        }
        protected override async Task isNotInRepository(string id)
        {
            var r = await repository.GetObject(id);
            Assert.AreEqual(r.Data.ID, Constants.Unspecified);
        }
        protected override async Task validateEntityInRepository(object o) {
            var expected = o as CountryView;
            var actual = await repository.GetObject(expected?.Alpha3Code);
            Assert.IsNotNull(expected);
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Alpha3Code, actual.Data.ID);
            Assert.AreEqual(expected.Alpha2Code, actual.Data.Code);
            Assert.AreEqual(expected.Name, actual.Data.Name);
            validateDates(expected.ValidFrom, actual.Data.ValidFrom);
            validateDates(expected.ValidTo, actual.Data.ValidTo);
        }

        protected override IEnumerable<KeyValuePair<string, string>> createHttpPostContext(object o) {
            var c = o as CountryView;
            var d = new Dictionary<string, string> {
                {GetMember.Name<CountryView>(m => m.Alpha3Code), c?.Alpha3Code},
                {GetMember.Name<CountryView>(m => m.Alpha2Code), c?.Alpha2Code},
                {GetMember.Name<CountryView>(m => m.Name), c?.Name},
                {GetMember.Name<CountryView>(m => m.ValidFrom), c?.ValidFrom.ToString()},
                {GetMember.Name<CountryView>(m => m.ValidTo), c?.ValidTo.ToString()}
            };
            return d;
        }
        protected override object createRandomViewModel() {
            var r = GetRandom.Object<CountryView>();
            r.Alpha3Code = GetRandom.String(3, 3).ToUpper();
            r.Alpha2Code = GetRandom.String(2, 2).ToUpper();
            r.Name = GetRandom.String(1, 1).ToUpper() + GetRandom.String();
            r.ValidTo = GetRandom.DateTime(r.ValidFrom);
            return r;
        }
        protected override List<string> specificStringsToTestInIndexView()
        {
            return new List<string> {
                "<h2>Countries</h2>",
                "<a href=\"/countries/Create\">Create New</a>",
                "ISO Three Character Code",
                "ISO Two Character Code",
                "Name",
                "Valid From",
                "Valid To",
                "<th></th>",
                "<td>AFG</td>",
                "<td>AF</td>",
                "<td>Afghanistan</td>",
                "<a href=\"/countries/Edit/AFG\">Edit</a>",
                "<a href=\"/countries/Details/AFG\">Details</a>",
                "<a href=\"/countries/Delete/AFG\">Delete</a>"
            };
        }

        [TestMethod] public void CreateNoDatesTest() { Assert.Inconclusive(); }

        [TestMethod] public void CreateNoNameCodeOrIdTest() { Assert.Inconclusive(); }

        [TestMethod] public void CreateWhenIdAlreadyUseTest() { Assert.Inconclusive(); }



        [TestMethod] public void EditNoDates() { Assert.Inconclusive(); }

        [TestMethod] public void EditNoNameCodeOrId() { Assert.Inconclusive(); }

        [TestMethod] public void BackToListFromCreate() { Assert.Inconclusive(); }

        [TestMethod] public void BackToListFromEdit() { Assert.Inconclusive(); }

        [TestMethod] public void BackToListFromDetails() { Assert.Inconclusive(); }

        [TestMethod] public void BackToListFromDelete() { Assert.Inconclusive(); }

        [TestMethod] public void ToEditFromDetails() { Assert.Inconclusive(); }

        [TestMethod] public void PropertiesTest() {
            const string c = ", ";
            var b = new StringBuilder();
            b.Append(GetMember.Name<CountryView>(m => m.Alpha3Code));
            b.Append(c);
            b.Append(GetMember.Name<CountryView>(m => m.Alpha2Code));
            b.Append(c);
            b.Append(GetMember.Name<CountryView>(m => m.Name));
            b.Append(c);
            b.Append(GetMember.Name<CountryView>(m => m.ValidFrom));
            b.Append(c);
            b.Append(GetMember.Name<CountryView>(m => m.ValidTo));
            Assert.AreEqual(b.ToString(), CountriesController.properties);
        }

    }
}





