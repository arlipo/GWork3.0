using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Domain.Quantity;
using Open.Facade.Quantity;
namespace Open.Tests.Facade.Quantity {
    [TestClass] public class RateTypeViewsListTests : ObjectTests<RateTypeViewsList> {
        protected override RateTypeViewsList getRandomObject() {
            var l = new RateTypeList(null, null);
            SetRandom.Values(l);
            return new RateTypeViewsList(l);
        }

        [TestMethod] public void CanCreateWithNullArgumentTest() {
            Assert.IsNotNull(new RateTypeViewsList(null));
        }
    }
}