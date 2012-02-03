using System;
using System.Linq.Expressions;
using SicoWeb.Dominio.Core.Entidades.Mantenimientos;

namespace SicoWeb.Dominio.Core.Querys.Mantenimientos
{
    public abstract  class AQueryHabilitado<TEntiMantenimiento>:AQueryMantenimiento<TEntiMantenimiento>,IQueryHabilitado<TEntiMantenimiento> 
        where TEntiMantenimiento :IEntiMantenimientos
    {
        public override Expression<Func<TEntiMantenimiento, bool>> Where
        {
            get { return c=> c.Habilitado==true; }
        }
    }
}