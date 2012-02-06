using System;
using System.Linq.Expressions;
using NHibernate.Criterion;
using SicoWeb.Dominio.Core.Entidades.Mantenimientos;

namespace SicoWeb.Dominio.Core.Querys.Mantenimientos
{
    public abstract class AQueryFindByDescripcion<TEnti>:AQueryMantenimiento<TEnti>,IQueryFindByDescripcion<TEnti>
        where TEnti :IEntiMantenimientos
    {
        
        public DetachedCriteria GetQueryByDescripcion(string descripcion)  
        {
            Where = c =>c.Descripcion == descripcion;
            return base.GetQuery();
        }
       
        public override Expression<Func<TEnti, bool>> Where { get; protected set; }

    }
}