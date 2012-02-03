using System;
using System.Linq.Expressions;
using NHibernate.Criterion;
using SicoWeb.Dominio.Core.Entidades.Mantenimientos;

namespace SicoWeb.Dominio.Core.Querys.Mantenimientos
{
    public abstract class AQueryMantenimiento<TEnti>:IQueryMantenimientos<TEnti> where TEnti :IEntiMantenimientos
    {
     
        public DetachedCriteria GetQuery()
        {
            return DetachedCriteria.For<TEnti>().Add( new Disjunction().Add(Where));
        }
        
        public abstract Expression<Func<TEnti, bool>> Where { get; }
    }
}