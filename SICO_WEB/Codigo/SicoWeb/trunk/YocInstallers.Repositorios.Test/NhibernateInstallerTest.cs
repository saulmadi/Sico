using System.Linq;
using Castle.Core;
using Castle.Core.Internal;
using Castle.Windsor;
using NHibernate;
using NUnit.Framework;
using SicoWeb.Dominio.Core.Entidades;
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
            _containerWithControllers = new WindsorContainer().AddFacility<PersistenceFacility>();

        }

        [Test]
        public void Resolve_Componet()
        {
            var valor = _containerWithControllers.Resolve<ISession>();
            
            var lista =valor.QueryOver<Mantenimientos>().Where(d => d.Id > 0).List<IEntiBase>();

            Assert.IsNotNull(valor);
            CollectionAssert.IsNotEmpty(lista);
        }
       
    }
}