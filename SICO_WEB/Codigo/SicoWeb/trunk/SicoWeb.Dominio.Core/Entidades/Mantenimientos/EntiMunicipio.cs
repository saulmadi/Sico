namespace SicoWeb.Dominio.Core.Entidades.Mantenimientos
{
    public partial class EntiMunicipio:IEntiMantenimientosClomplejosHijos
    {
        public virtual IEntiMantenimientosComplejosPadres Padre
        {
            get { return EntiDepartamentos ?? (EntiDepartamentos = new EntiDepartamentos()); }
            set { EntiDepartamentos = (EntiDepartamentos) value; }
        }
    }
}