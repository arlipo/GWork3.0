namespace Open.Core {
    public class RoundingPolicy : Archetype {

        private const byte maxDigit = 9;
        private const byte maxDecimals = 10;
        private sbyte decimals;
        private byte digit;
        private double step;

        public RoundingPolicy(RoundingStrategy s = RoundingStrategy.Round, sbyte decimals = 2,
            byte digit = 5, double step = 0.1) {
            Strategy = s;
            this.decimals = validateDecimals(decimals);
            this.digit = validateDigit(digit);
            this.step = validateStep(step);
        }

        private static double validateStep(double x) {
            if (x > 0 && x <= 1.0) return x;
            return 1.0;
        }

        private static byte validateDigit(byte x) {
            return x < maxDigit ? x : maxDigit;
        }

        private static sbyte validateDecimals(sbyte x) {
            if (x > maxDecimals) return 2;
            if (x < -maxDecimals) return 2;
            return x;
        }

        public RoundingStrategy Strategy { get; set; }

        public double Step { get => step; set => step = validateStep(value); }

        public sbyte Decimals { get => decimals; set => decimals = validateDecimals(value); }

        public byte Digit { get => digit; set => digit = validateDigit(value); }
    }
}