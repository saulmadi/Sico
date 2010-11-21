using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SiCo.ctrla
{
    public partial class CorreoCajaTexto : CajaTexto
    {
        public CorreoCajaTexto()
        {
            InitializeComponent();

            SetValidacion();
        }

        public CorreoCajaTexto(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            SetValidacion();
        }

        private void SetValidacion()
        {
            this.ExpresionValidacion = "^([a-zA-Z0-9_\\-])([a-zA-Z0-9_\\-\\.]*)@(\\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\\.){3}|((([a-zA-Z0-9\\-]+)\\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\\])$";
            this.MensajeError = "El correo electrónico debe tener este formato: abc@dominio.com";
            this.TipoTexto = TiposTexto.Alfanumerico; 
        }
    }
}
