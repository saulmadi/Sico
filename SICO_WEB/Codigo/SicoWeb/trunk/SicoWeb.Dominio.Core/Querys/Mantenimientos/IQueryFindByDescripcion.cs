using System;
using NHibernate.Criterion;
using SicoWeb.Dominio.Core.Entidades.Mantenimientos;

namespace SicoWeb.Dominio.Core.Querys.Mantenimientos
{
    public interface IQueryFindByDescripcion<TEnti>:IQueryMantenimientos<TEnti>
        where TEnti :IEntiMantenimientos
    {
        [Obsolete]
        new DetachedCriteria GetQuery();
        DetachedCriteria GetQueryByDescripcion(string descripcion);
    }
}