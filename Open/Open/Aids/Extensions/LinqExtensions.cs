// (c) https://www.codeproject.com/articles/774228/mvc-html-table-helper-part-display-tables

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace Open.Aids.Extensions
{
    public static class LinqExtensions
    {

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            var knownKeys = new HashSet<TKey>();
            foreach (var element in source)
            {
                if (knownKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        public static IEnumerable<T> Flatten<T>(this IEnumerable<T> sequence, Func<T, IEnumerable<T>> childFetcher)
        {
            var itemsToYield = new Queue<T>(sequence);
            while (itemsToYield.Count > 0)
            {
                var item = itemsToYield.Dequeue();
                yield return item;

                var children = childFetcher(item);
                if (children == null) continue;
                foreach (var child in children) itemsToYield.Enqueue(child);
            }
        }

        public static bool IsGrouped(this IEnumerable collection) {
            if (collection is IDictionary) return true;
            if (collection.GetType() == typeof(IDictionary<,>)) return true;
            if (collection.GetType() == typeof(IEnumerable<>) && collection.GetType().GetElementType() == typeof(IGrouping<,>)) return true;
            return false;
        }

    }

}
