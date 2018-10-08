using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Quantity;
namespace Open.Tests.Facade.Quantity {
    [TestClass] public class CashViewTests: ViewTests<CashView, PaymentMethodView> {
        protected override CashView getRandomObject() {
            return GetRandom.Object<CashView>();
        }
        [TestMethod] public void ToStringTest() {
            Assert.AreEqual("Cash", obj.ToString());
        }
    }
}