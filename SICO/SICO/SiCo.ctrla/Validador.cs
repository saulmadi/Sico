using System.Collections.Generic;

namespace SiCo.ctrla

{
    public class Validador
    {
        #region Declaraciones

        private readonly List<CajaTexto> _ColecionCajasTexto = new List<CajaTexto>();

        #endregion

        #region Propiedades

        public List<CajaTexto> ColecionCajasTexto
        {
            get { return _ColecionCajasTexto; }
        }

        public bool PermitirIngresar
        {
            get { return Validar(); }
        }

        public string MensajesError { get; set; }

        #endregion

        #region Metodos

        private bool Validar()
        {
            bool flag = false;
            foreach (CajaTexto  txt in ColecionCajasTexto)
            {
                flag = txt.EsValido();
                if (!flag)
                {
                    MensajesError = txt.MensajeError;
                    txt.Focus();
                    return flag;
                }
                flag = !txt.EsVacio();
                if (!flag)
                {
                    MensajesError = txt.MensajeError;
                    txt.Focus();
                    return flag;
                }
            }

            return flag;
        }

        #endregion
    }
}