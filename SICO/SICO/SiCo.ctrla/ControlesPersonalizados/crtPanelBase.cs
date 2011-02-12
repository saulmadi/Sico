using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics ;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SiCo.ctrla.ControlesPersonalizados
{
    public partial class crtPanelBase : UserControl
    {
        SiCo.lgla.Usuario usu;
        SiCo.lgla.Sucursales suc;
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

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),EditorBrowsable( EditorBrowsableState.Advanced)]     
        public SiCo.lgla.Usuario Usuario
        {
            get 
            {
                return usu;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),EditorBrowsable( EditorBrowsableState.Advanced)]     
        public SiCo.lgla.Sucursales Sucursal
        {
            get 
            {
                return suc;
            }
        }
        
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),EditorBrowsable( EditorBrowsableState.Advanced)]     
        public Label Etiqueta
        {
            get 
            {
                return lblUsuario ;
            }

        }

        private void crtPanelBase_Load(object sender, EventArgs e)
        {
            try
            {
                suc = new SiCo.lgla.Sucursales();
                suc.Cargar();          
            }
            catch
            {
                suc = null;
            }

            try
            {
                       
                 usu = new SiCo.lgla.Usuario();
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
