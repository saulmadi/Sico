using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SiCo.ctrla.ControlesPersonalizados
{
    public partial class crtPanelBase : UserControl
    {
        public crtPanelBase()
        {
            InitializeComponent();
            lblfecha.Text = DateTime.Now.ToLongDateString ();            
        }

        public string Titulo
        {
            get { return lblTitulo.Text; }
            set { lblTitulo.Text = value; }
        }
        public bool VisiblePanelPrincipal
        {
            get { return PanelPrinipal.Visible; }
            set { PanelPrinipal.Visible = value; }

        }
        private void crtPanelBase_Load(object sender, EventArgs e)
        {
            try
            {
                SiCo.lgla.Usuario usu = new SiCo.lgla.Usuario();
                usu.Cargar();
                lblUsuario.Text = usu.usuario; 
            }
            catch
            {
                lblUsuario.Text = "Error al cargar el usuario";
            }            
           
        }
    }
}
