using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Common;
using Open.Data.Party;
namespace Open.Tests.Data.Party {
    [TestClass] public class CountryDataTests : ObjectTests<CountryData> {
        protected override CountryData getRandomObject() {
            return GetRandom.Object<CountryData>();
        }
        [TestMethod] public void BaseTypeIsIdentifiedDbRecord() {
            Assert.AreEqual(typeof(NamedData), typeof(CountryData).BaseType);
        }

        [TestMethod] public void ContainsTest() {
            Assert.IsFalse(obj.Contains(GetRandom.String()));
            Assert.IsTrue(obj.Contains(string.Empty));
            Assert.IsTrue(obj.Contains(null));
            Assert.IsTrue(obj.Contains(obj.ID));
            Assert.IsTrue(obj.Contains(obj.Name));
            Assert.IsTrue(obj.Contains(obj.Code));
            Assert.IsTrue(obj.Contains(obj.ValidFrom.Year.ToString()));
            Assert.IsTrue(obj.Contains(obj.ValidFrom.Day.ToString()));
            Assert.IsTrue(obj.Contains(obj.ValidFrom.Month.ToString()));
            Assert.IsTrue(obj.Contains(obj.ValidTo.Year.ToString()));
            Assert.IsTrue(obj.Contains(obj.ValidTo.Day.ToString()));
            Assert.IsTrue(obj.Contains(obj.ValidTo.Month.ToString()));
        }
    }
}




