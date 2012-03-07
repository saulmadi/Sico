using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using SicoWeb.Dominio.Core.Entidades.Mantenimientos;
using SicoWeb.Dominio.Core.Transaction;
using SicoWeb.Infraestructura.DataLayer.Transaction;

namespace YoCInstallers.Core
{
   public class PersistenceFacility : AbstractFacility
	{
		protected override void Init()
		{
			var config = BuildDatabaseConfiguration();

			if (System.Web.HttpContext.Current != null)
			{
				Kernel.Register(
					Component.For<ISessionFactory>()
						.UsingFactoryMethod(x => config.BuildSessionFactory()).LifestyleSingleton(),
					Component.For<ISession>()
						.UsingFactoryMethod(kernel => kernel.Resolve<ISessionFactory>().OpenSession())
						.LifestylePerWebRequest() 
					);
				Kernel.Register(Component.For<ISessionMannager>().ImplementedBy<SessionMannager>().LifestylePerWebRequest());
				Kernel.Register(Component.For<ISessionResolver>().AsFactory().LifestyleTransient() );
			}

			else
			{
				Kernel.Register(
					Component.For<ISessionFactory>()
						.UsingFactoryMethod(l => config.BuildSessionFactory()),
					Component.For<ISession>()
						.UsingFactoryMethod(k => k.Resolve<ISessionFactory>().OpenSession())
						.LifestyleTransient()
					);
				Kernel.Register(Component.For<ISessionMannager>().ImplementedBy<SessionMannager>().LifestyleTransient());
				Kernel.Register(Component.For<ISessionResolver>().AsFactory().LifestyleTransient());
			}

		}
	   protected virtual IPersistenceConfigurer SetupDatabase()
	   {
		   return MySQLConfiguration.Standard
			   .UseOuterJoin()
			   .ConnectionString(x => x.FromConnectionStringWithKey("BddKey")).AdoNetBatchSize( 100)
			   .ShowSql();

	   }

		private Configuration BuildDatabaseConfiguration()
		{
			return Fluently.Configure()
				.Database(SetupDatabase)
				.Cache(c=>c.UseQueryCache().UseMinimalPuts())
				.Mappings(m => m.FluentMappings.AddFromAssemblyOf<EntiMarcas>())
				.ProxyFactoryFactory<NHibernate.Bytecode.DefaultProxyFactoryFactory>()
				.CurrentSessionContext<NHibernate.Context.WebSessionContext>()
				.BuildConfiguration();
		}

	}
}
