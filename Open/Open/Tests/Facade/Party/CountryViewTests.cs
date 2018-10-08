using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Common;
using Open.Facade.Party;
using Open.Facade.Quantity;
namespace Open.Tests.Facade.Party {

    [TestClass]
    public class CountryViewTests : ViewTests<CountryView, NamedView> {
        protected override CountryView getRandomObject() {
            return GetRandom.Object<CountryView>();
        }

        [TestMethod] public void Alpha3CodeTest() {
            canReadWrite(() => obj.Alpha3Code, x => obj.Alpha3Code = x);
        }
        [TestMethod] public void Alpha2CodeTest() {
            canReadWrite(() => obj.Alpha2Code, x => obj.Alpha2Code = x);
        }
        [TestMethod] public void CurrenciesInUseTest() {
            Assert.IsInstanceOfType(obj.CurrenciesInUse, typeof(List<CurrencyView>));
            var name = GetMember.Name<CountryView>(x => x.CurrenciesInUse);
            Assert.IsTrue(IsReadOnly.Property<CountryView>(name));
        }
    }
}






