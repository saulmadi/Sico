using SicoWeb.Dominio.Core.Entidades.Mantenimientos;

namespace SicoWeb.Dominio.Core.Querys.Mantenimientos
{
    public interface IQueryHabilitado<TEntiMantenimiento>:IQueryMantenimientos<TEntiMantenimiento> where TEntiMantenimiento :IEntiMantenimientos 
    {
         
    }
}