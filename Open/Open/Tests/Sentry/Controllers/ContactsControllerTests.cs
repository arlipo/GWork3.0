using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Party;
using Open.Domain.Party;
using Open.Facade.Common;
using Open.Facade.Party;
using Open.Infra.Party;
using Open.Sentry.Controllers;
using Open.Tests.Domain.Party;
namespace Open.Tests.Sentry.Controllers {

    [TestClass] public class
        ContactsControllerTests : BaseControllerTests<ContactsController, IAddress, AddressData> {

        private AddressData randomContact;

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            repository = new ContactsRepository(db);
            controller = "contacts";
            detailsViewCaption = "Geographic Address";
            randomContact = null;
        }

        protected override List<string> specificStringsToTestInIndexView() {
            return new List<string> {
                "<h2>Contacts</h2>",
                "<t>Create new </t>",
                "<a href=\"/contacts/CreateWeb\">Web</a>",
                "<a href=\"/contacts/CreateEmail\">Email</a>",
                "<a href=\"/contacts/CreateTelecom\">Telecom</a>",
                "<a href=\"/contacts/Create\">Address</a>",
                "<th><a href=\"/contacts?SortOrder=type_desc\">Address type</a></th>",
                "<th><a href=\"/contacts?SortOrder=string\">Contact</a></th>",
                "<th><a href=\"/contacts?SortOrder=validFrom\">Valid From</a></th>",
                "<th><a href=\"/contacts?SortOrder=validFrom\">Valid To</a></th>"
            };
        }
        [TestMethod] public async Task EditWebTest() {
            randomContact = GetRandom.Object<WebPageAddressData>();
            await editTest(x => x.EditWeb(""), () => "editweb", () => editViewCaption,
                () => specificStringsToTestInView);
        }

        [TestMethod] public async Task EditEmailTest() {
            randomContact = GetRandom.Object<EmailAddressData>();
            await editTest(x => x.EditEmail(""), () => "editemail", () => editViewCaption,
                () => specificStringsToTestInView);
        }

        [TestMethod] public async Task EditAddressTest() {
            randomContact = GetRandom.Object<GeographicAddressData>();
            await editTest(x => x.EditAddress("", null, null, null), () => "editaddress",
                () => editViewCaption, () => specificStringsToTestInView);
        }

        [TestMethod] public async Task EditTelecomTest() {
            randomContact = GetRandom.Object<TelecomAddressData>();
            await editTest(x => x.EditTelecom(""), () => "edittelecom", () => editViewCaption,
                () => specificStringsToTestInView);
        }

        [TestMethod] public async Task CreateWebTest() {
            await createTest(x => x.CreateWeb(), controller, "WebPage Address", "createweb");
        }

        [TestMethod] public async Task CreateEmailTest() {
            await createTest(x => x.CreateEmail(), controller, "EMail Address", "createemail");
        }

        [TestMethod] public async Task CreateTelecomTest() {
            await createTest(x => x.CreateTelecom(), controller, "Telecom Address",
                "createtelecom");
        }

        [TestMethod] public void RemoveDeviceTest() {
            Assert.Inconclusive();
        }

        [TestMethod] public void AddDeviceTest() {
            Assert.Inconclusive();
        }

        [TestMethod] public async Task CreateWebAllGivenTest() {
            await createAllGivenTest<ContactsController>(createRandomWebViewModel,
                x => x.CreateWeb());
        }

        [TestMethod] public async Task CreateTelcoAllGivenTest() {
            await createAllGivenTest<ContactsController>(createRandomTelecomViewModel,
                x => x.CreateTelecom());
        }

        [TestMethod] public async Task CreateEmailAllGivenTest() {
            await createAllGivenTest<ContactsController>(createRandomEmailViewModel,
                x => x.CreateEmail());
        }

        protected override async Task isNotInRepository(string id) {
            var r = await repository.GetObject(id);
            id = getID(r);
            Assert.AreEqual(id, Constants.Unspecified);
        }

        protected override async Task validateEntityInRepository(object o) {
            var expected = o as EntityView;
            var actual = await repository.GetObject(expected?.ID);
            switch (o) {
                case EMailAddressView email:
                    validateEntity(email, (actual as EmailAddress)?.Data);
                    break;
                case WebPageAddressView web:
                    validateEntity(web, (actual as WebPageAddress)?.Data);
                    break;
                case TelecomAddressView telco:
                    validateEntity(telco, (actual as TelecomAddress)?.Data);
                    break;
                case GeographicAddressView adr:
                    validateEntity(adr, (actual as GeographicAddress)?.Data);
                    break;
                default:
                    Assert.Fail($"Wrong type {o.GetType()}");
                    break;
            }
        }

        protected override IEnumerable<KeyValuePair<string, string>>
            createHttpPostContext(object o) {
            switch (o) {
                case WebPageAddressView web: return httpPostContext(web);
                case EMailAddressView email: return httpPostContext(email);
                case TelecomAddressView telco: return httpPostContext(telco);
                case GeographicAddressView adr: return httpPostContext(adr);
                default: return new Dictionary<string, string>();
            }
        }

        protected override object createRandomViewModel() {
            var v = GetRandom.Object<GeographicAddressView>();
            v.ValidTo = GetRandom.DateTime(v.ValidFrom);
            return v;
        }

        protected object createRandomTelecomViewModel() {
            var v = GetRandom.Object<TelecomAddressView>();
            v.Number = GetRandom.UInt32().ToString();
            v.AreaCode = GetRandom.UInt8().ToString();
            v.CountryCode = GetRandom.UInt8().ToString();
            v.NationalDirectDialingPrefix = GetRandom.UInt8(0, 9).ToString();
            v.Extension = GetRandom.UInt8().ToString();
            v.ValidTo = GetRandom.DateTime(v.ValidFrom);
            return v;
        }

        protected object createRandomWebViewModel() {
            var v = GetRandom.Object<WebPageAddressView>();
            v.Url = GetRandom.String() + "." + GetRandom.String(2, 2);
            v.ValidTo = GetRandom.DateTime(v.ValidFrom);
            return v;
        }

        protected object createRandomEmailViewModel() {
            var v = GetRandom.Object<EMailAddressView>();
            v.EmailAddress = GetRandom.String() + "@" + GetRandom.String() + "." +
                             GetRandom.String(2, 2);
            v.ValidTo = GetRandom.DateTime(v.ValidFrom);
            return v;
        }

        protected override string createDbRecord() {
            var r = randomContact ?? AddressesListTests.getRandomAddressDbRecord();
            db.Addresses.Add(r);
            db.SaveChanges();
            specificStringsToTestInView = composeSpecificStrings(r);
            detailsViewCaption = $"{getType(r)} Address";
            editViewCaption = detailsViewCaption;
            actualEditAction = getEditAction(r);
            return r.ID;
        }

        private void validateEntity(GeographicAddressView expected, GeographicAddressData actual) {
            Assert.IsNotNull(expected);
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.ID, actual.ID);
            Assert.AreEqual(expected.AddressLine, actual.Address);
            Assert.AreEqual(expected.City, actual.CityOrAreaCode);
            Assert.AreEqual(expected.Country, actual.CountryID);
            Assert.AreEqual(expected.RegionOrState, actual.RegionOrStateOrCountryCode);
            Assert.AreEqual(expected.ZipOrPostalCode, actual.ZipOrPostCodeOrExtension);
            validateDates(expected.ValidFrom, actual.ValidFrom);
            validateDates(expected.ValidTo, actual.ValidTo);
        }

        private void validateEntity(TelecomAddressView expected, TelecomAddressData actual) {
            Assert.IsNotNull(expected);
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.ID, actual.ID);
            Assert.AreEqual(expected.Number, actual.Address);
            Assert.AreEqual(expected.AreaCode, actual.CityOrAreaCode);
            Assert.AreEqual(expected.CountryCode, actual.RegionOrStateOrCountryCode);
            Assert.AreEqual(expected.DeviceType, actual.Device);
            Assert.AreEqual(expected.Extension, actual.ZipOrPostCodeOrExtension);
            Assert.AreEqual(expected.NationalDirectDialingPrefix,
                actual.NationalDirectDialingPrefix);
            validateDates(expected.ValidFrom, actual.ValidFrom);
            validateDates(expected.ValidTo, actual.ValidTo);
        }

        private void validateEntity(WebPageAddressView expected, WebPageAddressData actual) {
            Assert.IsNotNull(expected);
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.ID, actual.ID);
            Assert.AreEqual(expected.Url, actual.Address);
            validateDates(expected.ValidFrom, actual.ValidFrom);
            validateDates(expected.ValidTo, actual.ValidTo);
        }

        private void validateEntity(EMailAddressView expected, EmailAddressData actual) {
            Assert.IsNotNull(expected);
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.ID, actual.ID);
            Assert.AreEqual(expected.EmailAddress, actual.Address);
            validateDates(expected.ValidFrom, actual.ValidFrom);
            validateDates(expected.ValidTo, actual.ValidTo);
        }

        private static IEnumerable<KeyValuePair<string, string>> httpPostContext(
            GeographicAddressView o) {
            var d = new Dictionary<string, string> {
                {GetMember.Name<GeographicAddressView>(m => m.ID), o?.ID},
                {GetMember.Name<GeographicAddressView>(m => m.AddressLine), o?.AddressLine},
                {GetMember.Name<GeographicAddressView>(m => m.City), o?.City},
                {GetMember.Name<GeographicAddressView>(m => m.Country), o?.Country},
                {GetMember.Name<GeographicAddressView>(m => m.RegionOrState), o?.RegionOrState},
                {GetMember.Name<GeographicAddressView>(m => m.ZipOrPostalCode), o?.ZipOrPostalCode},
                {GetMember.Name<GeographicAddressView>(m => m.ValidFrom), o?.ValidFrom.ToString()},
                {GetMember.Name<GeographicAddressView>(m => m.ValidTo), o?.ValidTo.ToString()}
            };
            return d;
        }

        private static IEnumerable<KeyValuePair<string, string>> httpPostContext(
            TelecomAddressView o) {
            var d = new Dictionary<string, string> {
                {GetMember.Name<TelecomAddressView>(m => m.ID), o?.ID},
                {GetMember.Name<TelecomAddressView>(m => m.Number), o?.Number},
                {GetMember.Name<TelecomAddressView>(m => m.AreaCode), o?.AreaCode},
                {GetMember.Name<TelecomAddressView>(m => m.CountryCode), o?.CountryCode},
                {GetMember.Name<TelecomAddressView>(m => m.DeviceType), o?.DeviceType.ToString()},
                {GetMember.Name<TelecomAddressView>(m => m.Extension), o?.Extension}, {
                    GetMember.Name<TelecomAddressView>(m => m.NationalDirectDialingPrefix),
                    o?.NationalDirectDialingPrefix
                },
                {GetMember.Name<TelecomAddressView>(m => m.ValidFrom), o?.ValidFrom.ToString()},
                {GetMember.Name<TelecomAddressView>(m => m.ValidTo), o?.ValidTo.ToString()}
            };
            return d;
        }

        private static IEnumerable<KeyValuePair<string, string>>
            httpPostContext(EMailAddressView o) {
            var d = new Dictionary<string, string> {
                {GetMember.Name<EMailAddressView>(m => m.ID), o?.ID},
                {GetMember.Name<EMailAddressView>(m => m.EmailAddress), o?.EmailAddress},
                {GetMember.Name<EMailAddressView>(m => m.ValidFrom), o?.ValidFrom.ToString()},
                {GetMember.Name<EMailAddressView>(m => m.ValidTo), o?.ValidTo.ToString()}
            };
            return d;
        }

        private IEnumerable<KeyValuePair<string, string>> httpPostContext(WebPageAddressView o) {
            var d = new Dictionary<string, string> {
                {GetMember.Name<WebPageAddressView>(m => m.ID), o?.ID},
                {GetMember.Name<WebPageAddressView>(m => m.Url), o?.Url},
                {GetMember.Name<WebPageAddressView>(m => m.ValidFrom), o?.ValidFrom.ToString()},
                {GetMember.Name<WebPageAddressView>(m => m.ValidTo), o?.ValidTo.ToString()}
            };
            return d;
        }

        private static string getID(IAddress a) {
            switch (a) {
                case EmailAddress email: return email.Data.ID;
                case WebPageAddress web: return web.Data.ID;
                case TelecomAddress tel: return tel.Data.ID;
                case GeographicAddress adr: return adr.Data.ID;
                default: return string.Empty;
            }
        }

        private static string getEditAction(AddressData a) {
            switch (a) {
                case EmailAddressData _: return "EditEmail";
                case WebPageAddressData _: return "EditWeb";
                case TelecomAddressData _: return "EditTelecom";
                default: return "EditAddress";
            }
        }

        private static List<string> composeSpecificStrings(AddressData a) {
            var l = new List<string> {
                $"{a.Address}"
            };
            if (a is WebPageAddressData || a is EmailAddressData) return l;
            var ll = new List<string> {
                $"{a.CityOrAreaCode}",
                $"{a.RegionOrStateOrCountryCode}",
                $"{a.ZipOrPostCodeOrExtension}"
            };
            l.AddRange(ll);
            var t = a as TelecomAddressData;
            if (t is null) return l;
            ll = new List<string> {
                $"{t.Device}",
                $"{t.NationalDirectDialingPrefix}"
            };
            l.AddRange(ll);
            return l;
        }

        private static string getType(AddressData a) {
            switch (a) {
                case EmailAddressData _: return "EMail";
                case WebPageAddressData _: return "WebPage";
                case TelecomAddressData _: return "Telecom";
                default: return "Geographic";
            }
        }

    }
}
