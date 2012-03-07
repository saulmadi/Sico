using Castle.Facilities.TypedFactory;
using Castle.Windsor;
using NUnit.Framework;
using SicoWeb.Aplicacion.ServiceLayer;
using SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Entidades;
using SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Servicios.Departamentos;
using SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Servicios.Municipios;
using YoCInstallers.Core;
using YoCInstallers.Service;
using YoCInstallers.Test;

namespace YoCInstaller.Servicios.Test
{
    [TestFixture]
    public class ServciosInstallerTest : BaseTest<IServicio>
    {
        private IWindsorContainer _container;

        [SetUp]
        public void Init()
        {
            _container = new WindsorContainer().AddFacility<TypedFactoryFacility>()
                .Install(new ServiceInstaller());

        }




        [Test]
        public void Resolve_Componet()
        {
            _container.Install(new RepositoryInstallers());

            _container.AddFacility<PersistenceFacility>();
            _container.Install(new QueryInstaller());
            _container.Install(new BuisnessRulesInstallers()).Install(new UnitOfWorkInstaller());

            var servicio = _container.Resolve<IServicioMantenimientosDepartamentos>();
            var servicio2 = _container.Resolve<IServicioMantenimientoHijoMunicipios>();
            Assert.IsNotNull(servicio);
        }

    }
}