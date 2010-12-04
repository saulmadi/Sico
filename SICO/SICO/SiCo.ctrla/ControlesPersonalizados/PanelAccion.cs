using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SiCo.ctrla
{
    public partial class PanelAccion : UserControl
    {
        public event PanelAccionNuevoEventArgs Nuevo;

        public event PanelAccionGuardarEventArgs Guardar;

        public event PanelAccionEliminarEventArgs Eliminar;

        public event PanelAccionImprimirEventArgs Imprimir;

        public event PanelAccionCancelarEventArgs Cancelar;

        private SiCo.lgla.Usuario _Usuario = new SiCo.lgla.Usuario();  
    
        public PanelAccion()
        {
            InitializeComponent();
            EstadoMensaje = "";
        }

        

        public string  EstadoMensaje
        {
            get
            {
                return lblEstado.Text ;
            }
            set
            {
                lblEstado.Text = value;
            }
        }

        public bool HabilitarNuevo
        {
            get
            {
                return btnNuevo.Enabled;
            }
            set
            {
                btnNuevo.Enabled = value;
            }
        }

        public bool HabilitarGuardar
        {
            get
            {
                return btnGuardar.Enabled;
            }
            set
            {
                btnGuardar.Enabled=value ;
            }
        }

        public bool habilitarEliminar
        {
            get
            {
                return btnEliminar.Enabled;
            }
            set
            {
                btnEliminar.Enabled=value;
            }
        }

        public bool HabilitarCancelar
        {
            get
            {
                return btnCancelar.Enabled;
            }
            set
            {
                btnCancelar.Enabled = value;
            }
        }

        public bool habilitarImprimir
        {
            get
            {
                return btnImprimir.Enabled;
            }
            set
            {
                btnImprimir.Enabled=value;
            }
        }

        public string Titulo
        {
            get { return lblTitulo.Text; }
            set { lblTitulo.Text=value ; }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (this.Nuevo != null)
                Nuevo();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (this.Guardar != null)
                Guardar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.Eliminar != null)
                Eliminar();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (this.Imprimir != null)
                Imprimir();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (this.Cancelar != null)
                Cancelar();
        }

        private void PanelAccion_Load(object sender, EventArgs e)
        {
            lblfecha.Text = DateTime.Now.ToLongDateString ();  
        }     

        
    }
}
