using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic; 

namespace SiCo.ctrla.ControlesPersonalizados
{
    public partial class frmImagen : Form
    {
        public frmImagen()
        {
            InitializeComponent();
            Microsoft.VisualBasic.Devices.Computer b = new Microsoft.VisualBasic.Devices.Computer();
            salvar.InitialDirectory =  b.FileSystem.SpecialDirectories.MyPictures;
            toolTip1.SetToolTip(btnSalvar, "Exportar");
            toolTip2.SetToolTip(button2, "Salir");
        }

        public Image Imagen
        {
            get
            {
                return panel1.BackgroundImage  ;
            }
            set 
            {
                panel1.BackgroundImage=value  ;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (salvar.ShowDialog() == DialogResult.OK)
            {
                this.Imagen.Save(salvar.FileName);
            }
        }
    }
}
