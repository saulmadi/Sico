namespace SicoWeb.Dominio.Core.Entidades.Mantenimientos
{
    public partial class EntiMunicipio:IEntiMantenimientosClomplejosHijos
    {
        public virtual IEntiMantenimientosComplejosPadres Padre
        {
            get { return EntiDepartamentos; }
            set { EntiDepartamentos = (EntiDepartamentos) value; }
        }
    }
}