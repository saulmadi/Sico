using System;
using System.Linq.Expressions;
using SicoWeb.Dominio.Core.Entidades.Mantenimientos;

namespace SicoWeb.Dominio.Core.Querys.Mantenimientos
{
    public interface IQueryMantenimientos<TEnti> :IQuery 
        where TEnti: IEntiMantenimientos
    {

        Expression<Func<TEnti, bool>> Where { get; }
    }
    
}