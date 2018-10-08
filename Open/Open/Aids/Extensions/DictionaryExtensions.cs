// (c) https://www.codeproject.com/articles/774228/mvc-html-table-helper-part-display-tables

using System;
using System.Collections.Generic;
using System.Linq;
namespace Open.Aids.Extensions {

    public static class DictionaryExtensions {

        public static void RemoveAll<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
            Func<KeyValuePair<TKey, TValue>, bool> predicate) {
            foreach (var item in dictionary.Where(predicate).ToList()) {
                dictionary.Remove(item.Key);
            }
        }

    }
}