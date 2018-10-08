using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Quantity;
using Open.Domain.Quantity;
namespace Open.Tests.Domain.Quantity {
    [TestClass] public class CurrenciesListTests : ListBaseTests<CurrenciesList, Currency> {
        protected override CurrenciesList getRandomObject() {
            createWithNullArgs = new CurrenciesList(null, null);
            var l = GetRandom.Object<List<CurrencyData>>();
            return new CurrenciesList(l, GetRandom.Object<RepositoryPage>());
        }
    }
}