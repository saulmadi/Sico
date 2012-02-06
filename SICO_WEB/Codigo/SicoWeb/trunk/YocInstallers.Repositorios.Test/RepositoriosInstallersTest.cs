using System.Linq;
using Castle.Core;
using Castle.Core.Internal;
using Castle.Facilities.TypedFactory;
using Castle.Windsor;
using NUnit.Framework;
using SicoWeb.Dominio.Core.Entidades;
using SicoWeb.Dominio.Core.Entidades.Errores;
using SicoWeb.Dominio.Core.Entidades.Mantenimientos;
using SicoWeb.Dominio.Core.Repositorio;
using SicoWeb.Dominio.Core.Repositorio.Mantenimientos.Marcas;
using YoCInstallers.Core;
using YoCInstallers.Test;
using SicoWeb.Infraestructura.DataLayer.Repositorio;  
namespace YocInstallers.Repositorios.Test
{
    [TestFixture]
    public class RepositoriosInstallersTest: BaseTest<IEntiBase>
    {

        private IWindsorContainer _containerWithControllers;

        [SetUp]
        public void Init()
        {
            _containerWithControllers = new WindsorContainer().AddFacility<TypedFactoryFacility>()
                .Install(new RepositoryInstallers());


        }

        [Test]
        public void All_Enti_implement_IEntiBase()
        {
            var allHandlers = GetAllHandlers(_containerWithControllers)
                .Where(c => !c.ToString().Contains("Repo") && c.ToString().Contains("Enti") && !c.ToString().Contains("Factory"))
                .ToList();
            var controllerHandlers = GetHandlersFor(typeof(IEntiBase), _containerWithControllers);

            Assert.IsNotEmpty(allHandlers);
            Assert.AreEqual(allHandlers, controllerHandlers);
        }

        [Test]
        public void All_Repositorios_implement_IRepository()
        {
            var allHandlers = GetAllHandlers(_containerWithControllers).Where(c => c.ToString().Contains("Repo")).ToList();
            var controllerHandlers = GetHandlersFor(typeof(IRepository<IEntiBase>), _containerWithControllers);

            Assert.IsNotEmpty(allHandlers);
            Assert.AreEqual(allHandlers, controllerHandlers);
        }

        [Test]
        public void Resolve_Componet()
        {
            _containerWithControllers.AddFacility<PersistenceFacility>();
            
            var repositorio  = _containerWithControllers.Resolve<IRepositorioEntiMarcas>();
            var repo = _containerWithControllers.Resolve<IRepository<EntiDepartamentos>>();
            var factory = _containerWithControllers.Resolve<IEntiMantenimientosFactory>();
            var entiDepto = factory.CreateEnti<EntiDepartamentos>();

            Assert.IsNotNull(repo);
            Assert.IsNotNull(repositorio);
            Assert.IsNotNull(factory);
            Assert.IsNotNull(entiDepto);
        }

        [Test]
        public void All_Enti_are_registered()
        {
            // Is<TType> is an helper, extension method from Windsor
            // which behaves like 'is' keyword in C# but at a Type, not instance level
            var allControllers = GetPublicClassesFromApplicationAssembly(c => c.Is<IEntiBase>());
            var registeredControllers = GetImplementationTypesFor(typeof(IEntiBase), _containerWithControllers);
            Assert.AreEqual( allControllers, registeredControllers);
            CollectionAssert.AreEqual(allControllers, registeredControllers);
        }

        [Test]
        public void All_Repository_are_registered()
        {
            // Is<TType> is an helper, extension method from Windsor
            // which behaves like 'is' keyword in C# but at a Type, not instance level
            var allControllers = GetPublicClassesFromApplicationAssembly<ARepository<EntiMarcas>>(c => c.Name.Contains("RepositorioEnti" ));
            var registeredControllers = GetImplementationTypesFor(typeof(IRepository<IEntiBase>), _containerWithControllers);
            Assert.AreEqual(allControllers, registeredControllers);
            CollectionAssert.AreEqual(allControllers, registeredControllers);
        }

        [Test]
        public void All_and_only_enti_have_enti_prefix()
        {
            var allControllers = GetPublicClassesFromApplicationAssembly(c => c.Name.StartsWith( "Enti") && !c.Name.EndsWith("Map"));
            var registeredControllers = GetImplementationTypesFor(typeof(IEntiMantenimientos ), _containerWithControllers);
            Assert.AreEqual(allControllers, registeredControllers);
        }

        [Test ]
        public void All_and_only_enti_live_in_enti_namespace()
        {
            var allControllers = GetPublicClassesFromApplicationAssembly(c => c.Namespace.Contains(".Core.Entidades") && !c.Name.EndsWith( "Map"));
            var registeredControllers = GetImplementationTypesFor(typeof(IEntiMantenimientos ), _containerWithControllers);
            Assert.AreEqual(allControllers, registeredControllers);
        }

        [Test]
        public void All_and_only_repositorios_live_in_repositorio_namespace()
        {
            var allControllers = GetPublicClassesFromApplicationAssembly(c => c.Namespace.Contains("Dominio.Core.Repositorio"));
            var registeredControllers = GetImplementationTypesFor(typeof(IRepository<>), _containerWithControllers);
            Assert.AreEqual(allControllers, registeredControllers);
        }

        [Test]
        public void All_Enti_are_transient()
        {
            var nonTransientControllers = GetHandlersFor(typeof(IEntiBase ), _containerWithControllers)
                .Where(controller => controller.ComponentModel.LifestyleType != LifestyleType.Transient)
                .ToArray();

            Assert.IsEmpty(nonTransientControllers);
        }

        [Test]
        public void All_repositori_are_transient()
        {
            var nonTransientControllers = GetHandlersFor(typeof(IRepository<IEntiBase>), _containerWithControllers)
                .Where(controller => controller.ComponentModel.LifestyleType != LifestyleType.Transient)
                .ToArray();

            Assert.IsEmpty(nonTransientControllers);
        }

        
    }
}
