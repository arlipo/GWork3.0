using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Party;
using Open.Domain.Party;
using Open.Tests.Domain;
namespace Open.Tests.Facade.Party {
    [TestClass]
    public class TelecomDeviceRegistrationsListTests : ListBaseTests<
        TelecomDeviceRegistrationsList, TelecomDeviceRegistration> {

        protected override TelecomDeviceRegistrationsList getRandomObject() {
            createWithNullArgs = new TelecomDeviceRegistrationsList(null, null);
            var l = GetRandom.Object<List<TelecomDeviceRegistrationData>>();
            return new TelecomDeviceRegistrationsList(l, GetRandom.Object<RepositoryPage>());
        }
    }
}





