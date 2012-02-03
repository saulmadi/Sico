using System.Linq;
using Castle.Core;
using Castle.Core.Internal;
using Castle.Windsor;
using NUnit.Framework;

using SicoWeb.Dominio.Core.Querys;
using SicoWeb.Dominio.Core.Querys.Mantenimientos.Departamentos;

using YoCInstallers.Core;

namespace YocInstallers.Repositorios.Test
{
    [TestFixture]
    public class QueryInstallerTest: YoCInstallers.Test.BaseTest<IQuery>
    {

        private IWindsorContainer _container;

        [SetUp]
        public void Init()
        {
            _container = new WindsorContainer()
                .Install(new QueryInstaller());
        }

        [Test]
        public void All_Enti_implement_IQuery()
        {
            var allHandlers = GetAllHandlers(_container)
                .ToList();
            var controllerHandlers = GetHandlersFor(typeof(IQuery), _container);

            Assert.IsNotEmpty(allHandlers);
            CollectionAssert.AreEqual(allHandlers, controllerHandlers);
        }

        
        [Test]
        public void Resolve_Componet()
        {
            var query = _container.Resolve<IQueryDeshabilitadoDepartamentos>();

            
            Assert.IsNotNull(query);


        }

        [Test]
        public void All_Querys_are_registered()
        {
            // Is<TType> is an helper, extension method from Windsor
            // which behaves like 'is' keyword in C# but at a Type, not instance level
            var allControllers = GetPublicClassesFromApplicationAssembly(c => c.Is<IQuery>());
            var registeredControllers = GetImplementationTypesFor(typeof(IQuery), _container);
            Assert.AreEqual(allControllers, registeredControllers);
            CollectionAssert.AreEqual(allControllers, registeredControllers);
        }

       
        [Test]
        public void All_and_only_query_have_query_prefix()
        {
            var allControllers = GetPublicClassesFromApplicationAssembly(c => c.Name.StartsWith("Query"));
            var registeredControllers = GetImplementationTypesFor(typeof(IQuery ), _container);
            Assert.AreEqual(allControllers, registeredControllers);
        }

        [Test]
        public void All_and_only_query_live_in_enti_namespace()
        {
            var allControllers = GetPublicClassesFromApplicationAssembly(c => c.Namespace.Contains(".Core.Query"));
            var registeredControllers = GetImplementationTypesFor(typeof(IQuery), _container);
            Assert.AreEqual(allControllers, registeredControllers);
        }

        
        [Test]
        public void All_Querys_are_transient()
        {
            var nonTransientControllers = GetHandlersFor(typeof(IQuery ), _container)
                .Where(controller => controller.ComponentModel.LifestyleType != LifestyleType.Transient)
                .ToArray();

            Assert.IsEmpty(nonTransientControllers);
        }
       
    }
}