using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Common;
namespace Open.Tests.Facade.Common {
    [TestClass] public class EntityViewTests : ObjectTests<EntityView> {
        protected override EntityView getRandomObject() {
            return GetRandom.Object<EntityView>();
        }

        [TestMethod] public void IsPeriodViewTest() {
            Assert.AreEqual(obj.GetType().BaseType, typeof(PeriodView));
        }

        [TestMethod] public void IDTest() {
            canReadWrite(() => obj.ID, x => obj.ID = x);
        }
    }
}




