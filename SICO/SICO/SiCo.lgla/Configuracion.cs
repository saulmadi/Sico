using System;
using System.Collections.Generic;
using System.Text;
using SiCo.dtla;  

namespace SiCo.lgla
{
    public class Configuracion
    {

    #region Declaraciones   
        private ConexionMySql _configuracion = new ConexionMySql() ;
    #endregion
    #region Propiedades

        public ConexionMySql Config
        {
            get
            {
                return _configuracion ;
            }
            set
            {
                _configuracion=value;
            }
        }

    #endregion

    
 
    }
}
