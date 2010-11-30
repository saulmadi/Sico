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
            this.listaDesplegable1 = new SiCo.ctrla.ListaDesplegable(this.components);
            this.SuspendLayout();
            // 
            // listaDesplegable1
            // 
            this.listaDesplegable1.Comando = null;
            this.listaDesplegable1.FormattingEnabled = true;
            this.listaDesplegable1.ListaDesplegablePadre = null;
            this.listaDesplegable1.Location = new System.Drawing.Point(64, 39);
            this.listaDesplegable1.Name = "listaDesplegable1";
            this.listaDesplegable1.ParametroBusqueda = null;
            this.listaDesplegable1.Size = new System.Drawing.Size(121, 21);
            this.listaDesplegable1.TabIndex = 0;
            // 
            // crtlPersonaNatural
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listaDesplegable1);
            this.Name = "crtlPersonaNatural";
            this.Size = new System.Drawing.Size(546, 290);
            this.ResumeLayout(false);

        }

        #endregion

        private ListaDesplegable listaDesplegable1;
    }
}
