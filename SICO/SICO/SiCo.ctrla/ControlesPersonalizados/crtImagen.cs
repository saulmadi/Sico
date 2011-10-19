using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using SiCo.lgla2;

namespace SiCo.ctrla.ControlesPersonalizados
{
    public partial class crtImagen : UserControl
    {
        #region Declaraciones

        private Boolean _Cambio;
        private Imagenes _imagenes;

        #endregion

        #region Constructor

        public crtImagen()
        {
            InitializeComponent();
            Tabla = "";
            try
            {
                _imagenes = new Imagenes();
            }
            catch
            {
            }
        }

        #endregion

        #region  Propiedades

        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Imagenes Imagenes
        {
            get { return _imagenes; }
            set { _imagenes = value; }
        }

        public string Tabla { get; set; }

        #endregion

        #region Metodos

        public void Descargar(long id)
        {
            _imagenes.TablaBusqueda = Tabla;
            var arg = new Argumento(_imagenes, id);
            tread.RunWorkerAsync(arg);
        }

        public void Guardar(long id)
        {
            Imagenes.TablaBusqueda = Tabla;
            if (_Cambio)
            {
                if (pictureBox1.Image != null)
                {
                    var m = new MemoryStream();
                    pictureBox1.Image.Save(m, ImageFormat.Jpeg);
                    _imagenes.ImagenBinaria = m.GetBuffer();
                }
                else
                {
                    _imagenes.ImagenBinaria = null;
                }
                _imagenes.IdImagenes = id;
                _imagenes.Guardar();
            }
        }

        public void limpiar()
        {
            pictureBox1.Image = null;
            Imagenes = new Imagenes();
        }

        #endregion

        #region Eventos

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (DialagoArchivo.ShowDialog() == DialogResult.OK)
            {
                txtArchivo.Text = DialagoArchivo.FileName;
                txtArchivo.Select(txtArchivo.Text.Length + 2, txtArchivo.Text.Length - 1);
                txtArchivo.SelectionLength = 0;

                var b = new Bitmap(new Bitmap(DialagoArchivo.FileName), new Size(320, 288));

                pictureBox1.Image = b;

                _Cambio = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
                _Cambio = true;
            pictureBox1.Image = null;
            txtArchivo.Text = string.Empty;
        }

        private void tread_DoWork(object sender, DoWorkEventArgs e)
        {
            var ar = (Argumento) e.Argument;
            ar._imagen.Buscar(ar._id);
        }

        private void tread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
                MessageBox.Show(e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (_imagenes.TotalRegistros > 0)
                {
                    if (_imagenes.Id > 0)
                    {
                        pictureBox1.Image = _imagenes.Imagen;
                    }
                    else
                    {
                        pictureBox1.Image = null;
                    }
                }
                else
                {
                    pictureBox1.Image = null;
                }
            }
        }

        private void crtImagen_Load(object sender, EventArgs e)
        {
            try
            {
                _imagenes = new Imagenes();
            }
            catch
            {
            }
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var f = new frmImagen();
            if (pictureBox1.Image != null)
            {
                f.Imagen = pictureBox1.Image;
                f.ShowDialog();
            }
        }

        #endregion

        #region Nested type: Argumento

        public class Argumento
        {
            public long _id;
            public Imagenes _imagen;

            public Argumento(Imagenes imagen, long id)
            {
                _imagen = imagen;

                _id = id;
            }
        }

        #endregion
    }
}