using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
namespace Open.Tests.Core {
    [TestClass] public class TelecomDeviceTests : ClassTests<TelecomDevice> {
        [TestMethod] public void CountTest() {
            Assert.AreEqual(5, GetEnum.Count<TelecomDevice>());
        }

        [TestMethod] public void NotKnownTest() =>
            Assert.AreEqual(0, (int) TelecomDevice.NotKnown);

        [TestMethod] public void PhoneTest() =>
            Assert.AreEqual(1, (int) TelecomDevice.Phone);

        [TestMethod] public void FaxTest() =>
            Assert.AreEqual(2, (int) TelecomDevice.Fax);

        [TestMethod] public void MobileTest() =>
            Assert.AreEqual(3, (int) TelecomDevice.Mobile);

        [TestMethod] public void PagerTest() =>
            Assert.AreEqual(4, (int) TelecomDevice.Pager);
    }

}


