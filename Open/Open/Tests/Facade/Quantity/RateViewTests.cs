using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Common;
using Open.Facade.Quantity;
namespace Open.Tests.Facade.Quantity {
    [TestClass] public class RateViewTests : ViewTests<RateView, PeriodView> {
        protected override RateView getRandomObject() {
            return GetRandom.Object<RateView>();
        }
        [TestMethod] public void RateTest() {
            canReadWrite(() => obj.Rate, x => obj.Rate = x);
        }
        [TestMethod] public void IDTest() {
            canReadWrite(() => obj.ID, x => obj.ID = x);
        }
        [TestMethod] public void CurrencyIDTest() {
            canReadWrite(() => obj.CurrencyID, x => obj.CurrencyID = x);
        }

        [TestMethod] public void RateTypeIDTest() {
            canReadWrite(() => obj.RateTypeID, x => obj.RateTypeID = x);
        }

    }
}