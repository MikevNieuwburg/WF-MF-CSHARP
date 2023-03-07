using System;
using System.Collections.Generic;

namespace MiniForms.Core.Helper
{

    public static class Extension
    {
        public static void ForEach<T>(this IEnumerable<T> @this, Action<T> action)
        {
            foreach (T item in @this)
            {
                action(item);
            }
        }
    }
}

