using System;
using System.Collections.Generic;

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
    }
}
