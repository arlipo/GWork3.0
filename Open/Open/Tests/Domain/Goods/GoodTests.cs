using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Goods;
using Open.Domain.Goods;

namespace Open.Tests.Domain.Goods
{
    [TestClass]
    public class GoodTests : EntityBaseTests<Good, GoodsData>
    {
        protected override Good getRandomObject()
        {
            createdWithNullArg = new Good(null);
            dbRecordType = typeof(GoodsData);
            return GetRandom.Object<Good>();
        }
    }
}