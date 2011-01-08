using System;
using System.Collections.Generic;
using System.Text;

namespace SiCo.ctrla

{
    public class Validador
    {
        #region Declaraciones
        List<CajaTexto> _ColecionCajasTexto = new List<CajaTexto>();
        #endregion

        #region Propiedades
        public  List<CajaTexto> ColecionCajasTexto
        {
            get { return _ColecionCajasTexto; }
            
        }

        public bool PermitirIngresar
        {
            get { return this.Validar(); }           
        }

        public string MensajesError
        {
            get;
            set;
        }

        #endregion 

        #region Metodos
        private bool Validar()
        {
            bool flag = false;
            foreach( CajaTexto  txt in this.ColecionCajasTexto   )
            {
                flag = txt.EsValido;
                flag = !txt.EsVacio;
                if (!flag)
                {
                    this.MensajesError=  txt.MensajeError  ;
                    txt.Focus();
                    return flag;
                }
            }

            return flag;
        }
        #endregion

    }
}

