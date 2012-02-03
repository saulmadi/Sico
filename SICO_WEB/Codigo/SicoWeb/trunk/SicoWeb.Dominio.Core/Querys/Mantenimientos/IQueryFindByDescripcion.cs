using NHibernate.Criterion;
using SicoWeb.Dominio.Core.Entidades.Mantenimientos;

namespace SicoWeb.Dominio.Core.Querys.Mantenimientos
{
    public interface IQueryFindByDescripcion<TEnti>:IQueryMantenimientos<TEnti>
        where TEnti :IEntiMantenimientos
    {
        DetachedCriteria GetQueryByDescripcion(string descripcion);
    }
}