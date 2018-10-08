using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Party;
namespace Open.Tests.Facade.Party {

    [TestClass] public class EMailAddressViewTests : ObjectTests<EMailAddressView> {

        protected override EMailAddressView getRandomObject() {
            return GetRandom.Object<EMailAddressView>();
        }

        [TestMethod] public void IsAddressViewModelTest() {
            Assert.AreEqual(obj.GetType().BaseType, typeof(AddressView));
        }

        [TestMethod] public void EmailAddressTest() {
            canReadWrite(() => obj.EmailAddress, x => obj.EmailAddress = x);
        }
        [TestMethod] public void ToStringTest() {
            Assert.AreEqual(obj.EmailAddress, obj.ToString());
        }

    }
}

