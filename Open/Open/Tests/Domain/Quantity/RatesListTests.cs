using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Quantity;
using Open.Domain.Quantity;
namespace Open.Tests.Domain.Quantity{
    [TestClass] public class RatesListTests : ListBaseTests<RatesList, Rate> {
        protected override RatesList getRandomObject() {
            createWithNullArgs = new RatesList(null, null);
            var l = GetRandom.Object<List<RateData>>();
            return new RatesList(l, GetRandom.Object<RepositoryPage>());
        }
    }
}