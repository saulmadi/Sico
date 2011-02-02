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
            this.CargarComboBox = true; 
        }

        public ListaDesplegable(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            this.CargarComboBox = true; 
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
                if (value != null)
                {
                    _ComboBoxPadre.SelectedIndexChanged += new EventHandler(_ListaDesplegable_SelectedIndexChanged);
                    _ComboBoxPadre.TextChanged += new EventHandler(_ComboBoxPadre_TextChanged);
                }
                    
            }
        }        

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Advanced)]
        public Entidad Entidad
        {
            get { return _Entidad; }
            
            set 
            {
                _Entidad = value;
               
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),EditorBrowsable(EditorBrowsableState.Advanced) ]
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

        public string ParametroBusquedaPadre
        {
            get;
            set;
        }

        public Boolean CargarComboBox
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
                this.Cursor = Cursors.WaitCursor;
                if (this.CargarComboBox)
                {
                    if (_ComboBoxPadre.SelectedValue != null && _ComboBoxPadre.SelectedIndex > -1)
                    {
                        Argumento arg = new Argumento(this.Entidad, this.ColeccionParametros, this.ParametroBusquedaPadre, _ComboBoxPadre.SelectedValue.ToString());

                        List<Parametro> p = new List<Parametro>();
                        foreach (ParametrosListaDesplegable i in arg.Coleccion)
                        {
                            p.Add(i);
                        }
                        p.Add(new Parametro(arg.NombreParametro, arg.ValorParametro));
                        arg.Entidad.Buscar(p);
                        string d = DisplayMember;
                        string v = ValueMember;
                        this.DataSource = null;
                        this.DataSource = Entidad.TablaAColeccion();
                        this.DisplayMember = d;
                        this.ValueMember = v;
                        this.Cursor = Cursors.Default;
                        this.SelectedIndex = -1;  
                    }
                }

                this.Cursor = Cursors.Default ;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error)  ;

            }
        }

        void _ComboBoxPadre_TextChanged(object sender, EventArgs e)
        {
            if ( _ComboBoxPadre.SelectedIndex == -1)
            {
                string d = DisplayMember;
                string v = ValueMember;
                this.DataSource = null;
                this.DisplayMember = d;
                this.ValueMember = v;
 
            }
        }

        private void SubProceso_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error !=null)
            {
                MessageBox.Show(e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Cursor = Cursors.Default;
                return;                
            }

            if (Entidad.TotalRegistros > 0)
            {
                string d = DisplayMember;
                string v = ValueMember;
                this.DataSource = null;
                this.DataSource = Entidad.TablaAColeccion();
                this.DisplayMember = d;
                this.ValueMember = v;
                this.Cursor = Cursors.Default;
                this.SelectedIndex = -1;
            }
            else
            {
                string d = DisplayMember;
                string v = ValueMember;
                this.DataSource = null;
                this.DisplayMember = d;
                this.ValueMember = v;
            }
            this.Cursor = Cursors.Default; 
        }

        private void SubProceso_DoWork(object sender, DoWorkEventArgs e)
        {
            Argumento a = (Argumento)e.Argument;

            if (a.Coleccion == null && a.NombreParametro.Length==0 )
            {
                a.Entidad.Buscar();
            }
            else
            {
                if (a.Coleccion != null && a.NombreParametro.Length == 0)
                {
                    List<Parametro> p = new List<Parametro>();
                    foreach (ParametrosListaDesplegable i in a.Coleccion)
                    {
                        p.Add(i);
                    }

                    a.Entidad.Buscar(p);
                }
                else
                {
                    if (a.Coleccion != null)
                    {
                        List<Parametro> p = new List<Parametro>();
                        foreach (ParametrosListaDesplegable i in a.Coleccion)
                        {
                            p.Add(i);
                        }
                        p.Add(new Parametro(a.NombreParametro, a.ValorParametro));
                        a.Entidad.Buscar(p);
                    }
                }
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
            this.Cursor = Cursors.WaitCursor;
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
            this.Cursor = Cursors.WaitCursor;
            if (Entidad != null)
            {
                if (!SubProceso.IsBusy)
                {
                    Argumento o = new Argumento(Entidad, ColeccionParametros);
                    SubProceso.RunWorkerAsync(o);
                } 
            }
        }
       

        public void Limpiar()
        {
            try
            {
                if (this.SubProceso.IsBusy)
                {
                    this.SubProceso.CancelAsync();
                    while( this.SubProceso.CancellationPending);    
                }

 
                string d = DisplayMember;
                string v = ValueMember;
                this.DataSource = null;
                this.DisplayMember = d;
                this.ValueMember = v;
            }
            catch 
            { 
            }
        }

        #endregion

        #region ClaseParametros
        [Serializable() ]
        public class ParametrosListaDesplegable : SiCo.lgla.Parametro
        {
            public ParametrosListaDesplegable(string nombre, object valor)
                : base(nombre, valor)
            {
 
            }

        }

        #endregion

        #region ClaseArgumento
        private class Argumento
        {
            public List<ParametrosListaDesplegable> Coleccion = null ;
            public Entidad Entidad;
            public string NombreParametro=string.Empty ;
            public string ValorParametro = string.Empty;

            public Argumento( Entidad entidad)
            {
                Entidad = entidad;
            }
            public Argumento(Entidad entidad, List<ParametrosListaDesplegable> coleccion)
            {
                Coleccion = coleccion;
                Entidad = entidad;
            }
            public Argumento(Entidad entidad,List<ParametrosListaDesplegable> coleccion, String nombreParametro, string valorParametro)
            {
                this.Entidad = entidad;
                this.NombreParametro = nombreParametro;
                this.ValorParametro = valorParametro;
                this.Coleccion = coleccion;  
            }
        }
        #endregion      

    }
}
