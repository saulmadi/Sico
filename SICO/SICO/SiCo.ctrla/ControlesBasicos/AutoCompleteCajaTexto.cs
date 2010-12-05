using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using SiCo.lgla; 

namespace SiCo.ctrla.ControlesBasicos
{
    public partial class AutoCompleteCajaTexto : SiCo.ctrla.CajaTexto
    {
        #region Declaraciones
        private Entidad _Entidad;
        #endregion

        #region Constructor

        public AutoCompleteCajaTexto()
        {
            InitializeComponent();
            InicializarComponente();
        }


        public AutoCompleteCajaTexto(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            InicializarComponente();

        }
        #endregion

        public System.Collections.Generic.List<Parametro> ColeccionParametros
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public string ParameteroBusqueda
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public string Procedimiento
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        #region Propiedades
        #endregion

        #region Metodos

        private void InicializarComponente()
        {
            this.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TextChanged += new EventHandler(AutoCompleteCajaTexto_TextChanged);           
        }       

        private void InicializarEntidad()
        {
            if (_Entidad == null)
            {
                _Entidad = new Entidad();
            }
        }


        #endregion

        #region Eventos

        void AutoCompleteCajaTexto_TextChanged(object sender, EventArgs e)
        {

        }

        #endregion
    }

}