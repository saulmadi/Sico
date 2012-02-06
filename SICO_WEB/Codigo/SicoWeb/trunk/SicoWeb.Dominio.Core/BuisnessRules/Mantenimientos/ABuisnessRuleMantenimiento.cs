using System;
using System.Collections.Generic;
using System.Linq;
using SicoWeb.Dominio.Core.Entidades.Mantenimientos;
using SicoWeb.Dominio.Core.Repositorio.Errores;

namespace SicoWeb.Dominio.Core.BuisnessRules.Mantenimientos
{
    public abstract class ABuisnessRuleMantenimiento<TEnti> : ABuisnessRule<TEnti>, IBuisnessRuleMantenimiento<TEnti>
        where TEnti : IEntiMantenimientos
    {
        protected ABuisnessRuleMantenimiento(ISicoWebCoreExceptionFactory coreCoreExceptionFactory,
                                             IRepositorioEntiErrores repositorioEntiErrores)
            : base(coreCoreExceptionFactory, repositorioEntiErrores)
        {
            
        }

        private List<RuleErroCode> _listReglas;

        public void SetRule(Func<TEnti, bool> rule, int errorCode)
        {
            if (_listReglas == null) _listReglas = new List<RuleErroCode>();
            _listReglas.Add( new RuleErroCode {Regla = rule,ErrorCode = errorCode} );
        }

        public abstract void SetRules(TEnti entidad);

        public override void Comportamiento(TEnti entidad)
        {
            SetRules(entidad);
            foreach (var listRegla in _listReglas.Where(listRegla => listRegla.Regla(entidad)))
            {
                ThrowError(listRegla.ErrorCode);
            }
        }

        private class RuleErroCode
        {
            public Func<TEnti , bool> Regla { get; set; }
            public  int ErrorCode { get; set; }
        }

       
    }
}