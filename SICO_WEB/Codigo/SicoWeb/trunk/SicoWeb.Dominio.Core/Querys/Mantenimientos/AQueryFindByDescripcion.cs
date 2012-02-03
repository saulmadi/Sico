using System;
using System.Linq.Expressions;
using NHibernate.Criterion;
using SicoWeb.Dominio.Core.Entidades.Mantenimientos;

namespace SicoWeb.Dominio.Core.Querys.Mantenimientos
{
    public abstract class AQueryFindByDescripcion<TEnti>:AQueryMantenimiento<TEnti>,IQueryFindByDescripcion<TEnti>
        where TEnti :IEntiMantenimientos
    {

        private Expression<Func<TEnti, bool>> _where;

        public DetachedCriteria GetQueryByDescripcion(string descripcion)  
        {
            _where = c => c.Descripcion == descripcion;
            return base.GetQuery();
        }

        [Obsolete]
        public  new DetachedCriteria  GetQuery()
        {
            return null;
        }

        public override Expression<Func<TEnti, bool>> Where
        {
            get { return _where ; }
        }
    }
}