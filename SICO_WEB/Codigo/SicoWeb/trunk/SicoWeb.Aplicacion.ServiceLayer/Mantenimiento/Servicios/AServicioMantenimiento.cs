using System;
using System.Collections.Generic;
using NHibernate.Criterion;

using SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Entidades;

using SicoWeb.Dominio.Core.Entidades.Mantenimientos;
using SicoWeb.Dominio.Core.Querys;
using SicoWeb.Dominio.Core.Repositorio.Mantenimientos;
using SicoWeb.Dominio.Core.Transaction;
using SicoWeb.Dominio.Core.BuisnessRules.Mantenimientos;

namespace SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Servicios
{
    public class AServicioMantenimiento<TEntidadServicio, TEntidadMantenimiento> :
        AServicio<TEntidadServicio, TEntidadMantenimiento>, IServicioMantenimiento<TEntidadServicio>
        where TEntidadServicio : IEntidadServicioMantenimiento, new()
        where TEntidadMantenimiento : IEntiMantenimientos, new()
    {
        private readonly IRepositorioMantimientos<TEntidadMantenimiento> _repositorioMantimientos;
        private readonly IEntiMantenimientosFactory _entiMantenimientosFactory;
        private readonly IQuery _queryDeshabilitado;
        private readonly IQuery _queryHabilitado;


        public AServicioMantenimiento(IRepositorioMantimientos<TEntidadMantenimiento> repositorioMantimientos,
                                      IEntiMantenimientosFactory entiMantenimientosFactory,
                                      IQuery queryDeshabilitado,
                                      IQuery queryHabilitado,
                                      IUnitOfWork unitOfWork,
                                      IBuisnessRulesMannagerMantenimientos<TEntidadMantenimiento>
                                          buisnessRulesMannagerMantenimientos

            )
            : base(buisnessRulesMannagerMantenimientos,unitOfWork)
        {
            if (repositorioMantimientos == null) throw new ArgumentNullException("repositorioMantimientos");
            if (entiMantenimientosFactory == null) throw new ArgumentNullException("entiMantenimientosFactory");
            if (queryDeshabilitado == null) throw new ArgumentNullException("queryDeshabilitado");
            if (queryHabilitado == null) throw new ArgumentNullException("queryHabilitado");

            _repositorioMantimientos = repositorioMantimientos;
            _entiMantenimientosFactory = entiMantenimientosFactory;
            _queryDeshabilitado = queryDeshabilitado;
            _queryHabilitado = queryHabilitado;
        }


        public IList<TEntidadServicio> GetHabilitados()
        {
            return GetList(RunQuery(_queryHabilitado));
        }

        public IList<TEntidadServicio> GetDesHabilitados()
        {
            return GetList(RunQuery(_queryDeshabilitado));
        }

        public IList<TEntidadServicio> GetTodos()
        {
            return GetList(RunQuery(null));
        }

        public TEntidadServicio GetById(int id)
        {
            return _repositorioMantimientos.Get(id).ToEntidadServicioMantenimiento<TEntidadServicio>();
        }

        public void AgregarMantenimiento(TEntidadServicio mantenimiento)
        {
            var entiMatenimiento = Convert(mantenimiento);
            SetCambios(() => _repositorioMantimientos.SaveOrUpdate(entiMatenimiento));
            RunRules(entiMatenimiento);
        }

        private ICollection<TEntidadMantenimiento> RunQuery(IQuery query)
        {
            return query == null
                       ? _repositorioMantimientos.FindAll((DetachedCriteria) null, null)
                       : _repositorioMantimientos.FindAll(query.GetQuery());
        }

        private IList<TEntidadServicio> GetList(ICollection<TEntidadMantenimiento> collection)
        {
            return collection.ToListOfEntidadMantenimiento<TEntidadServicio, TEntidadMantenimiento>();
        }

        private TEntidadMantenimiento Convert(TEntidadServicio entidadServicio)
        {
            return entidadServicio.ToEntiMantenimientos<TEntidadMantenimiento>();
        }

        public TEntidadMantenimiento GetNewEntiMantenimiento()
        {
            return _entiMantenimientosFactory.CreateEnti<TEntidadMantenimiento>();
        }

       
    }
}