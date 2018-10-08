using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Common;
using Open.Facade.Party;
using Open.Facade.Quantity;
namespace Open.Tests.Facade.Quantity {
    [TestClass] public class CurrencyViewTests : ViewTests<CurrencyView, NamedView> {
        protected override CurrencyView getRandomObject() {
            return GetRandom.Object<CurrencyView>();
        }
        [TestMethod] public void IsoCodeTest() {
            canReadWrite(() => obj.IsoCode, x => obj.IsoCode = x);
        }
        [TestMethod] public void SymbolTest() {
            canReadWrite(() => obj.Symbol, x => obj.Symbol = x);
        }
        [TestMethod] public void UsedInCountriesTest() {
            Assert.IsInstanceOfType(obj.UsedInCountries, typeof(List<CountryView>));
            var name = GetMember.Name<CurrencyView>(o => obj.UsedInCountries);
            Assert.IsTrue(IsReadOnly.Property<CurrencyView>(name));
        }
    }
}