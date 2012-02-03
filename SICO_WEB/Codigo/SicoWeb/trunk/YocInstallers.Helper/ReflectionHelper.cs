using System;
using System.Collections.Generic;
using System.Linq;

namespace YocInstallers.Helper
{
    public static class ReflectionHelper
    {
        public static IEnumerable<Type> GetTypes<TImplement>(Func<Type, bool> predicate)
        {
            return typeof(TImplement).Assembly.GetTypes().Where(predicate);
        }

        public static IEnumerable<Type> GetTypes(Type type ,  Func<Type, bool> predicate)
        {
              return type .Assembly.GetTypes().Where(predicate);
        }


         
        public static Type GetInterace<TImplement>(string likeName)
        {
            return GetTypes<TImplement>(f => f.IsInterface && f.Name.Contains(likeName)).FirstOrDefault();
        }

        public static Type GetImplementationForService<TImplement>(Type service)
        {
            return GetTypes<TImplement>(j => j.GetInterface(service.Name) != null).FirstOrDefault();
        }

    }
}
