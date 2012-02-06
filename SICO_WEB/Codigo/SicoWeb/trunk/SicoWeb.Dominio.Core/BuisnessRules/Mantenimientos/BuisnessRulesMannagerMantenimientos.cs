using SicoWeb.Dominio.Core.Entidades.Mantenimientos;

namespace SicoWeb.Dominio.Core.BuisnessRules.Mantenimientos
{
    public class BuisnessRulesMannagerMantenimientos<TEnti> : ABuisnessRuleMannager<TEnti>, IBuisnessRulesMannagerMantenimientos<TEnti> where TEnti : IEntiMantenimientos
    {
        public BuisnessRulesMannagerMantenimientos(IBuisnessRuleMantenimientosSinDescripcionRepetida<TEnti> descripcionRepetida):base(descripcionRepetida)
        {
            
        }
    }
}