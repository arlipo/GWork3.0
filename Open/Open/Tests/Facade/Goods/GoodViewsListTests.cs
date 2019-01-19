using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Domain.Goods;
using Open.Facade.Goods;

namespace Open.Tests.Facade.Goods
{
    [TestClass]
    public class GoodViewsListTests : ObjectTests<GoodViewsList>
    {
        protected override GoodViewsList getRandomObject() {
            var l = new GoodsList(null, null);
            SetRandom.Values(l);
            return new GoodViewsList(l);
        }

        [TestMethod] public void CanCreateWithNullArgumentTest() {
            Assert.IsNotNull(new GoodViewsList(null));
        }
    }
}
