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


        public BuisnessRuleMantenimientosSinDescripcionRepetida(ISicoWebExceptionFactory coreExceptionFactory,
                                                                 IRepositorioEntiErrores repositorioEntiErrores,
                                                                 IRepository<TEnti> repository,
                                                                 IQueryFindByDescripcion<TEnti> byDescripcion)
            : base(coreExceptionFactory, repositorioEntiErrores)
        {
            _repository = repository;
            _byDescripcion = byDescripcion;
        }

        #region IBuisnessRuleMantenimientosSinDescripcionRepetida<TEnti> Members

        public override void SetRules(TEnti entidad)
        {
            var listaItems = GetItemsDescripciones(entidad);
            SetRule(c => HasMultipleItems(listaItems), 1);
            SetRule(c => HasOnlyOneItemWithDifId(c, listaItems), 1);
        }
        

        private static bool HasOnlyOneItemWithDifId(TEnti entidad, ICollection<TEnti> listaItems)
        {
            return listaItems.Count ==1 && listaItems.FirstOrDefault(c=>c.Id == entidad.Id) == default(TEnti);
        }

        private ICollection<TEnti> GetItemsDescripciones(TEnti entidad)
        {
            return _repository.FindAll(GetQuery(entidad)) ;
        }

        private DetachedCriteria GetQuery(TEnti entidad)
        {
            return _byDescripcion.GetQueryByDescripcion(entidad.Descripcion);
        }

        private bool HasMultipleItems(ICollection<TEnti> listaDescripciones)
        {
            return listaDescripciones.Count > 1;
        }

        #endregion
    }
}