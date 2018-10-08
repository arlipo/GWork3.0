using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Party;
namespace Open.Tests.Facade.Party {
    [TestClass] public class WebPageAddressViewTests : ObjectTests<WebPageAddressView> {

        protected override WebPageAddressView getRandomObject() {
            return GetRandom.Object<WebPageAddressView>();
        }

        [TestMethod] public void IsAddressViewModelTest() {
            Assert.AreEqual(obj.GetType().BaseType, typeof(AddressView));
        }

        [TestMethod] public void UrlTest() {
            canReadWrite(() => obj.Url, x => obj.Url = x);
        }
        [TestMethod]
        public void ToStringTest()
        {
            Assert.AreEqual(obj.Url, obj.ToString());
        }

    }
}

