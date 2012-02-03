using System.Web.Mvc;
using System.Web.Routing;
using Castle.Facilities.TypedFactory;
using Castle.Windsor;
using SicoWeb.Installers;
using SicoWeb.Plumbing;
using YoCInstallers.Core;
using YoCInstallers.Service;

namespace SicoWeb
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });
            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Inicio", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
         
            
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            BootstrapContainer();
        }

        protected void Application_End()
        {
            _container.Dispose();
        } 

        private static IWindsorContainer _container;

        private static void BootstrapContainer()
        {
            _container = new WindsorContainer()
                .AddFacility<PersistenceFacility>()
                .AddFacility<TypedFactoryFacility>()
                .Install(new ControllerInstaller())
                .Install(new RepositoryInstallers())
                .Install(new QueryInstaller())
                .Install( new ServiceInstaller())
                .Install(new UnitOfWorkInstaller());
                
                
            var controllerFactory = new WindsorControllerFactory(_container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);

        }

        

    }
}