using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kresleni22Maui
{
    internal static class Rozsireni
    {
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {   
            if (source == null || source.Count() == 0)
                return source;
            foreach (T item in source)
                action(item);
            return source;
        }
    }
}
