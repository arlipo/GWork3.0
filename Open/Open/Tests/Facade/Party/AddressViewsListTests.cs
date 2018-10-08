using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Party;
using Open.Domain.Party;
using Open.Facade.Party;
namespace Open.Tests.Facade.Party {
    [TestClass] public class AddressViewsListTests : ObjectTests<AddressViewsList> {
        protected override AddressViewsList getRandomObject() {
            var l = new AddressesList(getRandomAddressDbRecordsList(),
                GetRandom.Object<RepositoryPage>());
            SetRandom.Values(l);
            return new AddressViewsList(l);
        }
        private IEnumerable<AddressData> getRandomAddressDbRecordsList() {
            var l = new List<AddressData>();
            for (var i = 0; i < GetRandom.UInt8(5, 10); i++) {
                var x = i % 4;
                if (x == 0) l.Add(GetRandom.Object<WebPageAddressData>());
                if (x == 1) l.Add(GetRandom.Object<EmailAddressData>());
                if (x == 2) l.Add(GetRandom.Object<TelecomAddressData>());
                if (x == 3) l.Add(GetRandom.Object<GeographicAddressData>());
            }

            return l;
        }
        [TestMethod] public void CanCreateWithNullArgumentTest() {
            Assert.IsNotNull(new CountryViewsList(null));
        }

    }
}

