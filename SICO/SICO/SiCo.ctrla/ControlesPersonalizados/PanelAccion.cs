using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SiCo.ctrla ;

namespace SiCo.ctrla
{
    public partial class PanelAccion : SiCo.ctrla.ControlesPersonalizados.crtPanelBase  
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
            lblfecha .Text = DateTime.Now.ToLongDateString ();
        }
        #endregion

        #region Propiedades
        public string EstadoMensaje
        {
            get
            {
                return lblEstado.Text;
            }
            set
            {
                lblEstado.Text = value;
            }
        }

        public Button  BotonNuevo
        {
            get
            {
                return btnNuevo ;
            }
            set
            {
                btnNuevo = value;
            }
        }

        public Button BotonGuardar
        {
            get
            {
                return btnGuardar ;
            }
            set
            {
                btnGuardar = value;
            }
        }

        public Button BotonEliminar
        {
            get
            {
                return btnEliminar ;
            }
            set
            {
                btnEliminar = value;
            }
        }

        public Button BotonCancelar
        {
            get
            {
                return btnCancelar;
            }
            set
            {
                btnCancelar= value;
            }
        }

        public Button BotonImprimir
        {
            get
            {
                return BtnImprimir;
            }
            set
            {
                BtnImprimir  = value;
            }
        }

        
        #endregion

        #region Eventos

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.Eliminar != null)
                this.Eliminar();
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            if (this.Imprimir != null)
                this.Imprimir();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (this.Nuevo != null)
                this.Nuevo();
            this.BarraProgreso.Value = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (this.Guardar != null)
                this.Guardar();
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (this.Cancelar  != null)
                this.Cancelar();            

        }

        #endregion               
        
    }
}
