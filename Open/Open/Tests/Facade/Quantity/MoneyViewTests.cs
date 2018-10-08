using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Common;
using Open.Facade.Quantity;
namespace Open.Tests.Facade.Quantity {
    [TestClass] public class MoneyViewTests : ViewTests<MoneyView, PeriodView> {
        protected override MoneyView getRandomObject() {
            return GetRandom.Object<MoneyView>();
        }
        [TestMethod] public void AmountTest() {
            canReadWrite(() => obj.Amount, x => obj.Amount = x);
        }

        [TestMethod] public void CurrencyIDTest() {
            canReadWrite(() => obj.CurrencyID, x => obj.CurrencyID = x);
        }

    }
}