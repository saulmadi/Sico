using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SicoWeb.Dominio.Core.Transaction;
using SicoWeb.Infraestructura.DataLayer.Transaction; 


namespace YoCInstallers.Core
{
    public class UnitOfWorkInstaller:IWindsorInstaller 
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IGenericTransactionFactory>().AsFactory())
                .Register(
                    Component.For<IGenericTransaction>().ImplementedBy<GenericTransaction>().Named("GenericTransaction")
                        .LifestylePerWebRequest())
                .Register(Component.For<IUnitOfWork>().ImplementedBy<UnitOfWork>().LifestylePerWebRequest());
        }
    }
}