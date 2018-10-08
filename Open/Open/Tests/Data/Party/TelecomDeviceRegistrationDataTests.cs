using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Party;
namespace Open.Tests.Data.Party {

    [TestClass]
    public class
        TelecomDeviceRegistrationDataTests : ObjectTests<TelecomDeviceRegistrationData> {
        protected override TelecomDeviceRegistrationData getRandomObject() {
            return GetRandom.Object<TelecomDeviceRegistrationData>();
        }
        [TestMethod] public void DeviceIDTest() {
            canReadWrite(() => obj.DeviceID, x => obj.DeviceID = x);
            allowNullEmptyAndWhitespace(() => obj.DeviceID, x => obj.DeviceID = x,
                () => Constants.Unspecified);
        }
        [TestMethod] public void AddressIDTest() {
            canReadWrite(() => obj.AddressID, x => obj.AddressID = x);
            allowNullEmptyAndWhitespace(() => obj.AddressID, x => obj.AddressID = x,
                () => Constants.Unspecified);
        }
        [TestMethod] public void DeviceTest() {
            canReadWrite(() => obj.Device, x => obj.Device = x);
            obj.Device = null;
            Assert.IsNull(obj.Device);
        }
        [TestMethod] public void AddressTest() {
            canReadWrite(() => obj.Address, x => obj.Address = x);
            obj.Address = null;
            Assert.IsNull(obj.Address);
        }

    }
}


