using System;
using SicoWeb.Dominio.Core.Entidades.Mantenimientos;

namespace SicoWeb.Dominio.Core.BuisnessRules.Mantenimientos
{
    public interface IBuisnessRuleMantenimiento<TEnti> : IBuisnessRule<TEnti> where TEnti : IEntiMantenimientos
    {
        
        void SetRule(Func<TEnti, bool> func, int errorCode);
        void SetRules(TEnti entidad);
    }
}