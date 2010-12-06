using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SiCo.lgla; 


namespace SiCo.ctrla.ControlesPersonalizados
{
    public partial class crtlPersonaNatural : UserControl
    {
        #region Declaraciones
        private lgla.PersonaNatural _PersonaNatural;
        private List<lgla.TipoIdentidad> _ColeccionTipoIdentidad = new List<lgla.TipoIdentidad>();
        public event ErroresEventsHandler Errores;

        #endregion       

        #region Constructor

        public crtlPersonaNatural()
        {
            InitializeComponent();
            this.ColeccionTipoIdentidad.Add(new TipoIdentidad("Identidad", "I"));
            this.ColeccionTipoIdentidad.Add(new TipoIdentidad("Pasaporte", "P"));
            this.ColeccionTipoIdentidad.Add(new TipoIdentidad("Menor de Edad", "M"));

            cmbTipoIdentidad.DataSource = this.ColeccionTipoIdentidad;
            cmbTipoIdentidad.DisplayMember = "Descripcion";
            cmbTipoIdentidad.ValueMember = "valor";

            txtNombre.ColeccionParametros.Add(new Parametro("id",string.Empty));
            txtNombre.ColeccionParametros.Add(new Parametro("nombrecompleto",string.Empty));
            txtNombre.ColeccionParametros.Add(new Parametro("identidad",string.Empty));
            txtNombre.ColeccionParametros.Add(new Parametro("rtn",string.Empty));
            txtNombre.ColeccionParametros.Add(new Parametro("nombre",string.Empty));
            txtNombre.ColeccionParametros.Add(new Parametro("apellidos", string.Empty));


            txtApellidos.ColeccionParametros.Add(new Parametro("id", string.Empty));
            txtApellidos.ColeccionParametros.Add(new Parametro("nombrecompleto", string.Empty));
            txtApellidos.ColeccionParametros.Add(new Parametro("identidad", string.Empty));
            txtApellidos.ColeccionParametros.Add(new Parametro("rtn", string.Empty));
            txtApellidos.ColeccionParametros.Add(new Parametro("nombre", string.Empty));
            txtApellidos.ColeccionParametros.Add(new Parametro("apellidos", string.Empty));

            

        }

        #endregion

        #region Propiedad

        public List<lgla.TipoIdentidad> ColeccionTipoIdentidad
        {
            get { return _ColeccionTipoIdentidad; }
        }

        public int Id
        {
            get { return 0; }
            
        }

        #endregion       

        #region Metodos

        private int Guadar()
        {
            int i = 0;
            InicializarPersonaNatural();
            Validador Validador= new Validador() ;
            Validador.ColecionCajasTexto.Add(txtNombre);
            Validador.ColecionCajasTexto.Add(txtdireccion);
            Validador.ColecionCajasTexto.Add(txtCorreo );
            Validador.ColecionCajasTexto.Add(txtidentifiacion);
            Validador.ColecionCajasTexto.Add(txtApellidos);
            Validador.ColecionCajasTexto.Add(txtrtn);
            Validador.ColecionCajasTexto.Add(txttelefono);
            if (Validador.PermitirIngresar)
            {
                _PersonaNatural.nombre = txtNombre.Text;
                _PersonaNatural.apellidos = txtApellidos.Text;
                _PersonaNatural.identidad = txtidentifiacion.Texto;
                _PersonaNatural.tipoidentidad = txtidentifiacion.TipoIdentificacion;
                _PersonaNatural.Direccion = txtdireccion.Texto;
                _PersonaNatural.correo = txtCorreo.Texto;
                _PersonaNatural.rtn = txtrtn.Texto;
                _PersonaNatural.Telefono = txttelefono.ValorInt;  

            }
            else 
            {
                if (this.Errores != null)
                {
                    this.Errores(Validador.MensajesError);  
                }

            }

            return i ;

        }

        public void Cargar(Int32 Id)
        {
            try
            {
                InicializarPersonaNatural();
                _PersonaNatural.Id = Id; 
            }
            catch (Exception ex)
            {
                if (this.Errores != null)
                {
                    this.Errores(ex.Message); 
                }
            }


        }

        private void InicializarPersonaNatural()
        {
            if (_PersonaNatural == null)
            {
                _PersonaNatural = new PersonaNatural();
                _PersonaNatural.CambioId += new CambioIdEventArgs(_PersonaNatural_CambioId);
                _PersonaNatural.Errores += new ErroresEventsArgs(_PersonaNatural_Errores);
            }
        }        

        public void NuevaPersonaNatural()
        {
            _PersonaNatural = new PersonaNatural();
            CargarDatos();
        }

        private void CargarDatos()
        {
            InicializarPersonaNatural(); 
            txtNombre.Text = _PersonaNatural.nombre;
            txtApellidos.Text = _PersonaNatural.apellidos;
            txtCorreo.Text = _PersonaNatural.correo;
            txttelefono.Text = _PersonaNatural.Telefono.ToString();
            txtidentifiacion.Text = _PersonaNatural.identidad;
            cmbTipoIdentidad.SelectedItem = _PersonaNatural.tipoidentidad;
            txtdireccion.Text = _PersonaNatural.Direccion;
            txtrtn.Text = _PersonaNatural.rtn;
        }

        #endregion

        #region Eventos

        private void _PersonaNatural_CambioId()
        {
            CargarDatos();
        }

        private void cmbTipoIdentidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbTipoIdentidad.SelectedItem != null)
                {
                    txtidentifiacion.TipoIdentificacion = (TipoIdentidad)cmbTipoIdentidad.SelectedItem;
                }

            }
            catch 
            {

            }
        }

        private  void _PersonaNatural_Errores(string Mensaje)
        {

        }

        private void crtlPersonaNatural_Load(object sender, EventArgs e)
        {

        }

        #endregion       
    }
}
