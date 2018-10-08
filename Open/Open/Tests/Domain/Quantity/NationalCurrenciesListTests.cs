using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Quantity;
using Open.Domain.Quantity;
namespace Open.Tests.Domain.Quantity {
    [TestClass] public class NationalCurrenciesListTests : ListBaseTests<NationalCurrenciesList, NationalCurrency> {
        protected override NationalCurrenciesList getRandomObject() {
            createWithNullArgs = new NationalCurrenciesList(null, null);
            var l = GetRandom.Object<List<NationalCurrencyData>>();
            return new NationalCurrenciesList(l, GetRandom.Object<RepositoryPage>());
        }
    }
}