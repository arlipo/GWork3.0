using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Common;
using Open.Facade.Quantity;
namespace Open.Tests.Facade.Quantity {
    [TestClass] public class RateTypeViewTests : ViewTests<RateTypeView, NamedView> {
        protected override RateTypeView getRandomObject() { return GetRandom.Object<RateTypeView>(); }

        [TestMethod] public void IDTest() {
            canReadWrite(() => obj.ID, x => obj.ID = x);
        }
        [TestMethod] public void CodeTest() {
            canReadWrite(() => obj.Code, x => obj.Code = x);
        }
        [TestMethod] public void DescriptionTest() {
            canReadWrite(() => obj.Description, x => obj.Description = x);
        }
    }
}