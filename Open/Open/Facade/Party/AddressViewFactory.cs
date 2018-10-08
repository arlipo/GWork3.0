using System;
using Open.Core;
using Open.Data.Party;
using Open.Domain.Party;
namespace Open.Facade.Party {
    public static class AddressViewFactory {

        public static AddressView Create(IAddress o) {
            switch (o) {
                case WebPageAddress web: return create(web);
                case EmailAddress email: return create(email);
                case TelecomAddress device: return create(device);
                default: return create(o as GeographicAddress);
            }
        }

        private static WebPageAddressView create(WebPageAddress o) {
            var v = new WebPageAddressView {
                Url = o?.Data?.Address
            };
            setCommonValues(v, o?.Data?.ID, o?.Data?.ValidFrom, o?.Data?.ValidTo);
            return v;
        }
        private static EMailAddressView create(EmailAddress o) {
            var v = new EMailAddressView {
                EmailAddress = o?.Data?.Address
            };
            setCommonValues(v, o?.Data?.ID, o?.Data?.ValidFrom, o?.Data?.ValidTo);
            return v;
        }
        private static TelecomAddressView create(TelecomAddress o) {
            var v = new TelecomAddressView {
                Number = o?.Data?.Address,
                AreaCode = o?.Data?.CityOrAreaCode,
                DeviceType = o?.Data?.Device ?? TelecomDevice.NotKnown,
                CountryCode = o?.Data?.RegionOrStateOrCountryCode,
                NationalDirectDialingPrefix = o?.Data?.NationalDirectDialingPrefix,
                Extension = o?.Data?.ZipOrPostCodeOrExtension
            };
            setCommonValues(v, o?.Data?.ID, o?.Data?.ValidFrom, o?.Data?.ValidTo);
            if (o is null) return v;
            foreach (var c in o.RegisteredInAddresses) {
                var address = create(c);
                v.RegisteredInAddresses.Add(address);
            }

            return v;
        }
        private static GeographicAddressView create(GeographicAddress o) {
            var v = new GeographicAddressView {
                AddressLine = o?.Data?.Address,
                City = o?.Data?.CityOrAreaCode,
                ZipOrPostalCode = o?.Data?.ZipOrPostCodeOrExtension,
                RegionOrState = o?.Data?.RegionOrStateOrCountryCode,
                Country = o?.Data?.CountryID
            };
            setCommonValues(v, o?.Data?.ID, o?.Data?.ValidFrom, o?.Data?.ValidTo);
            if (o is null) return v;
            foreach (var c in o.RegisteredTelecomDevices) {
                var device = create(c);
                v.RegisteredTelecomAddresses.Add(device);
            }

            return v;
        }

        private static void setCommonValues(AddressView model, string id, DateTime? validFrom,
            DateTime? validTo) {
            model.ID = id;
            model.ValidFrom = setNullIfExtremum(validFrom ?? DateTime.MinValue);
            model.ValidTo = setNullIfExtremum(validTo ?? DateTime.MaxValue);
        }
        private static DateTime? setNullIfExtremum(DateTime d) {
            if (d.Date >= DateTime.MaxValue.Date) return null;
            if (d.Date <= DateTime.MinValue.AddDays(1).Date) return null;
            return d;
        }
        public static TelecomAddress Create(TelecomAddressView v) {
            var d = new TelecomAddressData {
                ID = v.ID,
                Address = v.Number,
                CityOrAreaCode = v.AreaCode,
                Device = v.DeviceType,
                RegionOrStateOrCountryCode = v.CountryCode,
                NationalDirectDialingPrefix = v.NationalDirectDialingPrefix,
                ZipOrPostCodeOrExtension = v.Extension,
                ValidTo = v.ValidTo ?? DateTime.MaxValue,
                ValidFrom = v.ValidFrom ?? DateTime.MinValue
            };
            return new TelecomAddress(d);
        }
        public static GeographicAddress Create(GeographicAddressView v) {
            var d = new GeographicAddressData {
                ID = v.ID,
                Address = v.AddressLine,
                CityOrAreaCode = v.City,
                ZipOrPostCodeOrExtension = v.ZipOrPostalCode,
                RegionOrStateOrCountryCode = v.RegionOrState,
                CountryID = v.Country,
                ValidTo = v.ValidTo ?? DateTime.MaxValue,
                ValidFrom = v.ValidFrom ?? DateTime.MinValue
            };

            return new GeographicAddress(d);
        }
        public static WebPageAddress Create(WebPageAddressView v) {
            var d = new WebPageAddressData {
                ID = v.ID,
                Address = v.Url,
                ValidTo = v.ValidTo ?? DateTime.MaxValue,
                ValidFrom = v.ValidFrom ?? DateTime.MinValue
            };

            return new WebPageAddress(d);
        }
        public static EmailAddress Create(EMailAddressView v) {
            var d = new EmailAddressData {
                ID = v.ID,
                Address = v.EmailAddress,
                ValidTo = v.ValidTo ?? DateTime.MaxValue,
                ValidFrom = v.ValidFrom ?? DateTime.MinValue
            };

            return new EmailAddress(d);
        }
    }
}
