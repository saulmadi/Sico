using NHibernate.Criterion;

namespace SicoWeb.Dominio.Core.Querys
{
    public interface IQuery
    {
        DetachedCriteria GetQuery();
    }
}