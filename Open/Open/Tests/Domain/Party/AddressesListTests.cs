using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Party;
using Open.Domain.Party;
namespace Open.Tests.Domain.Party
{
    [TestClass]
    public class AddressesListTests : ListBaseTests<AddressesList, IAddress>
    {
        protected override AddressesList getRandomObject()
        {
            createWithNullArgs = new AddressesList(null, null);
            var l = getRandomAddressDbRecordsList();
            return new AddressesList(l, GetRandom.Object<RepositoryPage>());
        }
        internal static IEnumerable<AddressData> getRandomAddressDbRecordsList() {
            var l = new List<AddressData>();
            for (var i = 0; i < GetRandom.UInt8(5, 10); i++) {
                l.Add(getRandomAddressDbRecord(i));
            }

            return l;
        }
        internal static AddressData getRandomAddressDbRecord(int i = int.MinValue) {
            i = i == int.MinValue ? GetRandom.UInt8() : i;
            var x = i % 4;
            if (x == 0) return GetRandom.Object<WebPageAddressData>();
            if (x == 1) return GetRandom.Object<EmailAddressData>();
            if (x == 2) return GetRandom.Object<TelecomAddressData>();
            return GetRandom.Object<GeographicAddressData>();
        }
    }
}


