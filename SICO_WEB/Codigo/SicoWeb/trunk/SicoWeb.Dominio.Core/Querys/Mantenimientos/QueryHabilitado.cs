using SicoWeb.Dominio.Core.Entidades.Mantenimientos;

namespace SicoWeb.Dominio.Core.Querys.Mantenimientos
{
    class QueryHabilitado<TEntiMantenimiento> : AQueryHabilitado<TEntiMantenimiento> where TEntiMantenimiento : IEntiMantenimientos
    {
    }
}