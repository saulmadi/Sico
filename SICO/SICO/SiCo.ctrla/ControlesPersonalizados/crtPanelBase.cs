using System;
using System.ComponentModel;
using System.Windows.Forms;
using SiCo.lgla;

namespace SiCo.ctrla.ControlesPersonalizados
{
    public partial class crtPanelBase : UserControl
    {
        [NonSerialized] private static Usuario usu;
        [NonSerialized] private static Sucursales suc;


        public crtPanelBase()
        {
            InitializeComponent();
            lblfecha.Text = DateTime.Now.ToLongDateString();

            try
            {
                if (suc == null)
                {
                    suc = new Sucursales();
                    suc.Cargar();

                    lblSucursal.Text = suc.NombreSucursal;
                }
                else
                {
                    lblSucursal.Text = suc.NombreSucursal;
                }
            }
            catch
            {
                if (suc != null)
                    suc = null;
                lblSucursal.Text = "Error al cargar la sucursal";
            }

            try
            {
                if (usu == null)
                {
                    usu = new Usuario();
                    usu.Cargar();
                    lblUsuario.Text = usu.usuario;
                }
                else
                {
                    lblUsuario.Text = usu.usuario;
                }
            }
            catch
            {
                if (usu != null)
                    usu = null;
                lblUsuario.Text = "Error al cargar el usuario";
            }
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


        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
         EditorBrowsable(EditorBrowsableState.Advanced)]
        public Usuario Usuario
        {
            get { return usu; }
            set { usu = value; }
        }


        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
         EditorBrowsable(EditorBrowsableState.Advanced)]
        public Sucursales sucursal
        {
            get { return suc; }
            set { suc = value; }
        }


        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
         EditorBrowsable(EditorBrowsableState.Advanced)]
        public Label Etiqueta
        {
            get { return lblUsuario; }
        }

        private void crtPanelBase_Load(object sender, EventArgs e)
        {
            if (suc != null)
                lblSucursal.Text = suc.NombreSucursal;

            if (usu != null)
                lblUsuario.Text = usu.usuario;
        }
    }
}