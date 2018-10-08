using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Quantity;
namespace Open.Tests.Facade.Quantity {
    [TestClass] public class CreditCardViewTests : ViewTests<CreditCardView, PaymentCardView> {
        protected override CreditCardView getRandomObject() {
            return GetRandom.Object<CreditCardView>();
        }
        [TestMethod] public void CreditLimitTest() {
            canReadWrite(() => obj.CreditLimit, x => obj.CreditLimit = x);
        }
        [TestMethod]
        public void ToStringTest()
        {
            var s = $"Credit Card ({obj.CardName}, {obj.CardNumber})";
            Assert.AreEqual(s, obj.ToString());
        }
    }
}