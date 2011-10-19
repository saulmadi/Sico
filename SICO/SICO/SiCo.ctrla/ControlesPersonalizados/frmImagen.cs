using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;
using Microsoft.VisualBasic.FileIO;

namespace SiCo.ctrla.ControlesPersonalizados
{
    public partial class frmImagen : Form
    {
        public frmImagen()
        {
            InitializeComponent();
            var b = new Computer();
            salvar.InitialDirectory = b.FileSystem.SpecialDirectories.MyPictures;
            toolTip1.SetToolTip(btnSalvar, "Exportar");
            toolTip2.SetToolTip(button2, "Salir");
        }

        public Image Imagen
        {
            get { return panel1.BackgroundImage; }
            set { panel1.BackgroundImage = value; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (salvar.ShowDialog() == DialogResult.OK)
            {
                var c = new Computer();

                Imagen.Save(salvar.FileName, ImageFormat.Jpeg);

                if (cajaTexto1.Text != "")
                {
                    Imagen.Save(c.FileSystem.SpecialDirectories.Temp + "\\tmpimg.jpeg");
                    Image i = Image.FromFile(c.FileSystem.SpecialDirectories.Temp + "\\tmpimg.jpeg");
                    using (Graphics g = Graphics.FromImage(i))
                    {
                        Brush solidBrush = new SolidBrush(Color.Black);
                        var family = new FontFamily("Verdana");
                        var font = new Font(family, (float) 10.00);

                        Brush p = new SolidBrush(Color.White);
                        var location = new PointF(8, 260);

                        g.FillRectangle(p, 5, 260, 300, 25);
                        g.DrawString(cajaTexto1.Text, font, solidBrush, location);
                        FileSystem.DeleteFile(salvar.FileName);
                        i.Save(salvar.FileName, ImageFormat.Jpeg);
                        i.Dispose();
                    }
                    FileSystem.DeleteFile(c.FileSystem.SpecialDirectories.Temp + "\\tmpimg.jpeg");
                }
            }
        }
    }
}