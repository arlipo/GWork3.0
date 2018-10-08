using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Facade.Party;
namespace Open.Tests.Facade.Party {
    [TestClass] public class TelecomAddressViewTests : ObjectTests<TelecomAddressView> {
        protected override TelecomAddressView getRandomObject() {
            return GetRandom.Object<TelecomAddressView>();
        }
        [TestMethod] public void IsAddressViewModelTest() {
            Assert.AreEqual(obj.GetType().BaseType, typeof(AddressView));
        }
        [TestMethod] public void CountryCodeTest() {
            canReadWrite(()=>obj.CountryCode, x => obj.CountryCode = x);
        }
        [TestMethod] public void AreaCodeTest() {
            canReadWrite(() => obj.AreaCode, x => obj.AreaCode = x);
        }
        [TestMethod] public void NumberTest() {
            canReadWrite(() => obj.Number, x => obj.Number = x);
        }
        [TestMethod] public void ExtensionTest() {
            canReadWrite(() => obj.Extension, x => obj.Extension = x);
        }
        [TestMethod] public void NationalDirectDialingPrefixTest() {
            canReadWrite(() => obj.NationalDirectDialingPrefix, x => obj.NationalDirectDialingPrefix = x);
        }
        [TestMethod] public void DeviceTypeTest() {
            canReadWrite(() => obj.DeviceType, x => obj.DeviceType = x);
        }
        [TestMethod] public void RegisteredInAddressesTest() {
            Assert.IsInstanceOfType(obj.RegisteredInAddresses,
                typeof(List<GeographicAddressView>));
            var name =
                GetMember.Name<TelecomAddressView>(x => x.RegisteredInAddresses);
            Assert.IsTrue(IsReadOnly.Property<TelecomAddressView>(name));
        }
        [TestMethod]
        public void ToStringTest()
        {
            var s = obj.Number;
            if (obj.AreaCode != Constants.Unspecified) s = $"{obj.AreaCode} {s}";
            if (obj.NationalDirectDialingPrefix != Constants.Unspecified) s = $"({obj.NationalDirectDialingPrefix}){s}";
            if (obj.CountryCode != Constants.Unspecified) s = $"{obj.CountryCode} {s}";
            if (obj.Extension != Constants.Unspecified) s = $"{s} ext. {obj.Extension}";
            Assert.AreEqual(s, obj.ToString());
        }
    }
}




