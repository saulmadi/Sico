using System.Collections.Generic;

namespace SicoWeb.Dominio.Core.Entidades.Mantenimientos
{
    public partial class EntiMarcas:IEntiMantenimientosComplejosPadres
    {
        
        public virtual void  AddHijo(IEntiMantenimientosClomplejosHijos clomplejosHijos)
        {
            EntiModelos.Add((EntiModelos) clomplejosHijos);
        }

        public virtual IList<IEntiMantenimientosClomplejosHijos> Hijos
        {
            get { return EntiModelos.ToEntiMantenimientosComplejosHijosList(); }
            set { EntiModelos = value.ToEntiMantenimientos<EntiModelos>(); }
        }
    }
}