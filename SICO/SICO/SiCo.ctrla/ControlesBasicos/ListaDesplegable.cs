using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SiCo.lgla; 


namespace SiCo.ctrla
{
    public partial class ListaDesplegable : ComboBox
    {
        #region Declaraciones
        public event ErroresEventsArgs  Errores;
        private ListaDesplegable _ListaDesplegable ;
        private Entidad _Entidad = new Entidad();
        
        #endregion

        #region Construtores

        public ListaDesplegable()
        {
            InitializeComponent();

            InicializarDelegados();
        }

        public ListaDesplegable(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            InicializarDelegados();
        }

        #endregion

        #region Propiedades

        public ListaDesplegable ListaDesplegablePadre
        {
            get
            {
                return _ListaDesplegable;
            }
            set
            {
                _ListaDesplegable =  value;
                if(value!=null)
                _ListaDesplegable.SelectedIndexChanged += new EventHandler(_ListaDesplegable_SelectedIndexChanged);
            }
        }

        public string Comando
        {
            get;
            set;
        }

        #endregion       

        public string  ParametroBusqueda
        {
            get;
            set;
        }

        #region Eventos

        void _ListaDesplegable_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                _Entidad.LlenadoTabla(this.Comando, new Parametro[] {new Parametro( this.ParametroBusqueda,_ListaDesplegable.SelectedValue )}) ;

                if (_Entidad.TotalRegistros > 0)
                {
                    this.DataSource = null;
                    this.DataSource = _Entidad.Tabla;
                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
 
            }
        }

        void _Entidad_Errores(string Mensaje)
        {
            this.Errores(Mensaje);
        }

        #endregion

        #region Metodos

        private void InicializarDelegados()
        {
            
            _Entidad.Errores += new SiCo.lgla.ErroresEventsArgs(_Entidad_Errores); 
 
        }

        #endregion
        
    }
}
