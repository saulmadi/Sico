using System;
using System.Collections.Generic;
using NUnit.Framework;
using SicoWeb.Dominio.Core.BuisnessRules.Mantenimientos ;
using SicoWeb.Dominio.Core.BuisnessRules;
using SicoWeb.Dominio.Core.Entidades.Mantenimientos;
using Rhino.Mocks;
using SicoWeb.Dominio.Core.Querys.Mantenimientos;
using SicoWeb.Dominio.Core.Repositorio;
using SicoWeb.Dominio.Core.Repositorio.Errores;
using System.Linq ;
namespace SicoWeb.Dominio.Core.Test.BuisnessRules.Mantenimientos
{
    [TestFixture]
    public class BuisnesRuleMantenimientosSinDescripcionRepetidaTest
    {
        private IBuisnessRuleMantenimiento<FackeEnti> _buisnessRuleMantenimiento;
        private ISicoWebExceptionFactory _exceptionFactory;
        private IRepositorioEntiErrores _repositorioEntiErrores;
        private IRepository<FackeEnti> _repository;
        private IQueryFindByDescripcion<FackeEnti> _queryFindByDescripcion;
        private SicoWebCoreException _coreException;
        private List<FackeEnti> _list; 
        [SetUp]
        public void Init()
        {
            _exceptionFactory = MockRepository.GenerateMock<ISicoWebExceptionFactory>();
            _repositorioEntiErrores = MockRepository.GenerateMock<IRepositorioEntiErrores>();
            _repository = MockRepository.GenerateMock<IRepository<FackeEnti>>();
            _queryFindByDescripcion = MockRepository.GenerateMock<IQueryFindByDescripcion<FackeEnti>>();
            _coreException = new SicoWebCoreException(0, _repositorioEntiErrores);

            _list = new List<FackeEnti> {new FackeEnti() {Descripcion = "descripcion"},new FackeEnti() {Descripcion="descripcion"}};


            _buisnessRuleMantenimiento =
                new BuisnessRuleMantenimientosSinDescripcionRepetida<FackeEnti>(_exceptionFactory,
                                                                                _repositorioEntiErrores, _repository,
                                                                                _queryFindByDescripcion);
        }

       
        
        [TestCase("descripcion",1),ExpectedException(typeof(SicoWebCoreException)) ]
        public void Comportamiento_VariosResultados_ThrowSicoWebExepcion(string descripcion,int errorCode)
        {
            
            var mockery = _repository.GetMockRepository();
            using (mockery.Record())
            {
                _coreException.ErrorCode = errorCode;
                _coreException.ErrorDescripcion = descripcion;
                _repository.Expect(c => c.FindAll(_queryFindByDescripcion.GetQueryByDescripcion(descripcion))).Return(
                    _list);
                _exceptionFactory.Expect(f => f.CreateSicoWebCoreException(errorCode, _repositorioEntiErrores)).Return(
                   _coreException  );
            }
            using (mockery.Playback())
            {
                var fakeEnti = new FackeEnti { Descripcion = descripcion, Id=1 };
                _buisnessRuleMantenimiento.Comportamiento(fakeEnti);
            }
        }

        [TestCase("descripcion", 1,1)]
        public void Comportamiento_MismaDescripcionMismoId_DejaPasar(string descripcion, int errorCode,int id)
        {
            _list.RemoveAt(0);
            _list.First().Id = id;
            var mockery = _repository.GetMockRepository();
            using (mockery.Record())
            {
                _coreException.ErrorCode = errorCode;
                _coreException.ErrorDescripcion = "descripcion error";
                _repository.Expect(c => c.FindAll(_queryFindByDescripcion.GetQueryByDescripcion(descripcion))).Return(
                    _list);
                _exceptionFactory.Expect(f => f.CreateSicoWebCoreException(errorCode, _repositorioEntiErrores)).Return(
                   _coreException);
            }
            using (mockery.Playback())
            {
                var fakeEnti = new FackeEnti { Descripcion = descripcion ,Id=id};
                _buisnessRuleMantenimiento.Comportamiento(fakeEnti);
            }
        }


    }

    public class FackeEnti :IEntiMantenimientos
    {
        public int Id { get; set; }
        public int Usu { get; set; }
        public DateTime Fmodif { get; set; }
        public string Descripcion { get; set; }
        public bool Habilitado { get; set; }
    }
}