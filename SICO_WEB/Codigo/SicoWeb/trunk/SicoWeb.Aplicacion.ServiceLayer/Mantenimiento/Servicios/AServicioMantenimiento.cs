using System;
using System.Collections.Generic;
using NHibernate.Criterion;
using SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Entidades;
using SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Helper;
using SicoWeb.Dominio.Core.Entidades.Mantenimientos;
using SicoWeb.Dominio.Core.Querys;
using SicoWeb.Dominio.Core.Repositorio.Mantenimientos;
using SicoWeb.Dominio.Core.Transaction;
using SicoWeb.Dominio.Core.BuisnessRules.Mantenimientos;

namespace SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Servicios
{
    public class AServicioMantenimiento<TEntidadServicio, TEntidadMantenimiento> :
        AServicio<TEntidadMantenimiento>, IServicioMantenimiento<TEntidadServicio>
        where TEntidadServicio :  IEntidadServicioMantenimiento, new()
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
            : base(buisnessRulesMannagerMantenimientos, unitOfWork)
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
            return GetListaWithTransaction(() => GetList(RunQuery(_queryHabilitado)));
        }

        public IList<TEntidadServicio> GetDesHabilitados()
        {
            return GetListaWithTransaction(() => GetList(RunQuery(_queryDeshabilitado)));
        }

        public IList<TEntidadServicio> GetTodos()
        {
            return GetListaWithTransaction( ()=> GetList(RunQuery(null)));
        }

        public TEntidadServicio GetById(int id)
        {
            return id == 0 ? Activator.CreateInstance<TEntidadServicio>() : GetEntidadWithTransaction(() => _repositorioMantimientos.Get(id).ToEntidadServicioMantenimiento<TEntidadServicio>());
        }
        
        public virtual  void AgregarMantenimiento(TEntidadServicio mantenimiento)
        {
            var entiMatenimiento = Convert(mantenimiento);

            SetCambios(() => GuardarMantenimiento(entiMatenimiento));
            RunRules(entiMatenimiento);
        }

        protected TEntidadMantenimiento GuardarMantenimiento(TEntidadMantenimiento entiMatenimiento)
        {

            return _repositorioMantimientos.SaveOrUpdate(entiMatenimiento);
        }

        protected ICollection<TEntidadMantenimiento> RunQuery(IQuery query)
        {
            return query == null
                       ? _repositorioMantimientos.FindAll((DetachedCriteria) null, null)
                       : _repositorioMantimientos.FindAll(query.GetQuery());
        }

        protected virtual IList<TEntidadServicio> GetList(ICollection<TEntidadMantenimiento> collection)
        {
            return collection.ToListOfEntidadMantenimiento<TEntidadServicio, TEntidadMantenimiento>();
        }

        protected virtual TEntidadMantenimiento Convert(TEntidadServicio entidadServicio)
        {
            return entidadServicio.ToEntiMantenimientos<TEntidadMantenimiento>();
        }

        public TEntidadMantenimiento GetNewEntiMantenimiento()
        {
            return _entiMantenimientosFactory.CreateEnti<TEntidadMantenimiento>();
        }


    }
}