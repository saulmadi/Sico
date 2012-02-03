namespace SicoWeb.Dominio.Core.Entidades.Mantenimientos
{
    public partial class EntiModelos:IEntiMantenimientosClomplejosHijos
    {
       

        public virtual IEntiMantenimientosComplejosPadres Padre 
        {
            get { return EntiMarcas; }
            set { EntiMarcas = (EntiMarcas) value; }
        }
    }
}