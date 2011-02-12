using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SiCo.ctrla.ControlesPersonalizados
{
    public partial class crtImagen : UserControl
    {
        #region Declaraciones

        private SiCo.lgla2.Imagenes _imagenes;

        private Boolean _Cambio = false; 

        #endregion

        #region Constructor
        public crtImagen()
        {
            InitializeComponent();

        }
        #endregion

        #region  Propiedades
        public SiCo.lgla2.Imagenes Imagenes
        {
            get
            {
                return _imagenes;
            }
            set { _imagenes = value; }
        }
        #endregion 

        #region Metodos
        public void Descargar(long id)
        {
            Argumento arg = new Argumento(this._imagenes,id );
            tread.RunWorkerAsync(arg); 
        }

        public void Guardar(long id)
        {
            if (_Cambio)
            { 
                if (pictureBox1.Image != null)
                {
                    MemoryStream m = new MemoryStream();
                    this.pictureBox1.Image.Save(m, System.Drawing.Imaging.ImageFormat.Jpeg);
                    this._imagenes.ImagenBinaria = m.GetBuffer();
                }
                else 
                {
                    this._imagenes.ImagenBinaria = null;
                  
                }
                this._imagenes.IdImagenes = id;
                this._imagenes.Guardar(); 
            }

        }   
    
        public void  limpiar()
        {
            pictureBox1.Image=null;
            this.Imagenes=new SiCo.lgla2.Imagenes ();
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

                Bitmap b = new Bitmap(new Bitmap( DialagoArchivo.FileName),new Size(320,288));

                pictureBox1.Image =b;

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
            Argumento ar = (Argumento)e.Argument;
            ar._imagen.Buscar(ar._id);  
        }

        private void tread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
                MessageBox.Show(e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else 
            {
                if (this._imagenes.TotalRegistros > 0)
                {
                    if (this._imagenes.Id > 0)
                    {
                        this.pictureBox1.Image = _imagenes.Imagen;
                    }
                    else
                    {
                        this.pictureBox1.Image = null;
                    }
                }
                else 
                {
                    this.pictureBox1.Image = null;
                }
            }

        }
        
        private void crtImagen_Load(object sender, EventArgs e)
        {
            try
            {
                _imagenes = new SiCo.lgla2.Imagenes();                
            }
            catch 
            {
            }
        
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frmImagen f = new frmImagen();
            if (pictureBox1.Image != null)
            {
                f.Imagen = pictureBox1.Image;
                f.ShowDialog();
            }

        }

        #endregion

        public class Argumento
        {
            public  SiCo.lgla2.Imagenes _imagen;
            public long  _id;
            public Argumento(SiCo.lgla2 .Imagenes imagen,long id)
            {
                _imagen = imagen;
                _id = id;
            }
        }        

    }
}
