

using System.Collections.Generic;
using System.Globalization;
using System.Linq;
namespace Open.Aids {

    public static class SystemRegionInfo {

        public static bool IsCountry(RegionInfo r) {
            return Safe.Run(() => SystemString.StartsWithLetter(r.ThreeLetterISORegionName), false);
        }

        public static List<RegionInfo> GetRegionsList() {
            return Safe.Run(() => {
                var cultures = SystemCultureInfo.GetSpecificCultures();
                var regions = SystemEnumerable.Convert(cultures, SystemCultureInfo.ToRegionInfo);
                regions = SystemEnumerable.Distinct(regions);
                regions = SystemEnumerable.OrderBy(regions, p => p.EnglishName);
                return regions.ToList();
            }, new List<RegionInfo>());
        }
    }
}


