using System.Collections.Generic;
using System.ComponentModel;
using Open.Core;
using Open.Data.Quantity;
namespace Open.Facade.Quantity {

    public class MoneyCalculatorView: MoneyView {
        public const sbyte DefaultRoundingDecimals = 2;
        public const byte DefaultRoundingDigit = 5;
        public const double DefaultRoundingStep = 0.1;
        public MoneyCalculatorView():this(null){ }
        public MoneyCalculatorView(List<CurrencyData> list) {
            LoadCurrencies(list);
        }
        public List<string> Currencies { get; } = new List<string>();

        public decimal Score { get; set; }

        [DisplayName("Score currency")] public string ScoreCurrency { get; set; }

        [DisplayName("Rounding strategy")] public RoundingStrategy RoundingStrategy { get; set; } = RoundingStrategy.Round;

        [DisplayName("Rounding step")] public double RoundingStep { get; set; } = DefaultRoundingStep;

        [DisplayName("Rounding decimals")] public sbyte RoundingDecimals { get; set; } = DefaultRoundingDecimals;

        [DisplayName("Rounding digit")] public byte RoundingDigit { get; set; } = DefaultRoundingDigit;

        public MoneyOperation Operation { get; set; } = MoneyOperation.Dummy;
        public string Result => $"{Score} {ScoreCurrency}";
        public void LoadCurrencies(List<CurrencyData> list) {
            if (list is null) return;
            foreach (var c in list) {
                if (Currencies.Contains(c.ID)) continue;
                Currencies.Add(c.ID);
            }
        }
    }
}
