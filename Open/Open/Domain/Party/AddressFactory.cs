using System;
using Open.Core;
using Open.Data.Party;
namespace Open.Domain.Party {
    public static class AddressFactory {
        public static IAddress Create(AddressData data) {
            switch (data) {
                case WebPageAddressData web:
                    return create(web);
                case EmailAddressData email:
                    return create(email);
                case TelecomAddressData device:
                    return create(device);
            }

            return create(data as GeographicAddressData);
        }
        private static WebPageAddress create(WebPageAddressData data) {
            return new WebPageAddress(data);
        }
        private static EmailAddress create(EmailAddressData data) {
            return new EmailAddress(data);
        }
        private static GeographicAddress create(GeographicAddressData data) {
            return new GeographicAddress(data);
        }
        private static TelecomAddress create(TelecomAddressData data) {
            return new TelecomAddress(data);
        }
        public static WebPageAddress CreateWeb(string id, string address,
            DateTime? validFrom = null, DateTime? validTo = null) {
            var r = new WebPageAddressData {
                ID = id,
                Address = address,
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue
            };
            return new WebPageAddress(r);
        }
        public static EmailAddress CreateEmail(string id, string address,
            DateTime? validFrom = null, DateTime? validTo = null) {
            var r = new EmailAddressData {
                ID = id,
                Address = address,
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue
            };
            return new EmailAddress(r);
        }
        public static GeographicAddress CreateAddress(string id, string addressLine,
            string city, string regionOrState, string zipOrPostalCode, string countryId,
            DateTime? validFrom = null, DateTime? validTo = null) {
            var r = new GeographicAddressData {
                ID = id,
                Address = addressLine,
                ZipOrPostCodeOrExtension = zipOrPostalCode,
                RegionOrStateOrCountryCode = regionOrState,
                CityOrAreaCode = city,
                CountryID = countryId,
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue
            };
            return new GeographicAddress(r);
        }
        public static TelecomAddress CreateDevice(string id, string countryCode,
            string areaCode,
            string number, string extension, string nationalDirectDialingPrefix,
            TelecomDevice deviceType,
            DateTime? validFrom = null, DateTime? validTo = null) {
            var r = new TelecomAddressData {
                ID = id,
                Address = number,
                ZipOrPostCodeOrExtension = extension,
                RegionOrStateOrCountryCode = countryCode,
                CityOrAreaCode = areaCode,
                NationalDirectDialingPrefix = nationalDirectDialingPrefix,
                Device = deviceType,
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue
            };
            return new TelecomAddress(r);
        }
    }
}





