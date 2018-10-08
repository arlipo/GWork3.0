using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Quantity;
namespace Open.Tests.Facade.Quantity {
    [TestClass] public class DebitCardViewTests : ViewTests<DebitCardView, PaymentCardView> {
        protected override DebitCardView getRandomObject() {
            return GetRandom.Object<DebitCardView>();
        }
        [TestMethod]
        public void ToStringTest()
        {
            var s = $"Debit Card ({obj.CardName}, {obj.CardNumber})";
            Assert.AreEqual(s, obj.ToString());
        }
    }
}