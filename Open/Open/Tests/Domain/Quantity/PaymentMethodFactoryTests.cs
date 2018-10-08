using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Quantity;
using Open.Domain.Quantity;
namespace Open.Tests.Domain.Quantity {
    [TestClass] public class PaymentMethodFactoryTests : BaseTests {
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(PaymentMethodFactory);
        }

        [TestMethod]
        public void CreateCheckTest()
        {
            var r = GetRandom.Object<CheckData>();
            var o = PaymentMethodFactory.Create(r) as Check;
            Assert.IsInstanceOfType(o, typeof(Check));
            Assert.AreEqual(r, o?.Data);
            Assert.AreEqual(r.ID, o?.ID);
        }
        [TestMethod]
        public void CreateCreditCardTest()
        {
            var r = GetRandom.Object<CreditCardData>();
            var o = PaymentMethodFactory.Create(r) as CreditCard;
            Assert.IsInstanceOfType(o, typeof(CreditCard));
            Assert.AreEqual(r, o?.Data);
            Assert.AreEqual(r.ID, o?.ID);
        }
        [TestMethod]
        public void CreateDebitCardTest()
        {
            var r = GetRandom.Object<DebitCardData>();
            var o = PaymentMethodFactory.Create(r) as DebitCard;
            Assert.IsInstanceOfType(o, typeof(DebitCard));
            Assert.AreEqual(r, o?.Data);
            Assert.AreEqual(r.ID, o?.ID);
        }
        [TestMethod]
        public void CreateTest()
        {
            var o = PaymentMethodFactory.Create(null) as Cash;
            Assert.IsInstanceOfType(o, typeof(Cash));
        }
    }
}