using System.Linq;
using Castle.Core;
using Castle.Core.Internal;
using Castle.Facilities.TypedFactory;

using Castle.Windsor;
using NUnit.Framework;
using SicoWeb.Dominio.Core.BuisnessRules;
using SicoWeb.Dominio.Core.BuisnessRules.Mantenimientos;
using SicoWeb.Dominio.Core.Entidades.Mantenimientos;
using SicoWeb.Dominio.Core.Querys;
using SicoWeb.Dominio.Core.Repositorio.Errores;
using YoCInstallers.Core;

namespace YocInstallers.Repositorios.Test
{
    [TestFixture]
    public class BuisnesRuleInstallerTest
    {
        [TestFixture]
        public class QueryInstallerTest : YoCInstallers.Test.BaseTest<IBuisnessRule<EntiDepartamentos>>
        {

            private IWindsorContainer _container;

            [SetUp]
            public void Init()
            {
                _container = new WindsorContainer().AddFacility<TypedFactoryFacility>()
                    .Install(new BuisnessRulesInstallers());

            }

            [Test]
            public void All_Enti_implement_IQuery()
            {
                var allHandlers = GetAllHandlers(_container)
                    .ToList();
                var controllerHandlers = GetHandlersFor(typeof(IBuisnessRule<>), _container);

                Assert.IsNotEmpty(allHandlers);
                CollectionAssert.AreEqual(allHandlers, controllerHandlers);
            }


            [Test]
            public void Resolve_Componet()
            {
                _container.Install(new RepositoryInstallers());
                _container.AddFacility<PersistenceFacility>();
                _container.Install(new QueryInstaller());
                var factory = _container.Resolve<ISicoWebCoreExceptionFactory>();
                var ex = factory.CreateSicoWebCoreException(1, _container.Resolve<IRepositorioEntiErrores>());
                var rule = _container.Resolve<IBuisnessRuleMantenimientosSinDescripcionRepetida<EntiDepartamentos>>();
                var ruleMannager =_container.Resolve<IBuisnessRulesMannagerMantenimientos<EntiDepartamentos>>();

                Assert.IsNotNull(rule );
                Assert.IsNotNull(factory);
                Assert.IsNotNull(ex);
                Assert.IsNotNull(ruleMannager);


            }

            [Test]
            public void All_Querys_are_registered()
            {
                // Is<TType> is an helper, extension method from Windsor
                // which behaves like 'is' keyword in C# but at a Type, not instance level
                var allControllers = GetPublicClassesFromApplicationAssembly(c => c.Is<IQuery>());
                var registeredControllers = GetImplementationTypesFor(typeof (IQuery), _container);
                Assert.AreEqual(allControllers, registeredControllers);
                CollectionAssert.AreEqual(allControllers, registeredControllers);
            }


            [Test]
            public void All_and_only_query_have_query_prefix()
            {
                var allControllers = GetPublicClassesFromApplicationAssembly(c => c.Name.StartsWith("Query"));
                var registeredControllers = GetImplementationTypesFor(typeof (IQuery), _container);
                Assert.AreEqual(allControllers, registeredControllers);
            }

            [Test]
            public void All_and_only_query_live_in_enti_namespace()
            {
                var allControllers = GetPublicClassesFromApplicationAssembly(c => c.Namespace.Contains(".Core.Query"));
                var registeredControllers = GetImplementationTypesFor(typeof (IQuery), _container);
                Assert.AreEqual(allControllers, registeredControllers);
            }


            [Test]
            public void All_Querys_are_transient()
            {
                var nonTransientControllers = GetHandlersFor(typeof (IQuery), _container)
                    .Where(controller => controller.ComponentModel.LifestyleType != LifestyleType.Transient)
                    .ToArray();

                Assert.IsEmpty(nonTransientControllers);
            }
        }
    }
}
