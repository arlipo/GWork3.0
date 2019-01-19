using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Common;
using Open.Facade.Goods;

namespace Open.Tests.Facade.Goods
{
    [TestClass]
    public class GoodViewTests : ViewTests<GoodView, EntityView>
    {
        protected override GoodView getRandomObject()
        {
            return GetRandom.Object<GoodView>();
        }

        [TestMethod]
        public void NameTest()
        {
            canReadWrite(() => obj.Name, x => obj.Name = x);
        }

        [TestMethod]
        public void CodeTest()
        {
            canReadWrite(() => obj.Code, x => obj.Code = x);
        }

        [TestMethod]
        public void TypeTest()
        {
            canReadWrite(() => obj.Type, x => obj.Type = x);
        }

        [TestMethod]
        public void ImgDataTest()
        {
            canReadWrite(() => obj.ImgData, x => obj.ImgData = x);
        }

        [TestMethod]
        public void ImgNameTest()
        {
            canReadWrite(() => obj.ImgName, x => obj.ImgName = x);
        }

        [TestMethod]
        public void DescriptionTest()
        {
            canReadWrite(() => obj.Description, x => obj.Description = x);
        }

        [TestMethod]
        public void PriceTest()
        {
            canReadWrite(() => obj.Price, x => obj.Price = x);
        }
    }
}
