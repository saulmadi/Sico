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
        //private Entidad _Entidad;
        private string _ParametroBusqueda = string.Empty;
        private List<SiCo.lgla.Parametro> _ColeccionParametros= new List<SiCo.lgla.Parametro  > ();
        public event ErroresEventsHandler Errores;
        private List<string> ListaAutoCompletado = new List<string>();
        private int _CaracteresInicio=3;
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
       
        #region Propiedades

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public  System.Collections.Generic.List<SiCo.lgla.Parametro> ColeccionParametros
        {
            get { return _ColeccionParametros; }
            set
            {
                if(value !=null)
                _ColeccionParametros = value ;
            }
        }

        public string ParameteroBusqueda
        {
            get { return _ParametroBusqueda; }
            set 
            {
                
                    _ParametroBusqueda = value; 
            }
        }

        public string CampoMostrar
        {
            get;
            set;
        }

        public string Procedimiento
        {
            get;
            set;
        }

        public bool AutoCompletar
        {
            get;
            set;
        }

        public int CaracteresInicio
        {
            get { return _CaracteresInicio; }
            set { _CaracteresInicio = value; }
        }
        
        #endregion

        #region Metodos

        private void InicializarComponente()
        {
            this.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TextChanged += new EventHandler(AutoCompleteCajaTexto_TextChanged);
            this.AutoCompletar = true;          
        }       

        


        #endregion

        #region Eventos

        void AutoCompleteCajaTexto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if(this.AutoCompletar)
                {
                    
                    if (this.Text.Length == this.CaracteresInicio)
                    {
                        
                    }
                    else
                    {
                        this.AutoCompleteCustomSource.Clear();  
                    }
                }
            }
            catch (Exception ex)
            {

                if (this.Errores != null)
                    this.Errores(ex.Message);
            }
        }

        #endregion
    }

}