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
namespace Open.Tests.Sentry.Controllers {
    [TestClass]
    public class
        RateTypesControllerTests : BaseControllerTests<RateTypesController, RateType, RateTypeData
        > {
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            repository = new RateTypesRepository(db);
            controller = "ratetypes";
            detailsViewCaption = "Exchange Rate Type";
        }
        protected override List<string> specificStringsToTestInIndexView() {
            return new List<string> {
                "<h2>Exchange Rate Types</h2>",
                "<a href=\"/ratetypes/Create\">Create New</a>",
                "<th><a href=\"/ratetypes?SortOrder=id\">ID</a></th>",
                "<th><a href=\"/ratetypes?SortOrder=code\">Code</a></th>",
                "<th><a href=\"/ratetypes?SortOrder=name_desc\">Name</a></th>",
                "<th><a href=\"/ratetypes?SortOrder=descr\">Description</a></th>",
                "<th><a href=\"/ratetypes?SortOrder=validFrom\">Valid From</a></th>",
                "<th><a href=\"/ratetypes?SortOrder=validTo\">Valid To</a></th>",
                "<th></th>"
            };
        }
        protected override string createDbRecord() {
            var r = GetRandom.Object<RateTypeData>();
            db.RateTypes.Add(r);
            db.SaveChanges();
            specificStringsToTestInView = new List<string> {
                $"{r.Code}",
                $"{r.Name}",
                $"{r.Description}"
            };
            editViewCaption = $"Exchange Rate Type ({r.ID})";
            return r.ID;
        }
        protected override async Task isNotInRepository(string id) {
            var r = await repository.GetObject(id);
            Assert.AreEqual(r.Data.ID, Constants.Unspecified);
        }
        protected override async Task validateEntityInRepository(object o) {
            var expected = o as RateTypeView;
            var actual = await repository.GetObject(expected?.ID);
            Assert.IsNotNull(expected);
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.ID, actual.Data.ID);
            Assert.AreEqual(expected.Code, actual.Data.Code);
            Assert.AreEqual(expected.Name, actual.Data.Name);
            Assert.AreEqual(expected.Description, actual.Data.Description);
            validateDates(expected.ValidFrom, actual.Data.ValidFrom);
            validateDates(expected.ValidTo, actual.Data.ValidTo);
        }
        protected override IEnumerable<KeyValuePair<string, string>>
            createHttpPostContext(object o) {
            var c = o as RateTypeView;
            var d = new Dictionary<string, string> {
                {GetMember.Name<RateTypeView>(m => m.ID), c?.ID},
                {GetMember.Name<RateTypeView>(m => m.Code), c?.Code},
                {GetMember.Name<RateTypeView>(m => m.Description), c?.Description},
                {GetMember.Name<RateTypeView>(m => m.Name), c?.Name},
                {GetMember.Name<RateTypeView>(m => m.ValidFrom), c?.ValidFrom.ToString()},
                {GetMember.Name<RateTypeView>(m => m.ValidTo), c?.ValidTo.ToString()}
            };
            return d;
        }
        protected override object createRandomViewModel() {
            var v = GetRandom.Object<RateTypeView>();
            v.ID = GetRandom.String(3).ToUpper();
            v.Name = GetRandom.String(1, 1).ToUpper() + GetRandom.String();
            v.Description = GetRandom.String(1, 1).ToUpper() + GetRandom.String();
            v.ValidTo = GetRandom.DateTime(v.ValidFrom);
            return v;
        }
    }
}
