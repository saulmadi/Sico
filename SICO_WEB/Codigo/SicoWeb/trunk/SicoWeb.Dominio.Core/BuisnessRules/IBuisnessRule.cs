namespace SicoWeb.Dominio.Core.BuisnessRules
{
    public interface IBuisnessRule<in TEntidad>
    {
        void Comportamiento(TEntidad entidad);
    }
}