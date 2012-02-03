using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SicoWeb.Controllers;

namespace SicoWeb.Installers
{
    public class ControllerInstaller:IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.FromAssemblyContaining<InicioController>().BasedOn<IController>().LifestyleTransient());
        }
       
    }
}