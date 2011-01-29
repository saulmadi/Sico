using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using SiCo.lgla;
using System.Windows.Forms;

namespace SiCo.ctrla.ControlesBasicos
{
    public partial class AutoCompleteCajaTexto : SiCo.ctrla.CajaTexto
    {
        #region Declaraciones
        //private Entidad _Entidad;
        private string _ParametroBusqueda = string.Empty;
        private string _CampoMostrar = string.Empty;
        private Entidad _Entidad;                
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
            get { return null ; }
	            set  {
	                
	                
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
            get { return _CampoMostrar; }
            set { _CampoMostrar = value; }
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

        public Entidad Entidad
        {
            get { return _Entidad; }
            set { _Entidad = value; }
        }

        public string Procedimiento
        {
            get;
            set;
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
                        if (!SubProceso.IsBusy)
                        {
                            Argumento arg = new Argumento(this.Entidad, this.ParameteroBusqueda, this.Text);
                            this.Cursor = Cursors.WaitCursor; 
                            if (!SubProceso.IsBusy) SubProceso.RunWorkerAsync(arg);
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);     
                
            }
        }

        private void SubProceso_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument != null)
            {
                Argumento  en = (Argumento)e.Argument;
                en._Entidad.Buscar(en.ParaBusqueda, en.valor);    
            }
        }

        private void SubProceso_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Cursor = Cursors.Default;
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            if (Entidad.TotalRegistros > 0)
            {
                
                this.AutoCompleteCustomSource.Clear();
                for (int x = 0; x < Entidad.TotalRegistros; x++)
                { 
                    if ((string)Entidad.Registro(x,CampoMostrar) !="")
                        this.AutoCompleteCustomSource.Add((string)Entidad.Registro(x, CampoMostrar));
                }                
            }
            
        }

        #endregion

        private class Argumento
        {
            public Entidad _Entidad ;
            public string  ParaBusqueda;
            public string valor;
            public Argumento(Entidad entidad,string parametro, string val)
            {
                this._Entidad = entidad;
                this.ParaBusqueda = parametro;
                this.valor = val;
            } 
        }        
    }

}