using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Open.Core;
using Open.Data.Party;
using Open.Domain.Party;
using Open.Facade.Party;
namespace Open.Sentry.Controllers {
    [Authorize]
    public class ContactsController : Controller, ISentryController {

        private readonly IAddressesRepository addresses;
        private readonly ITelecomDeviceRegistrationsRepository deviceRegistrations;
        internal const string emailProperties = "ID, EmailAddress, ValidFrom, ValidTo";
        internal const string webProperties = "ID, Url, ValidFrom, ValidTo";
        internal const string telecomProperties =
            "ID, CountryCode, AreaCode, Number, Extension, NationalDirectDialingPrefix, DeviceType, ValidFrom, ValidTo";
        internal const string adrProperties =
            "ID, AddressLine, City, RegionOrState, ZipOrPostalCode, Country, ValidFrom, ValidTo";

        #region other code ...
        public ContactsController(IAddressesRepository a,
            ITelecomDeviceRegistrationsRepository d) {
            addresses = a;
            deviceRegistrations = d;
        }
        public async Task<IActionResult> Index(string sortOrder = null,
            string currentFilter = null,
            string searchString = null,
            int? page = null) {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["SortAddressType"] = string.IsNullOrEmpty(sortOrder) ? "type_desc" : "";
            ViewData["SortToString"] = sortOrder == "string" ? "string_desc" : "string";
            ViewData["SortValidFrom"] = sortOrder == "validFrom" ? "validFrom_desc" : "validFrom";
            ViewData["SortValidTo"] = sortOrder == "validTo" ? "validTo_desc" : "validTo";
            addresses.SortOrder = sortOrder != null && sortOrder.EndsWith("_desc")
                ? SortOrder.Descending
                : SortOrder.Ascending;
            addresses.SortFunction = getSortFunction(sortOrder);
            if (searchString != null) page = 1;
            else searchString = currentFilter;
            ViewData["CurrentFilter"] = searchString;
            addresses.SearchString = searchString;
            addresses.PageIndex = page ?? 1;
            var l = await addresses.GetObjectsList();
            return View(new AddressViewsList(l));
        }
        private Func<AddressData, object> getSortFunction(string sortOrder) {
            if (string.IsNullOrWhiteSpace(sortOrder)) return x => x.GetType().Name;
            if (sortOrder.StartsWith("type")) return x => x.GetType().Name;
            if (sortOrder.StartsWith("validTo")) return x => x.ValidTo;
            if (sortOrder.StartsWith("validFrom")) return x => x.ValidFrom;
            return x => x.Address;
        }
        public async Task<IActionResult> Delete(string id) {
            var c = await addresses.GetObject(id);

            switch (c) {
                case WebPageAddress web:
                    return View("DeleteWeb",
                        AddressViewFactory.Create(web) as WebPageAddressView);
                case EmailAddress email:
                    return View("DeleteEmail",
                        AddressViewFactory.Create(email) as EMailAddressView);
                case TelecomAddress tel:
                    await deviceRegistrations.LoadAddresses(tel);
                    return View("DeleteTelecom",
                        AddressViewFactory.Create(tel) as TelecomAddressView);
                case GeographicAddress adr:
                    await deviceRegistrations.LoadDevices(adr);
                    return View("DeleteAddress",
                        AddressViewFactory.Create(adr) as GeographicAddressView);
            }

            return RedirectToAction("Index");
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id) {
            var c = await addresses.GetObject(id);
            await addresses.DeleteObject(c);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(string id) {
            var address = await addresses.GetObject(id);
            switch (address) {
                case WebPageAddress _: return RedirectToAction("EditWeb", new {id});
                case EmailAddress _: return RedirectToAction("EditEmail", new { id });
                case TelecomAddress _: return RedirectToAction("EditTelecom", new { id });
                default: return RedirectToAction("EditAddress", new { id });
            }
        }
        public async Task<IActionResult> EditWeb(string id) {
            var address = await addresses.GetObject(id);
            return View(AddressViewFactory.Create(address) as WebPageAddressView);
        }
        public async Task<IActionResult> EditEmail(string id) {
            var address = await addresses.GetObject(id);
            return View(AddressViewFactory.Create(address) as EMailAddressView);
        }
        public async Task<IActionResult> EditAddress(string id,
            string currentFilter = null,
            string searchString = null,
            int? page = null)
        {

            if (searchString != null) page = 1;
            else searchString = currentFilter;
            ViewData["CurrentFilter"] = searchString;
            addresses.SearchString = searchString;
            addresses.PageIndex = page ?? 1;
            var devices = new AddressViewsList(null);
            if (!string.IsNullOrWhiteSpace(searchString))
                devices = new AddressViewsList(await addresses.GetDevicesList());
            var a = await addresses.GetObject(id) as GeographicAddress ?? new GeographicAddress(null);
            await deviceRegistrations.LoadDevices(a);
            var adr = AddressViewFactory.Create(a) as GeographicAddressView ?? new GeographicAddressView();
            foreach (var device in adr.RegisteredTelecomAddresses)
                devices.RemoveAll(x => x.Contact == device.Contact);
            ViewBag.Devices = devices;
            return View(adr);
        }
        public async Task<IActionResult> EditTelecom(string id) {
            var address = await addresses.GetObject(id) as TelecomAddress;
            await deviceRegistrations.LoadAddresses(address);
            return View(AddressViewFactory.Create(address) as TelecomAddressView);
        }
        public async Task<IActionResult> Details(string id) {
            var c = await addresses.GetObject(id);

            switch (c) {
                case WebPageAddress web:
                    return View("DetailsWeb",
                        AddressViewFactory.Create(web) as WebPageAddressView);
                case EmailAddress email:
                    return View("DetailsEmail",
                        AddressViewFactory.Create(email) as EMailAddressView);
                case TelecomAddress tel:
                    await deviceRegistrations.LoadAddresses(tel);
                    return View("DetailsTelecom",
                        AddressViewFactory.Create(tel) as TelecomAddressView);
                case GeographicAddress adr:
                    await deviceRegistrations.LoadDevices(adr);
                    return View("DetailsAddress",
                        AddressViewFactory.Create(adr) as GeographicAddressView);
            }

            return RedirectToAction("Index");
        }

        public IActionResult CreateWeb() {
            return View(new WebPageAddressView());
        }
        public IActionResult CreateEmail() {
            return View(new EMailAddressView());
        }
        public IActionResult CreateTelecom() {
            return View(new TelecomAddressView());
        }
        public IActionResult Create() {
            return View(new GeographicAddressView());
        }

        [HttpPost] 
        public async Task<IActionResult>
            CreateWeb([Bind(webProperties)] WebPageAddressView c) {
            if (!ModelState.IsValid) return View(c);
            c.ID = c.ID?? Guid.NewGuid().ToString();
            var o = AddressFactory.CreateWeb(c.ID, c.Url, c.ValidFrom, c.ValidTo);
            await addresses.AddObject(o);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EditWeb([Bind(webProperties)] WebPageAddressView c) {
            if (!ModelState.IsValid) return View("EditWeb", c);
            var o = await addresses.GetObject(c.ID) as WebPageAddress;
            o.Data.Address = c.Url;
            o.Data.ValidFrom = c.ValidFrom ?? DateTime.MinValue;
            o.Data.ValidTo = c.ValidTo ?? DateTime.MaxValue;
            await addresses.UpdateObject(o);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmail(
            [Bind(emailProperties)] EMailAddressView c) {
            if (!ModelState.IsValid) return View(c);
            c.ID = c.ID ?? Guid.NewGuid().ToString();
            var o = AddressFactory.CreateEmail(c.ID, c.EmailAddress, c.ValidFrom, c.ValidTo);
            await addresses.AddObject(o);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EditEmail([Bind(emailProperties)] EMailAddressView c) {
            if (!ModelState.IsValid) return View("EditEmail", c);
            var o = await addresses.GetObject(c.ID) as EmailAddress;
            o.Data.Address = c.EmailAddress;
            o.Data.ValidFrom = c.ValidFrom ?? DateTime.MinValue;
            o.Data.ValidTo = c.ValidTo ?? DateTime.MaxValue;
            await addresses.UpdateObject(o);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> CreateTelecom(
            [Bind(telecomProperties)] TelecomAddressView c)
        {
            if (!ModelState.IsValid) return View(c);
            c.ID = c.ID ?? Guid.NewGuid().ToString();
            var o = AddressFactory.CreateDevice(c.ID, c.CountryCode, c.AreaCode,
                c.Number, c.Extension, c.NationalDirectDialingPrefix, c.DeviceType, c.ValidFrom, c.ValidTo);
            await addresses.AddObject(o);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EditTelecom(
            [Bind(telecomProperties)] TelecomAddressView c) {
            if (!ModelState.IsValid) return View("EditTelecom", c);
            var o = await addresses.GetObject(c.ID) as TelecomAddress;
            o.Data.Address = c.Number;
            o.Data.NationalDirectDialingPrefix = c.NationalDirectDialingPrefix;
            o.Data.CityOrAreaCode = c.AreaCode;
            o.Data.RegionOrStateOrCountryCode = c.CountryCode;
            o.Data.ZipOrPostCodeOrExtension = c.Extension;
            o.Data.Device = c.DeviceType;
            o.Data.ValidFrom = c.ValidFrom ?? DateTime.MinValue;
            o.Data.ValidTo = c.ValidTo ?? DateTime.MaxValue;
            await addresses.UpdateObject(o);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> Create(
            [Bind(adrProperties)] GeographicAddressView c)
        {
            if (!ModelState.IsValid) return View(c);
            c.ID = c.ID ?? Guid.NewGuid().ToString();
            var o = AddressFactory.CreateAddress(c.ID, c.AddressLine, c.City,
                c.RegionOrState, c.ZipOrPostalCode, c.Country, c.ValidFrom, c.ValidTo);
            await addresses.AddObject(o);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EditAddress(
            [Bind(adrProperties)] GeographicAddressView c)
        {
            if (!ModelState.IsValid) return View("EditAddress", c);
            var o = await addresses.GetObject(c.ID) as GeographicAddress;
            o.Data.Address = c.AddressLine;
            o.Data.CityOrAreaCode = c.City;
            o.Data.RegionOrStateOrCountryCode = c.RegionOrState;
            o.Data.ZipOrPostCodeOrExtension = c.ZipOrPostalCode;
            o.Data.CountryID = c.Country;
            o.Data.ValidFrom = c.ValidFrom ?? DateTime.MinValue;
            o.Data.ValidTo = c.ValidTo ?? DateTime.MaxValue;
            await addresses.UpdateObject(o);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveDevice(string adr, string dev)
        {
            var o = await deviceRegistrations.GetObject(adr, dev);
            o.Data.Address = null;
            o.Data.Device = null;
            await deviceRegistrations.DeleteObject(o);
            return RedirectToAction("EditAddress", new { id = adr });
        }


        #endregion
        public async Task<IActionResult> AddDevice(string adr, string dev)
        {
            var r = new TelecomDeviceRegistrationData
            {
                AddressID = adr,
                DeviceID = dev
            };
            await deviceRegistrations.AddObject(new TelecomDeviceRegistration(r));
            return RedirectToAction("EditAddress", new { id = adr });
        }
    }
}



