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
        private EntidadInstanciable _Entidad;
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

        private void InicializarEntidad()
        {
            if (_Entidad == null)
            {
                _Entidad = new EntidadInstanciable();
            }
        }


        #endregion

        #region Eventos

        void AutoCompleteCajaTexto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if(this.AutoCompletar)
                {
                    InicializarEntidad();
                    if (this.Text.Length == this.CaracteresInicio)
                    {
                        if (ColeccionParametros.Count > 0 && this.Procedimiento.Length > 0)
                        {
                            int val = 0;
                            foreach (SiCo.lgla.Parametro p in ColeccionParametros)
                            {
                                if (p.Nombre == this.ParameteroBusqueda)
                                {
                                    p.Valor = this.Text.Trim();
                                    val++;
                                }
                                
                            }
                            if (val >0 && this.ParameteroBusqueda.Length>0)
                            {
                                _Entidad.LlenadoTabla(this.Procedimiento, ColeccionParametros);
                                if (_Entidad.TotalRegistros > 0)
                                {
                                    for (int x = 0; x < _Entidad.TotalRegistros; x++)
                                    {
                                        AutoCompleteCustomSource.Add(_Entidad.Registro(x, this.CampoMostrar).ToString());
                                    }
                                }
                            }
                            else
                                throw new ApplicationException("El parametro de busqueda: " + this.ParameteroBusqueda + " no se encuentra en la colección");
                        }

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