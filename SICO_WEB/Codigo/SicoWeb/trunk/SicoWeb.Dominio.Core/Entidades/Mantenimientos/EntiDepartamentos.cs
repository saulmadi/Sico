using System.Collections.Generic;

namespace SicoWeb.Dominio.Core.Entidades.Mantenimientos
{
    public partial class EntiDepartamentos:IEntiMantenimientosComplejosPadres 
    {
        public virtual IList<IEntiMantenimientosClomplejosHijos> Hijos
        {
            get { return EntiMunicipios.ToEntiMantenimientosComplejosHijosList();  }
            set { EntiMunicipios=value.ToEntiMantenimientos<EntiMunicipio>(); }
        }
    }
}