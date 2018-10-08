using System;
using System.Globalization;
namespace Open.Core{
    public static class Rounding {
        internal static bool isPositive(double d) { return d >= 0; }
        internal static bool isPositive(decimal d) { return d >= 0; }
        internal static double floor(double d) { return Math.Floor(d); }
        internal static decimal floor(decimal d) { return Math.Floor(d); }
        internal static double ceiling(double d) { return Math.Ceiling(d); }
        internal static decimal ceiling(decimal d) { return Math.Ceiling(d); }
        internal static double coeficient(sbyte percision) { return Math.Pow(10.0, percision); }
        internal static decimal decimalCoeficient(sbyte percision) { return Convert.ToDecimal(Math.Pow(10.0, percision)); }
        internal static byte digit(double d, sbyte percision) {
            var coef = coeficient(percision);
            var s = (d * coef).ToString(CultureInfo.InvariantCulture);
            var found = false;
            byte r = 0;
            foreach (var v in s) {
                if (found) return (byte) (v - '0');
                if (v == '.') found = true;
                else r = (byte) (v - '0');
            }

            return r;
        }

        internal static byte digit(decimal d, sbyte percision) {
            var coef = decimalCoeficient(percision);
            var s = (d * coef).ToString(CultureInfo.InvariantCulture);
            var found = false;
            byte r = 0;
            foreach (var v in s) {
                if (found) return (byte) (v - '0');
                if (v == '.') found = true;
                else r = (byte) (v - '0');
            }

            return r;
        }

        public static double Up(double d, sbyte percision) {
            d = Math.Round(d, percision + 2);
            var coef = coeficient(percision);
            d = d * coef;
            d = isPositive(d) ? ceiling(d) : floor(d);
            return d / coef;
        }

        public static double Down(double d, sbyte percision) {
            d = Math.Round(d, percision + 2);
            var coef = coeficient(percision);
            d = d * coef;
            d = isPositive(d) ? floor(d) : ceiling(d);
            return d / coef;
        }

        public static double Off(double d, sbyte percision, byte roundingDigit) {
            d = Math.Round(d, percision + 2);
            var rd = digit(d, percision);
            return rd < roundingDigit ? Down(d, percision) : Up(d, percision);
        }

        public static double UpByStep(double d, double step) {
            d = d / step;
            d = isPositive(d) ? ceiling(d) : floor(d);
            return step * d;
        }

        public static double DownByStep(double d, double step) {
            d = d / step;
            d = isPositive(d) ? floor(d) : ceiling(d);
            return step * d;
        }

        public static double TowardsPositive(double d, sbyte percision) {
            d = Math.Round(d, percision + 2);
            return isPositive(d) ? Up(d, percision) : Down(d, percision);
        }

        public static double TowardsNegative(double d, sbyte percision) {
            d = Math.Round(d, percision + 2);
            return isPositive(d) ? Down(d, percision) : Up(d, percision);
        }

        public static decimal Up(decimal d, sbyte percision) {
            d = Math.Round(d, percision + 2);
            var coef = decimalCoeficient(percision);
            d = d * coef;
            d = isPositive(d) ? ceiling(d) : floor(d);
            return d / coef;
        }
        public static decimal Down(decimal d, sbyte percision) {
            d = Math.Round(d, percision + 2);
            var coef = decimalCoeficient(percision);
            d = d * coef;
            d = isPositive(d) ? floor(d) : ceiling(d);
            return d / coef;
        }

        public static decimal Off(decimal d, sbyte percision, byte roundingDigit) {
            d = Math.Round(d, percision + 2);
            var rd = digit(d, percision);
            return rd < roundingDigit ? Down(d, percision) : Up(d, percision);
        }

        public static decimal UpByStep(decimal d, double step) {
            var s = Convert.ToDecimal(step);
            d = d / s;
            d = isPositive(d) ? ceiling(d) : floor(d);
            return s * d;
        }
        public static decimal DownByStep(decimal d, double step) {
            var s = Convert.ToDecimal(step);
            d = d / s;
            d = isPositive(d) ? floor(d) : ceiling(d);
            return s * d;
        }

        public static decimal TowardsPositive(decimal d, sbyte percision) {
            d = Math.Round(d, percision + 2);
            return isPositive(d) ? Up(d, percision) : Down(d, percision);
        }

        public static decimal TowardsNegative(decimal d, sbyte percision) {
            d = Math.Round(d, percision + 2);
            return isPositive(d) ? Down(d, percision) : Up(d, percision);
        }

        public static decimal Off(decimal d, RoundingPolicy p) {
            switch (p.Strategy) {
                case RoundingStrategy.RoundUp: return Up(d, p.Decimals);
                case RoundingStrategy.RoundDown: return Down(d, p.Decimals);
                case RoundingStrategy.RoundUpByStep: return UpByStep(d, p.Step);
                case RoundingStrategy.RoundDownByStep: return DownByStep(d, p.Step);
                case RoundingStrategy.RoundTowardsPositive: return TowardsPositive(d, p.Decimals);
                case RoundingStrategy.RoundTowardsNegative: return TowardsNegative(d, p.Decimals);
                case RoundingStrategy.Round: return Off(d, p.Decimals, p.Digit);
                default: return Off(d, p.Decimals, p.Digit);
            }
        }

        public static double Off(double d, RoundingPolicy p) {
            switch (p.Strategy) {
                case RoundingStrategy.RoundUp: return Up(d, p.Decimals);
                case RoundingStrategy.RoundDown: return Down(d, p.Decimals);
                case RoundingStrategy.RoundUpByStep: return UpByStep(d, p.Step);
                case RoundingStrategy.RoundDownByStep: return DownByStep(d, p.Step);
                case RoundingStrategy.RoundTowardsPositive: return TowardsPositive(d, p.Decimals);
                case RoundingStrategy.RoundTowardsNegative: return TowardsNegative(d, p.Decimals);
                case RoundingStrategy.Round: return Off(d, p.Decimals, p.Digit);
                default: return Off(d, p.Decimals, p.Digit);
            }
        }

    }
}