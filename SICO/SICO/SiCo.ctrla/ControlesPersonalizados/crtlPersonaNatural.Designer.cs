namespace SiCo.ctrla.ControlesPersonalizados
{
    partial class crtlPersonaNatural
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            SiCo.lgla.TipoIdentidad tipoIdentidad1 = new SiCo.lgla.TipoIdentidad();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cajaTexto1 = new SiCo.ctrla.CajaTexto(this.components);
            this.txtCorreo = new SiCo.ctrla.CorreoCajaTexto(this.components);
            this.txtdireccion = new SiCo.ctrla.CajaTexto(this.components);
            this.txttelefono = new SiCo.ctrla.CajaTexto(this.components);
            this.txtApellidos = new SiCo.ctrla.CajaTexto(this.components);
            this.txtNombre = new SiCo.ctrla.CajaTexto(this.components);
            this.cmbTipoIdentidad = new SiCo.ctrla.ListaDesplegable(this.components);
            this.txtidentifiacion = new SiCo.ctrla.IdentidadCajaTexto(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo identificación";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Identificacion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nombre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Apellidos";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Telefono";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Dirección";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 209);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Correo";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 233);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "RTN";
            // 
            // cajaTexto1
            // 
            this.cajaTexto1.ColorError = System.Drawing.Color.Red;
            this.cajaTexto1.EsObligatorio = false;
            this.cajaTexto1.ExpresionValidacion = null;
            this.cajaTexto1.Location = new System.Drawing.Point(102, 233);
            this.cajaTexto1.MaxLength = 255;
            this.cajaTexto1.MensajeError = null;
            this.cajaTexto1.Name = "cajaTexto1";
            this.cajaTexto1.Size = new System.Drawing.Size(380, 20);
            this.cajaTexto1.TabIndex = 6;
            this.cajaTexto1.Texto = null;
            this.cajaTexto1.TipoTexto = SiCo.ctrla.TiposTexto.Alfanumerico;
            // 
            // txtCorreo
            // 
            this.txtCorreo.ColorError = System.Drawing.Color.Red;
            this.txtCorreo.EsObligatorio = false;
            this.txtCorreo.ExpresionValidacion = "^([a-zA-Z0-9_\\-])([a-zA-Z0-9_\\-\\.]*)@(\\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0" +
                "-9]|[0-9])\\.){3}|((([a-zA-Z0-9\\-]+)\\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-" +
                "9][0-9]|[1-9][0-9]|[0-9])\\])$";
            this.txtCorreo.Location = new System.Drawing.Point(102, 206);
            this.txtCorreo.MaxLength = 255;
            this.txtCorreo.MensajeError = "El correo electrónico debe tener este formato: abc@dominio.com";
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(380, 20);
            this.txtCorreo.TabIndex = 5;
            this.txtCorreo.Texto = null;
            this.txtCorreo.TipoTexto = SiCo.ctrla.TiposTexto.Alfanumerico;
            // 
            // txtdireccion
            // 
            this.txtdireccion.ColorError = System.Drawing.Color.Red;
            this.txtdireccion.EsObligatorio = false;
            this.txtdireccion.ExpresionValidacion = null;
            this.txtdireccion.Location = new System.Drawing.Point(102, 134);
            this.txtdireccion.MensajeError = null;
            this.txtdireccion.Multiline = true;
            this.txtdireccion.Name = "txtdireccion";
            this.txtdireccion.Size = new System.Drawing.Size(380, 66);
            this.txtdireccion.TabIndex = 4;
            this.txtdireccion.Texto = null;
            this.txtdireccion.TipoTexto = SiCo.ctrla.TiposTexto.Parrafo;
            // 
            // txttelefono
            // 
            this.txttelefono.ColorError = System.Drawing.Color.Red;
            this.txttelefono.EsObligatorio = false;
            this.txttelefono.ExpresionValidacion = null;
            this.txttelefono.Location = new System.Drawing.Point(102, 108);
            this.txttelefono.MaxLength = 255;
            this.txttelefono.MensajeError = null;
            this.txttelefono.Multiline = true;
            this.txttelefono.Name = "txttelefono";
            this.txttelefono.Size = new System.Drawing.Size(380, 20);
            this.txttelefono.TabIndex = 3;
            this.txttelefono.Texto = null;
            this.txttelefono.TipoTexto = SiCo.ctrla.TiposTexto.Parrafo;
            // 
            // txtApellidos
            // 
            this.txtApellidos.ColorError = System.Drawing.Color.Red;
            this.txtApellidos.EsObligatorio = false;
            this.txtApellidos.ExpresionValidacion = null;
            this.txtApellidos.Location = new System.Drawing.Point(102, 82);
            this.txtApellidos.MaxLength = 255;
            this.txtApellidos.MensajeError = null;
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(380, 20);
            this.txtApellidos.TabIndex = 3;
            this.txtApellidos.Texto = null;
            this.txtApellidos.TipoTexto = SiCo.ctrla.TiposTexto.Alfanumerico;
            // 
            // txtNombre
            // 
            this.txtNombre.ColorError = System.Drawing.Color.Red;
            this.txtNombre.EsObligatorio = false;
            this.txtNombre.ExpresionValidacion = null;
            this.txtNombre.Location = new System.Drawing.Point(102, 56);
            this.txtNombre.MaxLength = 255;
            this.txtNombre.MensajeError = null;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(380, 20);
            this.txtNombre.TabIndex = 3;
            this.txtNombre.Texto = null;
            this.txtNombre.TipoTexto = SiCo.ctrla.TiposTexto.Alfanumerico;
            // 
            // cmbTipoIdentidad
            // 
            this.cmbTipoIdentidad.Comando = null;
            this.cmbTipoIdentidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoIdentidad.FormattingEnabled = true;
            this.cmbTipoIdentidad.ListaDesplegablePadre = null;
            this.cmbTipoIdentidad.Location = new System.Drawing.Point(102, 29);
            this.cmbTipoIdentidad.Name = "cmbTipoIdentidad";
            this.cmbTipoIdentidad.Size = new System.Drawing.Size(380, 21);
            this.cmbTipoIdentidad.TabIndex = 2;
            this.cmbTipoIdentidad.SelectedIndexChanged += new System.EventHandler(this.cmbTipoIdentidad_SelectedIndexChanged);
            // 
            // txtidentifiacion
            // 
            this.txtidentifiacion.ColorError = System.Drawing.Color.Red;
            this.txtidentifiacion.EsObligatorio = false;
            this.txtidentifiacion.ExpresionValidacion = "[0-1][0-8][0-9][0-9]-[1-2][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9][0-9]";
            this.txtidentifiacion.Location = new System.Drawing.Point(102, 3);
            this.txtidentifiacion.MaxLength = 255;
            this.txtidentifiacion.MensajeError = "El número de identida debe tener este formato: 0301-1933-00232";
            this.txtidentifiacion.Name = "txtidentifiacion";
            this.txtidentifiacion.Size = new System.Drawing.Size(380, 20);
            this.txtidentifiacion.TabIndex = 1;
            this.txtidentifiacion.Texto = null;
            tipoIdentidad1.Descripcion = "Identidad";
            tipoIdentidad1.Valor = "I";
            this.txtidentifiacion.TipoIdentificacion = tipoIdentidad1;
            this.txtidentifiacion.TipoTexto = SiCo.ctrla.TiposTexto.Alfanumerico;
            // 
            // crtlPersonaNatural
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cajaTexto1);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.txtdireccion);
            this.Controls.Add(this.txttelefono);
            this.Controls.Add(this.txtApellidos);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.cmbTipoIdentidad);
            this.Controls.Add(this.txtidentifiacion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "crtlPersonaNatural";
            this.Size = new System.Drawing.Size(494, 290);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private IdentidadCajaTexto txtidentifiacion;
        private ListaDesplegable cmbTipoIdentidad;
        private CajaTexto txtNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private CajaTexto txtApellidos;
        private System.Windows.Forms.Label label5;
        private CajaTexto txttelefono;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private CajaTexto txtdireccion;
        private CorreoCajaTexto txtCorreo;
        private CajaTexto cajaTexto1;

    }
}
