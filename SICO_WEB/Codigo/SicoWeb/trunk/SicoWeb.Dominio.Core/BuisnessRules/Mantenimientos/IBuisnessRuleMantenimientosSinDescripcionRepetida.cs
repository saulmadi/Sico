using SicoWeb.Dominio.Core.Entidades.Mantenimientos;

namespace SicoWeb.Dominio.Core.BuisnessRules.Mantenimientos
{
    public interface IBuisnessRuleMantenimientosSinDescripcionRepetida< TEnti> : IBuisnessRuleMantenimiento<TEnti>
        where TEnti : IEntiMantenimientos
    {
    }
}