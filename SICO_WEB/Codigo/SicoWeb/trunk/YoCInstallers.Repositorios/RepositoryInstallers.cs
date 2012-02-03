using Castle.Core.Internal;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SicoWeb.Dominio.Core.Entidades;
using SicoWeb.Dominio.Core.Entidades.Mantenimientos;
using SicoWeb.Dominio.Core.Repositorio;
using SicoWeb.Infraestructura.DataLayer.Repositorio;
using YocInstallers.Helper;

namespace YoCInstallers.Core
{
    public class RepositoryInstallers : IWindsorInstaller
    {

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.FromAssemblyContaining<EntiMarcas>().
                    BasedOn<IEntiBase>().
                    LifestyleTransient());

            ReflectionHelper.GetTypes(typeof (IRepository<>), f => f.IsInterface && f.Name.Contains("RepositorioEnti")).
                ForEach(
                    k =>
                    container.Register(
                        Component.For(k).ImplementedBy(
                            ReflectionHelper.GetImplementationForService<ARepository<EntiMarcas>>(k)).Forward(
                                typeof (IRepository<IEntiBase>))
                            .LifestyleTransient()));

            container.Register(
                Component.For<IEntiMantenimientosFactory>().
                    AsFactory().
                    LifestyleTransient());
        }

        
    }
}