using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using SicoWeb.Dominio.Core.Entidades.Mantenimientos;

namespace YoCInstallers.Core
{
   public class PersistenceFacility : AbstractFacility
	{
		protected override void Init()
		{
			var config = BuildDatabaseConfiguration();

			if (System.Web.HttpContext.Current !=null )
			
				Kernel.Register(
				Component.For<ISessionFactory>()
					.UsingFactoryMethod(x=> config.BuildSessionFactory()),
				Component.For<ISession>()
					.UsingFactoryMethod(k => k.Resolve<ISessionFactory>().OpenSession())
					.LifestylePerWebRequest()
				);
			
			else
			
				Kernel.Register(
				Component.For<ISessionFactory>()
					.UsingFactoryMethod(_ => config.BuildSessionFactory()),
				Component.For<ISession>()
					.UsingFactoryMethod(k => k.Resolve<ISessionFactory>().OpenSession())
					.LifestyleTransient() 
				);
			

		}

		
		protected virtual IPersistenceConfigurer SetupDatabase()
		{
			return MySQLConfiguration.Standard
				.UseOuterJoin()
				.ConnectionString(x=>x.FromConnectionStringWithKey("BddKey"))
				.ShowSql();
		}

		private Configuration BuildDatabaseConfiguration()
		{
			return Fluently.Configure()
				.Database(SetupDatabase)
				.Mappings(m => m.FluentMappings.AddFromAssemblyOf<EntiMarcas>())
				.ProxyFactoryFactory<NHibernate.Bytecode.DefaultProxyFactoryFactory>()
				.BuildConfiguration();
		}

	}
}
