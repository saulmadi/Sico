using System.Linq;
using Castle.Facilities.TypedFactory;
using Castle.Windsor;
using NHibernate;
using NUnit.Framework;
using SicoWeb.Dominio.Core.Entidades.Mantenimientos;
using YoCInstallers.Core;
using YoCInstallers.Test;

namespace YocInstallers.Repositorios.Test
{
    public class NhibernateInstallerTest:BaseTest<ISession>
    {

        private IWindsorContainer _containerWithControllers;

        [SetUp]
        public void Init()
        {
            _containerWithControllers = new WindsorContainer().AddFacility<TypedFactoryFacility>().AddFacility<PersistenceFacility>();

        }

        [Test]
        public void Resolve_Componet()
        {
            var valor = _containerWithControllers.Resolve<ISession>();

            
            //var lista =valor.QueryOver<Mantenimientos>().Where(d => d.Id > 0).List<IEntiBase>();

            using (var tra =valor.BeginTransaction())
            {
                var muni = new EntiMunicipio {Descripcion = "ddssdds", Habilitado = true, Padre = {Id = 1}};
                valor.SaveOrUpdate(muni);
                tra.Commit();
            }
            

            
            Assert.IsNotNull(valor);
            //CollectionAssert.IsNotEmpty(lista);
        }
       
    }
}