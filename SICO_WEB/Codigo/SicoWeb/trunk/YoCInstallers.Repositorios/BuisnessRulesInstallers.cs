using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SicoWeb.Dominio.Core.BuisnessRules.Mantenimientos;
using SicoWeb.Dominio.Core.BuisnessRules;
using Castle.Facilities.TypedFactory;
namespace YoCInstallers.Core
{
    public class BuisnessRulesInstallers:IWindsorInstaller 
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.FromAssemblyContaining(typeof (IBuisnessRule<>))
                .Where(
                    c => c.Name.Contains("BuisnessRule")).WithServiceDefaultInterfaces().LifestyleTransient());

            container.Register(
                Component .For<SicoWebCoreException>().Named("SicoWebCoreException").LifestyleTransient(),
                               Component.For<ISicoWebCoreExceptionFactory>().AsFactory( ).LifestyleTransient());
        }
    }
}