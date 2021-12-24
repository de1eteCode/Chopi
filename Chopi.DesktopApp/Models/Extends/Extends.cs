using Chopi.DesktopApp.Models.ObjectSorting;
using Chopi.Modules.Share.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Chopi.DesktopApp.Models.Extends
{
    static class LinqExtends
    {
        public static void ForEach<T>(this IEnumerable<T> collecion, Action<T> action)
        {
            foreach (var item in collecion)
            {
                action(item);
            }
        }

        public static IEnumerable<T> Filtered<T>(this IEnumerable<T> entities, Filter filter, string search)
            where T : ObjectConteinered
        {
            return entities.Where(e => filter.IsEqual(e, search));
        }

        public static IEnumerable<T> Pagging<T>(this IEnumerable<T> entities, int start, int count)
        {
            return entities.Skip(start).Take(count);
        }

        public static IEnumerable<T> Ordering<T>(this IEnumerable<T> entities, Sorting sort, string property)
            where T : ObjectConteinered
        {
            return sort.Order(entities, property);
        }
    }

    static class ObjectCopy
    {
        public static T? CopyObj<T>(this object obj)
        {
            var json = JsonSerializer.Serialize(obj);
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
