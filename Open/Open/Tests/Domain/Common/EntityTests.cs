using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Common;
using Open.Data.Party;
using Open.Domain.Common;
namespace Open.Tests.Domain.Common {
    [TestClass]
    public class
        EntityTests : EntityBaseTests<Entity<CountryData>, CountryData> {
        class testClass : Entity<CountryData> {
            public testClass(CountryData dbRecord) : base(dbRecord) { }
        }
        protected override Entity<CountryData> getRandomObject() {
            createdWithNullArg = new testClass(null);
            dbRecordType = typeof(IdentifiedData);
            return GetRandom.Object<testClass>();
        }

    }
}



