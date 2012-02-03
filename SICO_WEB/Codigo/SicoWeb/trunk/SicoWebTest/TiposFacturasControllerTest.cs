using NUnit.Framework;
using SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Servicios.TiposFacturas;
using SicoWeb.Controllers;
using SicoWeb.Plumbing;
using Rhino.Mocks;

namespace SicoWebTest
{
    [TestFixture]
    public class TiposFacturasControllerTest
    {

        private TiposFacturasController _fakeController;
        private IServicioMantenimientosTiposFacturas _fakeTiposFacturas;
        [SetUp]
        public void Init()
        {
            _fakeTiposFacturas = MockRepository.GenerateStub<IServicioMantenimientosTiposFacturas>();
            _fakeController = new TiposFacturasController(_fakeTiposFacturas);
        }

        [Test]
        public void ControladorNoEditable()
        {

            Assert.IsFalse(_fakeController.Editable);
            Assert.IsFalse((bool) _fakeController.ViewData[ViewDataVariables.MantenimientoEditable]);
        }

        [Test]
        public void ControladorNoAgregable()
        {

            Assert.IsFalse(_fakeController.Agregable);
            Assert.IsFalse((bool)_fakeController.ViewData[ViewDataVariables.MantenimientoAgregable]);
        }

        [Test]
        public void ControladorNoEliminable()
        {

            Assert.IsFalse(_fakeController.Agregable);
            Assert.IsFalse((bool)_fakeController.ViewData[ViewDataVariables.MantenimientoAgregable]);
        }

        [Test]
        public void ControllerNameIgualTiposFacturas()
        {
            var expect = _fakeController.GetControllerName();
            Assert.AreEqual("TiposFacturas", expect);
        }

        [Test]
        public void ControllerTitle_Tipos_Facturas()
        {

            var expect = _fakeController.Title();
            Assert.IsNotNull(expect);
            Assert.AreEqual("Tipos Facturas", expect);

        }

        [Test]
        public void ControllerSubTitle_Administrativo()
        {

            var expect = _fakeController.SubTitleMenu();
            Assert.IsNotNull(expect);
            Assert.AreEqual("Administrativo", expect);

        }

        [Test]
        public void Index_llamaTodos()
        {
            var expect = _fakeController.Index();
            _fakeTiposFacturas.AssertWasCalled(c => c.GetTodos());
        }
    }
}
