using System;
using System.Linq;
using Castle.MicroKernel;
using Castle.Windsor;

namespace YoCInstallers.Test
{
    public abstract  class BaseTest<TBasedOn>
    {

        protected  IHandler[] GetAllHandlers(IWindsorContainer container)
        {
            return GetHandlersFor(typeof(object), container);
        }

        protected IHandler[] GetHandlersFor(Type type, IWindsorContainer container)
        {
            return container.Kernel.GetAssignableHandlers(type);

        }


        protected Type[] GetImplementationTypesFor(Type type, IWindsorContainer container)
        {
            return GetHandlersFor(type, container)
                .Select(h => h.ComponentModel.Implementation)
                .OrderBy(t => t.Name)
                .ToArray();
        }

        protected Type[] GetPublicClassesFromApplicationAssembly(Predicate<Type> where)
        {
            return typeof(TBasedOn).Assembly.GetExportedTypes()
                .Where(t => t.IsClass)
                .Where(t => t.IsAbstract == false)
                .Where(where.Invoke)
                .OrderBy(t => t.Name)
                .ToArray();
        }
        protected Type[] GetPublicClassesFromApplicationAssembly<TBasedOnExternal>(Predicate<Type> where)
        {
            return typeof(TBasedOnExternal).Assembly.GetExportedTypes()
                .Where(t => t.IsClass)
                .Where(t => t.IsAbstract == false)
                .Where(where.Invoke)
                .OrderBy(t => t.Name)
                .ToArray();
        }
    }
}
