using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Common;
namespace Open.Tests.Facade.Common {
    [TestClass] public class NamedViewTests : ViewTests<NamedView, PeriodView> {
        class testClass : NamedView { }
        protected override NamedView getRandomObject() {
            return GetRandom.Object<testClass>();
        }
        [TestMethod] public void NameTest() {
            canReadWrite(() => obj.Name, x => obj.Name = x);
        }
    }
}



