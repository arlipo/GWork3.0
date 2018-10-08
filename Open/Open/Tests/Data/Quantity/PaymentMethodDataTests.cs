using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Common;
using Open.Data.Quantity;
namespace Open.Tests.Data.Quantity {
    [TestClass] public class PaymentMethodDataTests : ObjectTests<PaymentMethodData> {
        private class testClass : PaymentMethodData { }

        protected override PaymentMethodData getRandomObject() {
            return GetRandom.Object<testClass>();
        }

        [TestMethod] public void ConstructorTest() {
            Assert.AreEqual(obj.GetType().BaseType.BaseType, typeof(IdentifiedData));
        }
        [TestMethod] public void CodeTest() {
            canReadWrite(() => obj.Code, x => obj.Code = x);
        }
        [TestMethod] public void IssueTest() {
            canReadWrite(() => obj.Issue, x => obj.Issue = x);
        }

        [TestMethod]
        public void AddressTest() {
            canReadWrite(() => obj.Address, x => obj.Address = x);
        }
        [TestMethod]
        public void NumberTest() {
            canReadWrite(() => obj.Number, x => obj.Number = x);
        }
        [TestMethod]
        public void NameTest() {
            canReadWrite(() => obj.Name, x => obj.Name = x);
        }
        [TestMethod]
        public void OrganizationTest() {
            canReadWrite(() => obj.Organization, x => obj.Organization = x);
        }
        [TestMethod]
        public void DailyLimitTest() {
            canReadWrite(() => obj.DailyLimit, x => obj.DailyLimit = x);
        }
        [TestMethod]
        public void CurrencyIDTest() {
            canReadWrite(() => obj.CurrencyID, x => obj.CurrencyID = x);
        }
        [TestMethod]
        public void CurrencyTest() {
            canReadWrite(() => obj.Currency, x => obj.Currency = x);
        }
    }
}