// (c) https://www.codeproject.com/articles/774228/mvc-html-table-helper-part-display-tables
using System;
namespace Open.Aids.Extensions {
    public static class TypeExtensions {

        public static bool IsNumeric(this Type t) {
            var x = Nullable.GetUnderlyingType(t);
            if (!(x is null)) t = x;
            if (t == typeof(byte)) return true;
            if (t == typeof(decimal)) return true;
            if (t == typeof(double)) return true;
            if (t == typeof(short)) return true;
            if (t == typeof(int)) return true;
            if (t == typeof(long)) return true;
            if (t == typeof(sbyte)) return true;
            if (t == typeof(float)) return true;
            if (t == typeof(ushort)) return true;
            if (t == typeof(uint)) return true;
            if (t == typeof(ulong)) return true;
            return false;
        }

    }
}
