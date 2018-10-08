using System;
using System.Globalization;
using Open.Data.Quantity;
namespace Open.Domain.Quantity {
    public static class CurrencyFactory {

        public static Currency Create(string id, string name, string code,
            DateTime? validFrom = null, DateTime? validTo = null) {
            var o = new CurrencyData {
                ID = id,
                Name = name,
                Code = code,
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue
            };
            return new Currency(o);
        }

        public static Currency Create(RegionInfo r) {
            var id = r?.ISOCurrencySymbol;
            var name = r?.CurrencyEnglishName;
            var code = r?.CurrencySymbol;
            return Create(id, name, code);
        }
    }
}

