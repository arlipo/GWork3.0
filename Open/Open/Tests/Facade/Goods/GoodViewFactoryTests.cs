using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Goods;
using Open.Domain.Goods;
using Open.Facade.Goods;

namespace Open.Tests.Facade.Goods
{
    [TestClass]
    public class GoodViewFactoryTests : BaseTests
    {
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(GoodViewFactory);
        }

        [TestMethod] public void CreateTest() {
            var r = GetRandom.Object<GoodsData>();
            var o = new Good(r);
            var v = GoodViewFactory.Create(o);
            Assert.AreEqual(v.Name, o.Data.Name);
            Assert.AreEqual(v.ValidFrom, o.Data.ValidFrom);
            Assert.AreEqual(v.ValidTo, o.Data.ValidTo);
            Assert.AreEqual(v.ID, o.Data.ID);
            Assert.AreEqual(v.Price, o.Data.Price);
            Assert.AreEqual(v.ImgData, o.Data.ImgData);
            Assert.AreEqual(v.ImgName, o.Data.ImgName);
            Assert.AreEqual(v.Type, o.Data.Type);
            Assert.AreEqual(v.Description, o.Data.Description);
            Assert.AreEqual(v.Code, o.Data.Code);
        }
    }
}
