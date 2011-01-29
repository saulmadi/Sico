using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SiCo.ctrla
{
    public partial class IdentidadCajaTexto : CajaTexto
    {
        #region Declaraciones
        private lgla.TipoIdentidad _TipoIdentificacion = new SiCo.lgla.TipoIdentidad();
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

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SiCo.lgla.TipoIdentidad TipoIdentificacion
        {
            get { return _TipoIdentificacion; }
            set
            {
                _TipoIdentificacion = value;
                switch (value.Valor)
                {
                    case "I":
                        this.ExpresionValidacion = "[0-1][0-8][0-9][0-9]-[1-2][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9][0-9]";
                        this.MaxLength = 13;
                        this.Enabled = true;
                        this.TipoTexto = TiposTexto.Entero;
                        break;
                    case "R":
                        this.ExpresionValidacion = "";
                        this.MaxLength = 45;
                        this.TipoTexto = TiposTexto.Alfanumerico;
                        this.Enabled = true;
                        break;

                }

            }
        }
        #endregion

        #region Metodos
        public void SetValidacion()
        {
            this.ExpresionValidacion = "[0-1][0-8][0-9][0-9]-[1-2][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9][0-9]";
            this.MensajeError = "El número de identida debe tener este formato: 0301-1933-00232 o no puede ser vacía";
            this.TipoTexto = TiposTexto.Entero;
            this.MaxLength = 13;
            this.TipoIdentificacion = new SiCo.lgla.TipoIdentidad("Identidad", "I");
            this.Leave += new EventHandler(IdentidadCajaTexto_Leave);
            this.Enter += new EventHandler(IdentidadCajaTexto_Enter);

        }
        #endregion

        #region Eventos
        void IdentidadCajaTexto_Enter(object sender, EventArgs e)
        {
            this.Text = this.Text.Replace("-", "");
        }

        void IdentidadCajaTexto_Leave(object sender, EventArgs e)
        {
            if (this.TipoIdentificacion.Valor == "I")
            {
                if (this.Text.Length == 13)
                {
                    this.MaxLength = 15;
                    string t = this.Text.Substring(0, 4);
                    t += "-";
                    t += this.Text.Substring(4, 4);
                    t += "-";
                    t += this.Text.Substring(8, 5);
                    this.Text = t;
                }
            }
        }

        #endregion                 

    }
}
