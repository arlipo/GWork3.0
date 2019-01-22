using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Goods;
using Open.Domain.Goods;

namespace Open.Tests.Domain.Goods
{
    [TestClass]
    public class GoodsListTests : ListBaseTests<GoodsList, Good>
    {
        protected override GoodsList getRandomObject()
        {
            createWithNullArgs = new GoodsList(null, null);
            var l = GetRandom.Object<List<GoodsData>>();
            return new GoodsList(l, GetRandom.Object<RepositoryPage>());
        }
    }
}