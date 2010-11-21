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

        public void SetValidacion()
        {
            this.ExpresionValidacion = "[0-1][0-8][0-9][0-9]-[1-2][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9][0-9]";
            this.MensajeError = "El número de identida debe tener este formato: 0301-1933-00232";
            this.TipoTexto = TiposTexto.Alfanumerico;  
        }

    }
}
