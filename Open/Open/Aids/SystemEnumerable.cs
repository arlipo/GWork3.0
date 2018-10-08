



using System;
using System.Collections.Generic;
using System.Linq;
namespace Open.Aids {
    public static class SystemEnumerable {

        public static IEnumerable<T> OrderBy<T>(IEnumerable<T> list, Func<T, string> func) {
            return Safe.Run(() => list.OrderBy(func),
                new List<T>() as IEnumerable<T>, true);
        }

        public static IEnumerable<T> Distinct<T>(IEnumerable<T> list) {
            return Safe.Run(list.Distinct,
                new List<T>(), true);
        }

        public static IEnumerable<TTo> Convert<TFrom, TTo>(IEnumerable<TFrom> list,
            Func<TFrom, TTo> func) {
            return Safe.Run(() => list.Select(func),
                new List<TTo>(), true);
        }
    }
}




