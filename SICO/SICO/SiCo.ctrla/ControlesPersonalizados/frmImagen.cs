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
                Microsoft.VisualBasic.Devices.Computer c= new Microsoft.VisualBasic.Devices.Computer ();
                 
                this.Imagen.Save(salvar.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                
                if(cajaTexto1.Text!= "")
                {
                    this.Imagen.Save(c.FileSystem.SpecialDirectories.Temp + "\\tmpimg.jpeg");
                    Image i = Image.FromFile(c.FileSystem.SpecialDirectories.Temp + "\\tmpimg.jpeg");
                    using (Graphics g = Graphics.FromImage(i))
                    {
                        Brush solidBrush = new SolidBrush(Color.Black);
                        FontFamily family = new FontFamily("Verdana");                     
                        Font font = new Font(family, (float)10.00);                        
                        
                        Brush  p = new SolidBrush(Color.White);                        
                        PointF location = new PointF(8, 260);                        
                        
                        g.FillRectangle(p, 5, 260, 300, 25);
                        g.DrawString(cajaTexto1.Text, font, solidBrush, location);
                        Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(salvar.FileName);
                        i.Save(salvar.FileName,System.Drawing.Imaging.ImageFormat.Jpeg );
                        i.Dispose();
                    }
                    Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(c.FileSystem.SpecialDirectories.Temp + "\\tmpimg.jpeg");

               }
             
            }
        }
    }
}
