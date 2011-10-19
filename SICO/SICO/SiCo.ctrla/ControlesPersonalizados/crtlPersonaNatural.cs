using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SiCo.lgla;

namespace SiCo.ctrla.ControlesPersonalizados
{
    public partial class crtlPersonaNatural : UserControl
    {
        #region Declaraciones

        private readonly List<TipoIdentidad> _ColeccionTipoIdentidad = new List<TipoIdentidad>();
        private PersonaNatural _PersonaNatural;
        public event ErroresEventsHandler Errores;

        #endregion

        #region Constructor

        public crtlPersonaNatural()
        {
            InitializeComponent();
            //this.ColeccionTipoIdentidad.Add(new TipoIdentidad("Identidad", "I"));
            //this.ColeccionTipoIdentidad.Add(new TipoIdentidad("Pasaporte", "P"));
            //this.ColeccionTipoIdentidad.Add(new TipoIdentidad("Menor de Edad", "M"));

            //cmbTipoIdentidad.DataSource = this.ColeccionTipoIdentidad;
            //cmbTipoIdentidad.DisplayMember = "Descripcion";
            //cmbTipoIdentidad.ValueMember = "valor";

            //txtNombre.ColeccionParametros.Add(new Parametro("id", string.Empty));
            //txtNombre.ColeccionParametros.Add(new Parametro("nombrecompleto", string.Empty));
            //txtNombre.ColeccionParametros.Add(new Parametro("identificacion", string.Empty));
            //txtNombre.ColeccionParametros.Add(new Parametro("rtn", string.Empty));
            //txtNombre.ColeccionParametros.Add(new Parametro("NombreCompleto", string.Empty));
            //txtNombre.ColeccionParametros.Add(new Parametro("apellidos", string.Empty));


            //txtApellidos.ColeccionParametros.Add(new Parametro("id", string.Empty));
            //txtApellidos.ColeccionParametros.Add(new Parametro("nombrecompleto", string.Empty));
            //txtApellidos.ColeccionParametros.Add(new Parametro("identificacion", string.Empty));
            //txtApellidos.ColeccionParametros.Add(new Parametro("rtn", string.Empty));
            //txtApellidos.ColeccionParametros.Add(new Parametro("NombreCompleto", string.Empty));
            //txtApellidos.ColeccionParametros.Add(new Parametro("apellidos", string.Empty));
        }

        #endregion

        #region Propiedad

        public List<TipoIdentidad> ColeccionTipoIdentidad
        {
            get { return _ColeccionTipoIdentidad; }
        }

        public Int32 Id
        {
            get { return Guadar(); }
        }

        #endregion

        #region Metodos

        private Int32 Guadar()
        {
            Int32 i = 0;
            InicializarPersonaNatural();
            var Validador = new Validador();
            Validador.ColecionCajasTexto.Add(txtNombre);
            Validador.ColecionCajasTexto.Add(txtdireccion);
            Validador.ColecionCajasTexto.Add(txtCorreo);
            Validador.ColecionCajasTexto.Add(txtidentifiacion);
            Validador.ColecionCajasTexto.Add(txtApellidos);
            Validador.ColecionCajasTexto.Add(txtrtn);
            Validador.ColecionCajasTexto.Add(txttelefono);
            if (Validador.PermitirIngresar)
            {
                _PersonaNatural.NombreCompleto = txtNombre.Text;

                _PersonaNatural.identificacion = txtidentifiacion.Texto;
                _PersonaNatural.tipoidentidad = txtidentifiacion.TipoIdentificacion;
                _PersonaNatural.direccion = txtdireccion.Texto;
                _PersonaNatural.correo = txtCorreo.Texto;
                _PersonaNatural.rtn = txtrtn.Texto;
                _PersonaNatural.telefono = txttelefono.ValorInt;
                _PersonaNatural.Guardar();
                i = (Int32) _PersonaNatural.Id;
            }
            else
            {
                if (Errores != null)
                {
                    Errores(Validador.MensajesError);
                }
            }

            return i;
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
                if (Errores != null)
                {
                    Errores(ex.Message);
                }
            }
        }

        private void InicializarPersonaNatural()
        {
            if (_PersonaNatural == null)
            {
                _PersonaNatural = new PersonaNatural();
                _PersonaNatural.CambioId += _PersonaNatural_CambioId;
                _PersonaNatural.Errores += _PersonaNatural_Errores;
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
            txtNombre.Text = _PersonaNatural.NombreCompleto;

            txtCorreo.Text = _PersonaNatural.correo;
            txttelefono.Text = _PersonaNatural.telefono.ToString();
            txtidentifiacion.Text = _PersonaNatural.identificacion;
            cmbTipoIdentidad.SelectedItem = _PersonaNatural.tipoidentidad;
            txtdireccion.Text = _PersonaNatural.direccion;
            txtrtn.Text = _PersonaNatural.rtn;
        }

        private void BuscarTextbox()
        {
            InicializarPersonaNatural();

            if (txtApellidos.Text != string.Empty && txtNombre.Text != string.Empty)
            {
                //_PersonaNatural.Buscar(string.Empty, string.Empty, string.Empty, string.Empty, txtNombre.Text.Trim(), txtApellidos.Text.Trim());
                if (_PersonaNatural.TotalRegistros > 0)
                    CargarDatos();
            }
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
                    txtidentifiacion.TipoIdentificacion = (TipoIdentidad) cmbTipoIdentidad.SelectedItem;
                }
            }
            catch
            {
            }
        }

        private void _PersonaNatural_Errores(string Mensaje)
        {
        }

        private void crtlPersonaNatural_Load(object sender, EventArgs e)
        {
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            BuscarTextbox();
        }

        #endregion
    }
}