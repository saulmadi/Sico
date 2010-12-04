using System;
using System.Collections.Generic;
using System.Text;

namespace SiCo.ctrla

{
    public class Validador
    {
        #region Propiedades
        public List<CajaTexto> ColecionCajasTexto
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public bool PermitirIngresar
        {
            get;
            set;
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
                    this.MensajesError+=  txt.MensajeError + "\n" ;   
                }
            }

            return flag;
        }
        #endregion

    }
}

