using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Common;
using Open.Data.Party;
using Open.Domain.Common;
namespace Open.Tests.Domain.Common {
    [TestClass] public class PeriodTests : EntityBaseTests<Period<CountryData> , CountryData> {
        class testClass : Period<CountryData> {
            public testClass(CountryData dbRecord) : base(dbRecord) { }
        }
        protected override Period<CountryData> getRandomObject() {
            dbRecordType = typeof(PeriodData);
            createdWithNullArg = new testClass(null);
            return GetRandom.Object<testClass>();
        }
    }
}

