using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Data.Common;
using Open.Data.Goods;

namespace Open.Tests.Data.Goods
{
    [TestClass]
    public class GoodsDataTests : ObjectTests<GoodsData>
    {
        [TestMethod]
        public void BaseTypeIsNamedData()
        {
            Assert.AreEqual(typeof(NamedData), typeof(GoodsData).BaseType);
        }

        [TestMethod]
        public void FileLocationTest()
        {
            canReadWrite(() => obj.PicFileLocation, x => obj.PicFileLocation = x);
        }

        [TestMethod]
        public void PriceTest()
        {
            canReadWrite(() => obj.Price, x => obj.Price = x);
        }

        [TestMethod]
        public void DescriptionTest()
        {
            canReadWrite(() => obj.Description, x => obj.Description = x);
        }

        [TestMethod]
        public void ImageTypeTest()
        {
            canReadWrite(() => obj.ImageType, x => obj.ImageType = x);
        }
    }
}