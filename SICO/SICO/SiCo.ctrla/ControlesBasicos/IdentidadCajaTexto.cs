using System;
using System.ComponentModel;
using SiCo.lgla;

namespace SiCo.ctrla
{
    public partial class IdentidadCajaTexto : CajaTexto
    {
        #region Declaraciones

        private TipoIdentidad _TipoIdentificacion = new TipoIdentidad();

        #endregion

        #region Constructor

        public IdentidadCajaTexto()
        {
            InitializeComponent();
            SetValidacion();
        }

        public IdentidadCajaTexto(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            SetValidacion();
        }

        #endregion

        #region propiedades

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TipoIdentidad TipoIdentificacion
        {
            get { return _TipoIdentificacion; }
            set
            {
                _TipoIdentificacion = value;
                switch (value.Valor)
                {
                    case "I":
                        ExpresionValidacion = "[0-1][0-8][0-9][0-9]-[1-2][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9][0-9]";
                        MaxLength = 13;
                        Enabled = true;
                        TipoTexto = TiposTexto.Entero;
                        break;
                    case "R":
                        ExpresionValidacion = "";
                        MaxLength = 45;
                        TipoTexto = TiposTexto.Alfanumerico;
                        Enabled = true;
                        break;
                    case "N":
                        Enabled = false;
                        ExpresionValidacion = "";
                        MaxLength = 45;
                        TipoTexto = TiposTexto.Alfanumerico;
                        Text = "";
                        break;
                }
            }
        }

        #endregion

        #region Metodos

        public void SetValidacion()
        {
            ExpresionValidacion = "[0-1][0-8][0-9][0-9]-[1-2][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9][0-9]";
            MensajeError = "El número de identida debe tener este formato: 0301-1933-00232 o no puede ser vacía";
            TipoTexto = TiposTexto.Entero;
            MaxLength = 13;
            TipoIdentificacion = new TipoIdentidad("Identidad", "I");
            Leave += IdentidadCajaTexto_Leave;
            Enter += IdentidadCajaTexto_Enter;
        }

        #endregion

        #region Eventos

        private void IdentidadCajaTexto_Enter(object sender, EventArgs e)
        {
            Text = Text.Replace("-", "");
        }

        private void IdentidadCajaTexto_Leave(object sender, EventArgs e)
        {
            if (TipoIdentificacion.Valor == "I")
            {
                if (Text.Length == 13)
                {
                    MaxLength = 15;
                    string t = Text.Substring(0, 4);
                    t += "-";
                    t += Text.Substring(4, 4);
                    t += "-";
                    t += Text.Substring(8, 5);
                    Text = t;
                }
            }
        }

        #endregion
    }
}