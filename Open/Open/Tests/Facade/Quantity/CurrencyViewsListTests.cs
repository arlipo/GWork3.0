using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Domain.Quantity;
using Open.Facade.Quantity;
namespace Open.Tests.Facade.Quantity {
    [TestClass] public class CurrencyViewsListTests : ObjectTests<CurrencyViewsList> {
        protected override CurrencyViewsList getRandomObject() {
            var l = new CurrenciesList(null, null);
            SetRandom.Values(l);
            return new CurrencyViewsList(l);
        }

        [TestMethod] public void CanCreateWithNullArgumentTest() {
            Assert.IsNotNull(new CurrencyViewsList(null));
        }
    }
}