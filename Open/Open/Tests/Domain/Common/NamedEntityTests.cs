using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Common;
using Open.Data.Party;
using Open.Domain.Common;
namespace Open.Tests.Domain.Common {
    [TestClass]
    public class NamedEntityTests : EntityBaseTests<NamedEntity<CountryData>, CountryData> {
        class testClass : NamedEntity<CountryData> {
            public testClass(CountryData dbRecord) : base(dbRecord) { }
        }
        protected override NamedEntity<CountryData> getRandomObject() {
            createdWithNullArg = new testClass(null);
            dbRecordType = typeof(NamedData);
            return GetRandom.Object<testClass>();
        }

    }
}



