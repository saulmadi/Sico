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
        private List<lgla.TipoIdentidad> _ColeccionTipoIdentidad = new List<TipoIdentidad>();
        #endregion

        public event ErroresEventsHandler Errores;

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
        }

        #endregion

        #region Propiedad
        public List<lgla.TipoIdentidad> ColeccionTipoIdentidad
        {
            get { return _ColeccionTipoIdentidad; }
        }
        #endregion       

        #region Metodos
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
            }
        }       

        #endregion

        #region Eventos
        void _PersonaNatural_CambioId()
        {

        }
        #endregion

        private void cmbTipoIdentidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbTipoIdentidad.SelectedItem != null)
                {
                    txtidentifiacion.TipoIdentificacion = (TipoIdentidad)cmbTipoIdentidad.SelectedItem; 
                }

            }
            catch (Exception ex)
            {               
                
            }
        }

    }
}
