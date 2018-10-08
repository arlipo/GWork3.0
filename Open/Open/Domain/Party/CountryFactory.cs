using System;
using System.Globalization;
using Open.Data.Party;
namespace Open.Domain.Party {

    public static class CountryFactory {

        public static Country Create(string id, string name, string code,
            DateTime? validFrom = null, DateTime? validTo = null) {
            var o = new CountryData{
                ID = id,
                Name = name,
                Code = code,
                ValidFrom = validFrom?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue
            };
            return new Country(o);
        }

        public static Country Create(RegionInfo r) {
            var id = r?.ThreeLetterISORegionName;
            var name = r?.DisplayName;
            var code = r?.TwoLetterISORegionName;
            return Create(id, name, code);
        }
    }
}



