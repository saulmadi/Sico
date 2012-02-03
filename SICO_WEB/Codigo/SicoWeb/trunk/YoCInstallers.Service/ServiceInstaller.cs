using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SicoWeb.Aplicacion.ServiceLayer;

namespace YoCInstallers.Service
{
    public class ServiceInstaller:IWindsorInstaller 
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.FromAssemblyContaining<IEntidadServicio>().Pick().If(
                    c => c.Namespace != null && c.Namespace.Contains("Servicios"))
                    .WithServiceDefaultInterfaces()
                    .LifestyleTransient());
        }
    }
}