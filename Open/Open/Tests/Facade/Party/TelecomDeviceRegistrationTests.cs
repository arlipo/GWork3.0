using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Domain.Party;
namespace Open.Tests.Facade.Party {

    [TestClass]
    public class
        TelecomDeviceRegistrationTests : ObjectTests<TelecomDeviceRegistration> {

        protected override TelecomDeviceRegistration getRandomObject() {
            return GetRandom.Object<TelecomDeviceRegistration>();
        }

        [TestMethod] public void AddressTest() {
            Assert.AreEqual(obj.Address.Data, obj.Data.Address);
        }

        [TestMethod] public void DeviceTest() {
            Assert.AreEqual(obj.Device.Data, obj.Data.Device);
        }

        [TestMethod] public void WhenCreatedWithNullArgumentsTest() {
            obj = new TelecomDeviceRegistration(null);
            Assert.AreEqual(obj.Address.Data, obj.Data.Address);
            Assert.AreEqual(obj.Device.Data, obj.Data.Device);
        }

    }
}






