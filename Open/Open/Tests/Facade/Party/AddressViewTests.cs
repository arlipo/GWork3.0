using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Common;
using Open.Facade.Party;
namespace Open.Tests.Facade.Party {
    [TestClass] public class AddressViewTests : ObjectTests<AddressView> {

        private class testClass : AddressView { }

        protected override AddressView getRandomObject() {
            return GetRandom.Object<testClass>();
        }

        [TestMethod] public void IsUniqueEntityViewModelTest() {
            Assert.AreEqual(obj.GetType().BaseType.BaseType, typeof(EntityView));
        }
        [TestMethod] public void AddressTypeTest() {
            Assert.AreEqual("testClass", obj.AddressType);
            Assert.AreEqual("WebPage", new WebPageAddressView().AddressType);
            Assert.AreEqual("EMail", new EMailAddressView().AddressType);
            Assert.AreEqual("Geographic", new GeographicAddressView().AddressType);
            Assert.AreEqual("Telecom", new TelecomAddressView().AddressType);
        }
        [TestMethod] public void ContactTest() {
            Assert.AreEqual(obj.Contact, obj.ToString());
        }
    }
}







