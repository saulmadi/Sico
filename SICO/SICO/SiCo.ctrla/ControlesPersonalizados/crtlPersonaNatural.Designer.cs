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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(crtlPersonaNatural));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtrtn = new SiCo.ctrla.CajaTexto(this.components);
            this.txtCorreo = new SiCo.ctrla.CorreoCajaTexto(this.components);
            this.txtdireccion = new SiCo.ctrla.CajaTexto(this.components);
            this.txttelefono = new SiCo.ctrla.CajaTexto(this.components);
            this.cmbTipoIdentidad = new SiCo.ctrla.ListaDesplegable(this.components);
            this.txtidentifiacion = new SiCo.ctrla.IdentidadCajaTexto(this.components);
            this.txtNombre = new SiCo.ctrla.ControlesBasicos.AutoCompleteCajaTexto(this.components);
            this.txtApellidos = new SiCo.ctrla.ControlesBasicos.AutoCompleteCajaTexto(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Tipo identificación";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Identificacion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Nombre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Apellidos";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "telefono";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Dirección";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 212);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Correo";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 236);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "RTN";
            // 
            // txtrtn
            // 
            this.txtrtn.ColorError = System.Drawing.Color.Red;
            this.txtrtn.EsObligatorio = false;
            this.txtrtn.ExpresionValidacion = null;
            this.txtrtn.Location = new System.Drawing.Point(102, 236);
            this.txtrtn.MaxLength = 255;
            this.txtrtn.MensajeError = null;
            this.txtrtn.Name = "txtrtn";
            this.txtrtn.Size = new System.Drawing.Size(380, 20);
            this.txtrtn.TabIndex = 7;
            this.txtrtn.Texto = null;
            this.txtrtn.TipoTexto = SiCo.ctrla.TiposTexto.Alfanumerico;
            // 
            // txtCorreo
            // 
            this.txtCorreo.ColorError = System.Drawing.Color.Red;
            this.txtCorreo.EsObligatorio = false;
            this.txtCorreo.ExpresionValidacion = "^([a-zA-Z0-9_\\-])([a-zA-Z0-9_\\-\\.]*)@(\\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0" +
                "-9]|[0-9])\\.){3}|((([a-zA-Z0-9\\-]+)\\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-" +
                "9][0-9]|[1-9][0-9]|[0-9])\\])$";
            this.txtCorreo.Location = new System.Drawing.Point(102, 209);
            this.txtCorreo.MaxLength = 255;
            this.txtCorreo.MensajeError = "El correo electrónico debe tener este formato: abc@dominio.com";
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(380, 20);
            this.txtCorreo.TabIndex = 6;
            this.txtCorreo.Texto = null;
            this.txtCorreo.TipoTexto = SiCo.ctrla.TiposTexto.Alfanumerico;
            // 
            // txtdireccion
            // 
            this.txtdireccion.ColorError = System.Drawing.Color.Red;
            this.txtdireccion.EsObligatorio = false;
            this.txtdireccion.ExpresionValidacion = null;
            this.txtdireccion.Location = new System.Drawing.Point(102, 137);
            this.txtdireccion.MensajeError = null;
            this.txtdireccion.Multiline = true;
            this.txtdireccion.Name = "txtdireccion";
            this.txtdireccion.Size = new System.Drawing.Size(380, 66);
            this.txtdireccion.TabIndex = 5;
            this.txtdireccion.Texto = null;
            this.txtdireccion.TipoTexto = SiCo.ctrla.TiposTexto.Parrafo;
            // 
            // txttelefono
            // 
            this.txttelefono.ColorError = System.Drawing.Color.Red;
            this.txttelefono.EsObligatorio = false;
            this.txttelefono.ExpresionValidacion = null;
            this.txttelefono.Location = new System.Drawing.Point(102, 111);
            this.txttelefono.MaxLength = 255;
            this.txttelefono.MensajeError = null;
            this.txttelefono.Multiline = true;
            this.txttelefono.Name = "txttelefono";
            this.txttelefono.Size = new System.Drawing.Size(380, 20);
            this.txttelefono.TabIndex = 4;
            this.txttelefono.Texto = null;
            this.txttelefono.TipoTexto = SiCo.ctrla.TiposTexto.Parrafo;
            // 
            // cmbTipoIdentidad
            // 
            this.cmbTipoIdentidad.Comando = null;
            this.cmbTipoIdentidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoIdentidad.FormattingEnabled = true;            
            this.cmbTipoIdentidad.Location = new System.Drawing.Point(102, 84);
            this.cmbTipoIdentidad.Name = "cmbTipoIdentidad";
            this.cmbTipoIdentidad.Size = new System.Drawing.Size(380, 21);
            this.cmbTipoIdentidad.TabIndex = 3;
            this.cmbTipoIdentidad.SelectedIndexChanged += new System.EventHandler(this.cmbTipoIdentidad_SelectedIndexChanged);
            // 
            // txtidentifiacion
            // 
            this.txtidentifiacion.ColorError = System.Drawing.Color.Red;
            this.txtidentifiacion.EsObligatorio = false;
            this.txtidentifiacion.ExpresionValidacion = "[0-1][0-8][0-9][0-9]-[1-2][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9][0-9]";
            this.txtidentifiacion.Location = new System.Drawing.Point(102, 58);
            this.txtidentifiacion.MaxLength = 255;
            this.txtidentifiacion.MensajeError = "El número de identida debe tener este formato: 0301-1933-00232";
            this.txtidentifiacion.Name = "txtidentifiacion";
            this.txtidentifiacion.Size = new System.Drawing.Size(380, 20);
            this.txtidentifiacion.TabIndex = 2;
            this.txtidentifiacion.Texto = null;
            tipoIdentidad1.Descripcion = "Identidad";
            tipoIdentidad1.Valor = "I";
            this.txtidentifiacion.TipoIdentificacion = tipoIdentidad1;
            this.txtidentifiacion.TipoTexto = SiCo.ctrla.TiposTexto.Alfanumerico;
            // 
            // txtNombre
            // 
            this.txtNombre.AutoCompletar = true;
            this.txtNombre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.txtNombre.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtNombre.CampoMostrar = "NombreCompleto";
            this.txtNombre.CaracteresInicio = 3;
            this.txtNombre.ColeccionParametros = ((System.Collections.Generic.List<SiCo.lgla.Parametro>)(resources.GetObject("txtNombre.ColeccionParametros")));
            this.txtNombre.ColorError = System.Drawing.Color.Red;
            this.txtNombre.EsObligatorio = false;
            this.txtNombre.ExpresionValidacion = null;
            this.txtNombre.Location = new System.Drawing.Point(102, 6);
            this.txtNombre.MaxLength = 255;
            this.txtNombre.MensajeError = null;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ParameteroBusqueda = "NombreCompleto";
            this.txtNombre.Procedimiento = "PersonaNatural_Buscar";
            this.txtNombre.Size = new System.Drawing.Size(380, 20);
            this.txtNombre.TabIndex = 16;
            this.txtNombre.Texto = null;
            this.txtNombre.TipoTexto = SiCo.ctrla.TiposTexto.Alfanumerico;
            this.txtNombre.Leave += new System.EventHandler(this.txtNombre_Leave);
            // 
            // txtApellidos
            // 
            this.txtApellidos.AutoCompletar = true;
            this.txtApellidos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtApellidos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtApellidos.CampoMostrar = "apellidos";
            this.txtApellidos.CaracteresInicio = 3;
            this.txtApellidos.ColeccionParametros = ((System.Collections.Generic.List<SiCo.lgla.Parametro>)(resources.GetObject("txtApellidos.ColeccionParametros")));
            this.txtApellidos.ColorError = System.Drawing.Color.Red;
            this.txtApellidos.EsObligatorio = false;
            this.txtApellidos.ExpresionValidacion = null;
            this.txtApellidos.Location = new System.Drawing.Point(102, 32);
            this.txtApellidos.MaxLength = 255;
            this.txtApellidos.MensajeError = null;
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.ParameteroBusqueda = "apellidos";
            this.txtApellidos.Procedimiento = "PersonaNatural_Buscar";
            this.txtApellidos.Size = new System.Drawing.Size(380, 20);
            this.txtApellidos.TabIndex = 17;
            this.txtApellidos.Texto = null;
            this.txtApellidos.TipoTexto = SiCo.ctrla.TiposTexto.Alfanumerico;
            this.txtApellidos.Leave += new System.EventHandler(this.txtNombre_Leave);
            // 
            // crtlPersonaNatural
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtApellidos);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtrtn);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.txtdireccion);
            this.Controls.Add(this.txttelefono);
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
            this.Size = new System.Drawing.Size(497, 264);
            this.Load += new System.EventHandler(this.crtlPersonaNatural_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private IdentidadCajaTexto txtidentifiacion;
        private ListaDesplegable cmbTipoIdentidad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private CajaTexto txttelefono;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private CajaTexto txtdireccion;
        private CorreoCajaTexto txtCorreo;
        private CajaTexto txtrtn;
        
        private SiCo.ctrla.ControlesBasicos.AutoCompleteCajaTexto txtNombre;
        private SiCo.ctrla.ControlesBasicos.AutoCompleteCajaTexto txtApellidos;

    }
}
