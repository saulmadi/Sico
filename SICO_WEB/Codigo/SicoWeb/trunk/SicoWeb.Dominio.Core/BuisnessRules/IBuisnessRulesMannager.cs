namespace SicoWeb.Dominio.Core.BuisnessRules
{
    public interface IBuisnessRulesMannager<in T>
    {
        void RunComportamiento(T entidad);
    }
}