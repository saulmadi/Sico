namespace SiCo.ctrla.ControlesBasicos
{
    partial class AutoCompleteCajaTexto
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
            this.SubProceso = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // SubProceso
            // 
            this.SubProceso.DoWork += new System.ComponentModel.DoWorkEventHandler(this.SubProceso_DoWork);
            this.SubProceso.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.SubProceso_RunWorkerCompleted);
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker SubProceso;
    }
}
