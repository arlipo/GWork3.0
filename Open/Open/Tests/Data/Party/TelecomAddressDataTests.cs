using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Party;
namespace Open.Tests.Data.Party {
    [TestClass] public class TelecomAddressDataTests : ObjectTests<TelecomAddressData> {
        protected override TelecomAddressData getRandomObject() {
            return GetRandom.Object<TelecomAddressData>();
        }

        [TestMethod] public void IsInstanceOfAddressDbRecord() {
            Assert.AreEqual(typeof(AddressData), obj.GetType().BaseType);
        }
        [TestMethod] public void NationalDirectDialingPrefixTest() {
            canReadWrite(() => obj.NationalDirectDialingPrefix,
                x => obj.NationalDirectDialingPrefix = x);
        }
        [TestMethod] public void DeviceTest() {
            canReadWrite(() => obj.Device, x => obj.Device = x);
        }
    }
}



