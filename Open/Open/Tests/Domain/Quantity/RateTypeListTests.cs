using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Quantity;
using Open.Domain.Quantity;
namespace Open.Tests.Domain.Quantity {
    [TestClass] public class RateTypeListTests : ListBaseTests<RateTypeList, RateType>
    {
        protected override RateTypeList getRandomObject() {
            createWithNullArgs = new RateTypeList(null, null);
            var l = GetRandom.Object<List<RateTypeData>>();
            return new RateTypeList(l, GetRandom.Object<RepositoryPage>());
        }
    }
}