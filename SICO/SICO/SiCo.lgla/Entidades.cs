using System;
using System.Collections.Generic;
using System.Text;

namespace SiCo.lgla
{
    public abstract class Entidades : Entidad
    {

        #region Declaraciones

        #endregion

        #region Constructores

        public Entidades():base()
        {
            
            
        }       

        #endregion

        #region Propiedades

        public int? telefono
        {
            get;
            set;
        }

        public string direccion
        {
            get;
            set;
        }

        public string correo
        {
            get;
            set;
        }

        public string  rtn
        {
            get;
            set;
        }

        #endregion

        #region Eventos


        #endregion      

        #region Metodos

        protected override  void CargadoPropiedades()
        {
            if (this.TotalRegistros > 0)
            {
                base.CargadoPropiedades();
                telefono = (int)PrimerRegistro("telefono");                
                direccion = PrimerRegistro("direccion").ToString();
                correo = PrimerRegistro("correo").ToString();
                rtn = (string)PrimerRegistro("RTN");                
            }

 
        }

        #endregion

    }
}
