using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SicoWeb.Dominio.Core.Querys;
using SicoWeb.Dominio.Core.Querys.Mantenimientos;

namespace YoCInstallers.Core
{
    public class QueryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.FromAssemblyContaining<IQuery>().Pick().If(
                    t => t.Namespace != null && t.Namespace.Contains("SicoWeb.Dominio.Core.Querys")).WithServiceDefaultInterfaces().
                    LifestyleTransient());

        }
    }
}