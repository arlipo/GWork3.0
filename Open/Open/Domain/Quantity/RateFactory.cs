using System;
using Open.Core;
using Open.Data.Quantity;
namespace Open.Domain.Quantity {
    public static class RateFactory {
        public static Rate Create(Currency c, decimal rate = 1M, DateTime? d = null, RateType t = null) {
            return Create(c?.Data?.ID, rate, d, t?.Data?.ID);
        }
        public static Rate Create(string currencyID, decimal rate = 1M, DateTime? d = null, string rateTypeID = null) {
            var dt = d ?? DateTime.Now;
            var id = calculateID(ref currencyID, dt, ref rateTypeID);
            var o = new RateData {
                ID = id,
                ValidFrom = dt.Date,
                ValidTo = dt.Date.AddSeconds(24 * 60 * 60 - 1),
                CurrencyID = currencyID,
                Rate = rate,
                RateTypeID = rateTypeID
            };
            return new Rate(o);
        }

        private static string calculateID(ref string currencyID, DateTime dt, ref string rateTypeID) {
            currencyID = string.IsNullOrWhiteSpace(currencyID) ? Constants.Unspecified : currencyID;
            rateTypeID = string.IsNullOrWhiteSpace(rateTypeID) ? Constants.Unspecified : rateTypeID;
            return currencyID + dt.ToString("-yyyy-MM-dd-") + rateTypeID;
        }
        public static string CalculateID(string currencyID, DateTime? dt, string rateTypeID) {
            return calculateID(ref currencyID, dt??DateTime.Now, ref rateTypeID);
        }

        public const string EuroRate = "EURORATE";
        public const string UsdRate = "USDRATE";
        public const string WeSell = "WESELL";
        public const string WeBuy = "WEBUY";
        public static readonly string[] RateTypes = {EuroRate, UsdRate, WeSell, WeBuy};
    }
}