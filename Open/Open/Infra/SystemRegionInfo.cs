using System.Collections.Generic;
using System.Globalization;
using System.Linq;
namespace Open.Aids {
    public static class SystemRegionInfo {
        public static bool IsCountry(RegionInfo r) {
            var id = r.ThreeLetterISORegionName;
            return !char.IsNumber(id[0]);
        }
        public static List<RegionInfo> GetRegionsList() {
            var cultures = CultureInfo
                .GetCultures(CultureTypes.SpecificCultures)
                .Select(i => new RegionInfo(i.LCID))
                .Distinct()
                .ToList();
            var regions = cultures.OrderBy(p => p.EnglishName).ToList();
            return regions;
        }
    }
}


