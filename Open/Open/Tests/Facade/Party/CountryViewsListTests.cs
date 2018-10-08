using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Domain.Party;
using Open.Facade.Party;
namespace Open.Tests.Facade.Party {

    [TestClass] public class CountryViewsListTests : ObjectTests<CountryViewsList> {
        protected override CountryViewsList getRandomObject() {
            var l = new CountriesList(null, null);
            SetRandom.Values(l);
            return new CountryViewsList(l);
        }

        [TestMethod] public void CanCreateWithNullArgumentTest() {
            Assert.IsNotNull(new CountryViewsList(null));
        }

    }
}



