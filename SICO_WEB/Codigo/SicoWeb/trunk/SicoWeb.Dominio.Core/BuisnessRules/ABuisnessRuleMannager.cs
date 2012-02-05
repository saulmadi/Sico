namespace SicoWeb.Dominio.Core.BuisnessRules
{
    public abstract  class ABuisnessRuleMannager<TEnti>:IBuisnessRulesMannager<TEnti>
    {
        private readonly IBuisnessRule<TEnti>[] _buisnessRules;


        protected ABuisnessRuleMannager( params IBuisnessRule<TEnti>[] buisnessRules  )
        {
            _buisnessRules = buisnessRules;
        }

        public void RunComportamiento(TEnti entidad)
        {
            foreach (var buisnessRule in _buisnessRules)
            {
                buisnessRule.Comportamiento(entidad);
            }
        }
    }
}