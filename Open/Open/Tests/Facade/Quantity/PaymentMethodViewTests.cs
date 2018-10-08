using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Common;
using Open.Facade.Quantity;
namespace Open.Tests.Facade.Quantity {
    [TestClass] public class PaymentMethodViewTests : ObjectTests<PaymentMethodView> {
        private class testView : PaymentMethodView {
            private string content { get; } = GetRandom.String();
            public override string ToString() {
                return content;
            }
        }
        protected override PaymentMethodView getRandomObject() {
            return GetRandom.Object<testView>();
        }
        [TestMethod] public void IsAbstract() {
            Assert.IsTrue(typeof(PaymentMethodView).IsAbstract);
        }
        [TestMethod] public void BaseTypeIsUniqueDbRecord() {
            Assert.AreEqual(typeof(EntityView), typeof(PaymentMethodView).BaseType);
        }
        [TestMethod] public void ContentTest() {
            Assert.AreEqual(obj.Content, obj.ToString());
        }
        [TestMethod] public void PaymentTypeTest() {
            Assert.AreEqual("test", obj.PaymentType);
        }
    }
}