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
        public event ErroresEventsHandler  Errores;
        private ListaDesplegable _ListaDesplegable ;
        private Entidad _Entidad ;
        private List<Parametro> _ColeccionParametro= new List<Parametro> ();
        
        #endregion

        #region Construtores

        public ListaDesplegable()
        {
            InitializeComponent();          
        }

        public ListaDesplegable(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
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
        
        public List<Parametro>  ColeccionParametroBusqueda
        {
            get {return  _ColeccionParametro; }            
        }

        public string Comando
        {
            get;
            set;
        }

        #endregion       

        #region Eventos

        void _ListaDesplegable_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _Entidad = new Entidad();
                _Entidad.LlenadoTabla(this.Comando,this.ColeccionParametroBusqueda) ;

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

       

        #endregion
        
    }
}
