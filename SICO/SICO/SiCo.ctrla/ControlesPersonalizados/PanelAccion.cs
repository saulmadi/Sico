using System;
using System.Windows.Forms;
using SiCo.ctrla.ControlesPersonalizados;

namespace SiCo.ctrla
{
    public partial class PanelAccion : crtPanelBase
    {
        #region Declaraciones

        //private SiCo.lgla.Usuario _Usuario ;  


        public event PanelAccionNuevoEventArgs Nuevo;

        public event PanelAccionGuardarEventArgs Guardar;

        public event PanelAccionEliminarEventArgs Eliminar;

        public event PanelAccionImprimirEventArgs Imprimir;

        public event PanelAccionCancelarEventArgs Cancelar;

        #endregion

        #region Constructor

        public PanelAccion()
        {
            InitializeComponent();
            EstadoMensaje = "";
            lblfecha.Text = DateTime.Now.ToLongDateString();
        }

        #endregion

        #region Propiedades

        public string EstadoMensaje
        {
            get { return lblEstado.Text; }
            set { lblEstado.Text = value; }
        }

        public Button BotonNuevo
        {
            get { return btnNuevo; }
            set { btnNuevo = value; }
        }

        public Button BotonGuardar
        {
            get { return btnGuardar; }
            set { btnGuardar = value; }
        }

        public Button BotonEliminar
        {
            get { return btnEliminar; }
            set { btnEliminar = value; }
        }

        public Button BotonCancelar
        {
            get { return btnCancelar; }
            set { btnCancelar = value; }
        }

        public Button BotonImprimir
        {
            get { return BtnImprimir; }
            set { BtnImprimir = value; }
        }

        #endregion

        #region Eventos

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Eliminar != null)
                Eliminar();
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            if (Imprimir != null)
                Imprimir();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (Nuevo != null)
                Nuevo();
            BarraProgreso.Value = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Guardar != null)
            {
                BarraEstado.Text = "Guardando....";
                BarraProgreso.Value = 50;
                Guardar();
                BarraEstado.Text = "";
                try
                {
                    BarraProgreso.Value = 100;
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            switch (
                MessageBox.Show("¿Esta seguro de salir de la transacción?", "Confirmación", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    if (Cancelar != null)
                        Cancelar();
                    break;
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnEliminar_Click(sender, e);
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BtnImprimir_Click(sender, e);
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnNuevo_Click(sender, e);
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnGuardar_Click(sender, e);
        }

        private void cancelarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnCancelar_Click(sender, e);
        }

        private void PanelAccion_Load(object sender, EventArgs e)
        {
        }

        #endregion
    }
}