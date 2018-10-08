using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Party;
using Open.Domain.Party;
namespace Open.Tests.Domain.Party {
    [TestClass]
    public class TelecomAddressTests : EntityBaseTests<TelecomAddress, TelecomAddressData> {
        protected override TelecomAddress getRandomObject() {
            createdWithNullArg = new TelecomAddress(null);
            dbRecordType = typeof(TelecomAddressData);
            return GetRandom.Object<TelecomAddress>();
        }
        [TestMethod] public void RegisteredInAddressesTest() {
            Assert.IsNotNull(obj.RegisteredInAddresses);
            Assert.IsInstanceOfType(obj.RegisteredInAddresses,
                typeof(IReadOnlyList<GeographicAddress>));
        }

        [TestMethod] public void RegisteredInAddressTest() {
            var address = GetRandom.Object<GeographicAddress>();
            Assert.IsFalse(obj.RegisteredInAddresses.Contains(address));
            obj.RegisteredInAddress(address);
            Assert.IsTrue(obj.RegisteredInAddresses.Contains(address));
        }
    }
}





