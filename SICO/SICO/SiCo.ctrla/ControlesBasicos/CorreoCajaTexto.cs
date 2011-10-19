using System.ComponentModel;

namespace SiCo.ctrla
{
    public partial class CorreoCajaTexto : CajaTexto
    {
        public CorreoCajaTexto()
        {
            InitializeComponent();
            DarValidacion();
        }

        public CorreoCajaTexto(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            DarValidacion();
        }

        private void DarValidacion()
        {
            base.ExpresionValidacion =
                "^([a-zA-Z0-9_\\-])([a-zA-Z0-9_\\-\\.]*)@(\\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\\.){3}|((([a-zA-Z0-9\\-]+)\\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\\])$";
            MensajeError = "El correo electrónico debe tener este formato: abc@dominio.com";
            TipoTexto = TiposTexto.Alfanumerico;
        }
    }
}