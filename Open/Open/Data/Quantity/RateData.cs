using Open.Data.Common;
namespace Open.Data.Quantity {
    public class RateData : IdentifiedData {

        private string currencyID;
        private string rateTypeID;

        public string CurrencyID { get => getString(ref currencyID); set => currencyID = value; }

        public string RateTypeID { get => getString(ref rateTypeID); set => rateTypeID = value; }

        public decimal Rate { get; set; }

        public virtual RateTypeData RateType { get; set; }

        public virtual CurrencyData Currency { get; set; }
    }
}