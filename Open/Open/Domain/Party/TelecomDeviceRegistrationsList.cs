using System.Collections.Generic;
using Open.Core;
using Open.Data.Party;
namespace Open.Domain.Party {

    public class
        TelecomDeviceRegistrationsList : PaginatedList<TelecomDeviceRegistration> {
        public TelecomDeviceRegistrationsList(
            IEnumerable<TelecomDeviceRegistrationData> items,
            RepositoryPage page) :
            base(page) {
            if (items is null) return;
            foreach (var dbRecord in items) { Add(new TelecomDeviceRegistration(dbRecord)); }
        }
    }
}


