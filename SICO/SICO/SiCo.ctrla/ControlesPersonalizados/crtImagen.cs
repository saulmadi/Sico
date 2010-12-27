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
    public partial class crtImagen : UserControl
    {
        public crtImagen()
        {
            InitializeComponent();
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (DialagoArchivo.ShowDialog() == DialogResult.OK)
            {
                txtArchivo.Text = DialagoArchivo.FileName;
                txtArchivo.Select(txtArchivo.Text.Length + 2, txtArchivo.Text.Length - 1);
                txtArchivo.SelectionLength = 0;
                pictureBox1.Image = System.Drawing.Image.FromFile(DialagoArchivo.FileName);    
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            txtArchivo.Text = string.Empty;
            tread.RunWorkerAsync();
        }
        
        private void tread_DoWork(object sender, DoWorkEventArgs e)
        {
        }

        private void tread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
         
        }


    }
}
