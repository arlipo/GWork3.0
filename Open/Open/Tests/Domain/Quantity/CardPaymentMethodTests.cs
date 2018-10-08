using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Quantity;
using Open.Domain.Quantity;
namespace Open.Tests.Domain.Quantity {
    [TestClass] public class CardPaymentMethodTests : EntityBaseTests<CardPaymentMethod<CreditCardData>, CreditCardData>
    {
        class testClass : CardPaymentMethod<CreditCardData> {
            public testClass(CreditCardData data) : base(data) { }
        }
        protected override CardPaymentMethod<CreditCardData> getRandomObject(){
            createdWithNullArg = new testClass(null);
            dbRecordType = typeof(CreditCardData);
            return GetRandom.Object<testClass>();
        }

        [TestMethod] public void DailyLimitTest()
        {
            Assert.AreEqual(obj.DailyLimit.Amount, obj.Data.DailyLimit);
            Assert.AreEqual(obj.DailyLimit.Currency.ID, obj.Data.Currency.ID);
        }
    }
}