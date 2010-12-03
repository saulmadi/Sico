﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SiCo.ctrla
{
    public partial class IdentidadCajaTexto : CajaTexto
    {
        private lgla.TipoIdentidad _TipoIdentificacion = new lgla.TipoIdentidad(); 
 

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

        public lgla.TipoIdentidad   TipoIdentificacion
        {
            get { return _TipoIdentificacion; }
            set 
            {
                _TipoIdentificacion = value;
                switch (value.Valor )
                {
                    case "I":
                        this.ExpresionValidacion = "[0-1][0-8][0-9][0-9]-[1-2][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9][0-9]";
                        this.MaxLength = 15;
                        this.Enabled = true ;
                        if (this.Text.Trim() =="Menor de Edad")
                        this.Text = "";
                        break;
                    case "P":
                        this.ExpresionValidacion = "";
                        this.MaxLength = 45;
                        this.Enabled = true;
                        if (this.Text.Trim() =="Menor de Edad")
                        this.Text = "";
                        break;
                    case "M":
                        this.ExpresionValidacion = "";
                        this.MaxLength = 45;
                        this.Enabled=false;
                        this.Text="Menor de Edad";
                        break; 
                }

            }
        }

        public void SetValidacion()
        {
            this.ExpresionValidacion  = "[0-1][0-8][0-9][0-9]-[1-2][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9][0-9]";
            this.MensajeError = "El número de identida debe tener este formato: 0301-1933-00232";
            this.TipoTexto = TiposTexto.Alfanumerico;
            this.TipoIdentificacion = new lgla.TipoIdentidad("Identidad", "I");
        }

    }
}
