using System;
using System.Linq.Expressions;
using SicoWeb.Dominio.Core.Entidades.Mantenimientos;

namespace SicoWeb.Dominio.Core.Querys.Mantenimientos
{
    public abstract class AQueryDeshabilitado<TEnti>:AQueryMantenimiento<TEnti>, IQueryDeshabilitado<TEnti> 
        where TEnti :IEntiMantenimientos
    {
        public override Expression<Func<TEnti, bool>> Where
        {
            get { return c => c.Habilitado == false; }
            protected set { }
        }
        
    }
}