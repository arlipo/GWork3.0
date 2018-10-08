using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Party;
using Open.Domain.Party;
namespace Open.Tests.Domain.Party {
    [TestClass] public class CountriesListTests : ListBaseTests<CountriesList, Country> {
        protected override CountriesList getRandomObject() {
            createWithNullArgs = new CountriesList(null, null);
            var l = GetRandom.Object<List<CountryData>>();
            return new CountriesList(l, GetRandom.Object<RepositoryPage>());
        }
    }
}

