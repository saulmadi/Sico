using System;
using System.Collections.Generic;
using NHibernate.Criterion;
using SicoWeb.Dominio.Core.Entidades.Mantenimientos;
using SicoWeb.Dominio.Core.Querys.Mantenimientos;
using SicoWeb.Dominio.Core.Repositorio;
using SicoWeb.Dominio.Core.Repositorio.Errores;
using System.Linq;

namespace SicoWeb.Dominio.Core.BuisnessRules.Mantenimientos
{
    public class BuisnessRuleMantenimientosSinDescripcionRepetida<TEnti> : ABuisnessRuleMantenimiento<TEnti>,
                                                                           IBuisnessRuleMantenimientosSinDescripcionRepetida
                                                                               <TEnti>
        where TEnti : class, IEntiMantenimientos
    {
        private readonly IQueryFindByDescripcion<TEnti> _byDescripcion;
        private readonly IRepository<TEnti> _repository;


        public BuisnessRuleMantenimientosSinDescripcionRepetida(ISicoWebCoreExceptionFactory coreCoreExceptionFactory,
                                                                 IRepositorioEntiErrores repositorioEntiErrores,
                                                                 IRepository<TEnti> repository,
                                                                 IQueryFindByDescripcion<TEnti> byDescripcion)
            : base(coreCoreExceptionFactory, repositorioEntiErrores)
        {
            _repository = repository;
            _byDescripcion = byDescripcion;
        }

        #region IBuisnessRuleMantenimientosSinDescripcionRepetida<TEnti> Members

        public override void SetRules(TEnti entidad)
        {
            if (entidad == null) throw new ArgumentNullException("entidad");
            var listaItems = GetItemsDescripciones(entidad);
            SetRule(c => HasMultipleItems(listaItems), 1);
        }
       
        private IEnumerable<TEnti> GetItemsDescripciones(TEnti entidad)
        {
            return _repository.FindAll(GetQuery(entidad)) ;
        }

        private DetachedCriteria GetQuery(TEnti entidad)
        {
            var query = _byDescripcion.GetQueryByDescripcion(entidad.Descripcion);
            return query.Add(new Disjunction().Add<TEnti>(c => c.Id != entidad.Id));
        }


        private static bool HasMultipleItems(IEnumerable<TEnti> listaDescripciones)
        {
            if (listaDescripciones == null) throw new ArgumentNullException("listaDescripciones");
            return listaDescripciones.Count() > 0;
        }

        #endregion
    }
}