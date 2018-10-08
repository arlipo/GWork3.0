using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Domain.Quantity;
using Open.Facade.Quantity;
namespace Open.Tests.Facade.Quantity {
    [TestClass] public class RateViewsListTests : ObjectTests<RateViewsList> {
        protected override RateViewsList getRandomObject() {
            var l = new RatesList(null, null);
            SetRandom.Values(l);
            return new RateViewsList(l);
        }

        [TestMethod] public void CanCreateWithNullArgumentTest() {
            Assert.IsNotNull(new RateViewsList(null));
        }
    }
}