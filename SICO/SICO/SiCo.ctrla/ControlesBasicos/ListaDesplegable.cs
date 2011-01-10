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
        private ComboBox _ComboBoxPadre = new ComboBox();       
       
        private List<ParametrosListaDesplegable> _ColeccionParametros = new List<ParametrosListaDesplegable> ();
       [NonSerialized()]  private Entidad _Entidad;
        
        
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

        public ComboBox ListaDesplegablePadre
        {
            get
            {
                return _ComboBoxPadre ;
            }
            set
            {
                _ComboBoxPadre = value;
                if(value!=null)
                    _ComboBoxPadre.SelectedIndexChanged += new EventHandler(_ListaDesplegable_SelectedIndexChanged);
            }
        }
        
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Entidad Entidad
        {
            get { return _Entidad; }
            
            set 
            {
                _Entidad = value;
                if (value != null)                
                    value.Errores += new ErroresEventHandler(value_Errores);
                
            }

        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Comando
        {
            get;
            set;
        }


        public string ParametroAutocompletar
        {
            get;
            set;
        }

        public Boolean CargarAutoCompletar
        {
            get;
            set;
        }

        [Browsable(false),DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<ParametrosListaDesplegable> ColeccionParametros
        {
            get
            {
                return _ColeccionParametros;
            }
            set
            {
                _ColeccionParametros = value;
            }
        }

        #endregion       

        #region Eventos

        void _ListaDesplegable_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    _Entidad = new EntidadInstanciable ();
            //    _Entidad.LlenadoTabla(this.Comando,this.ColeccionParametroBusqueda) ;

            //    if (_Entidad.TotalRegistros > 0)
            //    {
            //        this.DataSource = null;
            //        this.DataSource = _Entidad.Tabla;
            //    }

            //}
            //catch (Exception ex)
            //{
            //    ex.Message.ToString();
 
            //}
        }
        
        void value_Errores(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
        }

        private void SubProceso_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (Entidad.TotalRegistros > 0)
            {
                string d = DisplayMember; 
                string v= ValueMember ;
                this.DataSource = null;
                this.DataSource = Entidad.TablaAColeccion();
                this.DisplayMember = d;
                this.ValueMember = v;
                this.Cursor = Cursors.Default;
                this.SelectedIndex = -1;
            }
        }

        private void SubProceso_DoWork(object sender, DoWorkEventArgs e)
        {
            Argumento a = (Argumento)e.Argument;

            if (a.Coleccion == null)
            {
                a.Entidad.Buscar();
            }
            else
            {
                List<Parametro> p = new List<Parametro>();
                foreach (ParametrosListaDesplegable i in a.Coleccion)
                {
                    p.Add(i);
                }

                a.Entidad.Buscar(p);
            }
        }

        #endregion

        #region Metodos

        public void ValorParametros(string Nombre, object valor)
        {

            foreach (Parametro i in this.ColeccionParametros)
            {
                if (i.Nombre.ToLower() == Nombre.ToLower())
                {
                    i.Valor = valor;
                    return;
                }
            }
            throw new ApplicationException("El parámetro no se encuentra en la colección");
        }

        public void NullParametros()
        {
            foreach (Parametro i in this.ColeccionParametros)
            {
                i.Valor = null;
            }
        }

        public  void CargarEntidad()
        {
           if (Entidad !=null)
            {
                if (!SubProceso.IsBusy)
                {
                    this.Cursor = Cursors.WaitCursor;
                    Argumento o = new Argumento(Entidad);
                    SubProceso.RunWorkerAsync(o); 
                }
            }
        }

        public void CargarParametros()
        {
            if (Entidad != null)
            {
                if (SubProceso.IsBusy)
                {
                    Argumento o = new Argumento(Entidad, ColeccionParametros);
                    SubProceso.RunWorkerAsync(o);
                } 
            }
        }

       

        #endregion

        #region ClaseParametros
        [Serializable() ]
        public class ParametrosListaDesplegable : SiCo.lgla.Parametro
        {

        }

        #endregion

        #region ClaseArgumento
        private class Argumento
        {
            public List<ParametrosListaDesplegable> Coleccion = null ;
            public Entidad Entidad;

            public Argumento( Entidad entidad)
            {
                Entidad = entidad;
            }
            public Argumento(Entidad entidad, List<ParametrosListaDesplegable> coleccion)
            {
                Coleccion = coleccion;
                Entidad = entidad;
            }
        }
        #endregion      

    }
}
