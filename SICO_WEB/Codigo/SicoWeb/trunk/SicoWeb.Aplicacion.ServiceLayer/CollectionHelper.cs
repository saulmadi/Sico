using System;
using System.Collections.Generic;

namespace SicoWeb.Aplicacion.ServiceLayer
{
    public static class CollectionHelper
    {
        public static ICollection<T> ForEach<T>(this ICollection<T> list, Action<T> action)
        {
            foreach (var variable in list)
            {
                action(variable);
            }
            return list;
        } 
    }
}