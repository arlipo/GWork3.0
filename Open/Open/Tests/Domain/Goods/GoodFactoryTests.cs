using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Goods;
using Open.Domain.Goods;

namespace Open.Tests.Domain.Goods
{
    [TestClass]
    public class GoodFactoryTests : BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(GoodFactory);
        }

        [TestMethod]
        public void CreateTest()
        {
            var r = GetRandom.Object<GoodsData>();

            var o = GoodFactory.Create(r.ID, r.Name, r.Code, r.Description, r.Price, r.Type, r.ImgData,
                r.ImgName, r.ValidFrom, r.ValidTo);

            Assert.AreEqual(r.Name, o.Data.Name);
            Assert.AreEqual(r.ID, o.Data.ID);
            Assert.AreEqual(r.Description, o.Data.Description);
            Assert.AreEqual(r.Code, o.Data.Code);
            Assert.AreEqual(r.Price, o.Data.Price);
            Assert.AreEqual(r.Type, o.Data.Type);
            Assert.AreEqual(r.ImgData, o.Data.ImgData);
            Assert.AreEqual(r.ImgName, o.Data.ImgName);
            Assert.AreEqual(r.ValidFrom, o.Data.ValidFrom);
            Assert.AreEqual(r.ValidTo, o.Data.ValidTo);
        }

        [TestMethod]
        public void CreateWithNullTest()
        {
            var o = GoodFactory.Create(null);
            Assert.IsNotNull(o);
        }
    }
}