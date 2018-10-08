using System;
using System.Collections.Generic;
using System.Linq;
using Open.Aids;
using Open.Core;
using Open.Data.Party;
namespace Open.Infra.Party {
    public static class ContactsInitializer {
        public static void Initialize(SentryDbContext c) {
            c.Database.EnsureCreated();
            if (c.Addresses.Any()) return;
            initWebPageAddresses(c);
            initEmailAddresses(c);
            var geographicIDs = initGeographicAddresses(c);
            var telecomIDs = initTelecomAddresses(c);
            initTelecomRegistrations(c, geographicIDs, telecomIDs);
            c.SaveChanges();
        }

        private static void initTelecomRegistrations(SentryDbContext c, List<string> geographicIDs, List<string> telecomIDs) {
            foreach (var a in geographicIDs) {
                foreach (var d in telecomIDs) {
                    if (GetRandom.Bool()) continue;
                    c.TelecomDeviceRegistrations.Add(new TelecomDeviceRegistrationData {AddressID = a, DeviceID = d});
                }
            }
        }

        private static List<string> initTelecomAddresses(SentryDbContext c) {
            var l = new List<string> {
                add(c, new TelecomAddressData{Address = "22222222",
                    CityOrAreaCode = "51",
                    RegionOrStateOrCountryCode = "372",
                    Device = TelecomDevice.Mobile
                }),
                add(c, new TelecomAddressData{Address = "1111111",
                    CityOrAreaCode = "52",
                    RegionOrStateOrCountryCode = "372",
                    Device = TelecomDevice.Mobile
                }),
                add(c, new TelecomAddressData{Address = "3333333",
                    CityOrAreaCode = "60",
                    RegionOrStateOrCountryCode = "372",
                    Device = TelecomDevice.Phone
                }),
                add(c, new TelecomAddressData{Address = "4444444",
                    CityOrAreaCode = "61",
                    RegionOrStateOrCountryCode = "372",
                    Device = TelecomDevice.Fax
                })
            };
            return l;
        }

        private static List<string> initGeographicAddresses(SentryDbContext c) {
            var l = new List<string> {
                add(c, new GeographicAddressData {Address = "Akadeemia tee 15A",
                    CityOrAreaCode = "Tallinn",
                    RegionOrStateOrCountryCode = "Harjumaa",
                    CountryID = "EST",
                    ZipOrPostCodeOrExtension = "12618"
                }),
                add(c, new GeographicAddressData {Address = "Raja 4C",
                    CityOrAreaCode = "Tallinn",
                    RegionOrStateOrCountryCode = "Harjumaa",
                    CountryID = "EST",
                    ZipOrPostCodeOrExtension = "12616"
                }),
                add(c, new GeographicAddressData {Address = "Ehitajate tee 5",
                    CityOrAreaCode = "Tallinn",
                    RegionOrStateOrCountryCode = "Harjumaa",
                    CountryID = "EST",
                    ZipOrPostCodeOrExtension = "12618"
                })
            };
            add(c, new GeographicAddressData {
                Address = "4 Privet Drive",
                CityOrAreaCode = "Little Whinging",
                RegionOrStateOrCountryCode = "Surrey",
                CountryID = "GBR",
                ZipOrPostCodeOrExtension = "BS13 9RN"
            });
            return l;
        }

        private static void initEmailAddresses(SentryDbContext c) {
            add(c, new EmailAddressData { Address = "Harry.Potter@hogwarts.edu" });
            add(c, new EmailAddressData { Address = "Hermione.Granger@hogwarts.edu" });
            add(c, new EmailAddressData { Address = "Ron.Weasley@hogwarts.edu" });
            add(c, new EmailAddressData { Address = "Albus.Dumbledore@hogwarts.edu" });
        }

        private static void initWebPageAddresses(SentryDbContext c) {
            add(c, new WebPageAddressData {Address = "www.visualstudio.com" });
            add(c, new WebPageAddressData { Address = "www.jetbrains.com" });
            add(c, new WebPageAddressData { Address = "www.wikipedia.org" });
            add(c, new WebPageAddressData { Address = "www.amazon.com" });
        }

        private static string add(SentryDbContext c, AddressData address) {
            address.ID = Guid.NewGuid().ToString();
            c.Addresses.Add(address);
            return address.ID;
        }
    }
}


