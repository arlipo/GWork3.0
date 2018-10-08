using System;
using System.Globalization;
namespace Open.Aids {
    public static class Decimals {
        public static bool TryParse(string s, out decimal d) {
            return decimal.TryParse(s, NumberStyles.Any, UseCulture.Invariant, out d);
        }
        public static decimal Add(decimal x, decimal y) {
            try { return x + y; }
            catch { return decimal.MaxValue; }
        }
        public static decimal Divide(decimal x, decimal y) {
            try { return x / y; }
            catch { return decimal.MaxValue; }
        }
        public static bool ToDecimal(object o, out decimal v) {
            v = decimal.Zero;
            var r = true;
            if (o is string str) return TryParse(str, out v);
            if (o is decimal m) v = m;
            else if (o is double d) v = Convert.ToDecimal(d);
            else if (o is float f) v = Convert.ToDecimal(f);
            else if (o is long l) v = Convert.ToDecimal(l);
            else if (o is int i) v = Convert.ToDecimal(i);
            else if (o is short s) v = Convert.ToDecimal(s);
            else if (o is sbyte sb) v = Convert.ToDecimal(sb);
            else if (o is ulong ul) v = Convert.ToDecimal(ul);
            else if (o is uint u) v = Convert.ToDecimal(u);
            else if (o is ushort us) v = Convert.ToDecimal(us);
            else if (o is byte b) v = Convert.ToDecimal(b);
            else r = false;
            return r;
        }
        public static decimal ToDecimal(object o) {
            ToDecimal(o, out var d);
            return d;
        }
        public static string ToString(decimal a) {
            return a.ToString(UseCulture.Invariant);
        }
        public static decimal Subtract(decimal x, decimal y) {
            try { return x - y; }
            catch { return decimal.MaxValue; }
        }
        public static bool IsGreater(decimal x, decimal y) {
            return x.CompareTo(y) > 0;
        }
        public static bool IsLess(decimal x, decimal y) {
            return x.CompareTo(y) < 0;
        }
        public static bool IsEqual(decimal x, decimal y) {
            return x.CompareTo(y) == 0;
        }
        public static decimal Multiply(decimal x, decimal y) {
            try { return x * y; }
            catch { return decimal.MaxValue; }
        }
        public static decimal Inverse(decimal x) {
            return Subtract(decimal.Zero, x);
        }
        public static decimal Reciprocal(decimal x) {
            return Divide(decimal.One, x);
        }
        public static decimal Square(decimal x) {
            return Multiply(x, x);
        }
    }
}