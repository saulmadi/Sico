using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using SiCo.lgla;

namespace SiCo.ctrla
{
    public partial class ListaDesplegable : ComboBox
    {
        #region Declaraciones

        private List<ParametrosListaDesplegable> _ColeccionParametros = new List<ParametrosListaDesplegable>();
        private ComboBox _ComboBoxPadre = new ComboBox();
        [NonSerialized] private Entidad _Entidad;

        #endregion

        #region Construtores

        public ListaDesplegable()
        {
            InitializeComponent();
            CargarComboBox = true;
        }

        public ListaDesplegable(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            CargarComboBox = true;
        }

        #endregion

        #region Propiedades

        public ComboBox ListaDesplegablePadre
        {
            get { return _ComboBoxPadre; }
            set
            {
                _ComboBoxPadre = value;
                if (value != null)
                {
                    _ComboBoxPadre.SelectedIndexChanged += _ListaDesplegable_SelectedIndexChanged;
                    _ComboBoxPadre.TextChanged += _ComboBoxPadre_TextChanged;
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
         EditorBrowsable(EditorBrowsableState.Advanced)]
        public Entidad Entidad
        {
            get { return _Entidad; }

            set { _Entidad = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Comando { get; set; }


        public string ParametroAutocompletar { get; set; }

        public Boolean CargarAutoCompletar { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
         EditorBrowsable(EditorBrowsableState.Advanced)]
        public List<ParametrosListaDesplegable> ColeccionParametros
        {
            get { return _ColeccionParametros; }
            set { _ColeccionParametros = value; }
        }

        public string ParametroBusquedaPadre { get; set; }

        public Boolean CargarComboBox { get; set; }

        #endregion

        #region Eventos

        private void _ListaDesplegable_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (CargarComboBox)
                {
                    if (_ComboBoxPadre.SelectedValue != null && _ComboBoxPadre.SelectedIndex > -1)
                    {
                        var arg = new Argumento(Entidad, ColeccionParametros, ParametroBusquedaPadre,
                                                _ComboBoxPadre.SelectedValue.ToString());

                        var p = new List<Parametro>();
                        foreach (ParametrosListaDesplegable i in arg.Coleccion)
                        {
                            p.Add(i);
                        }
                        p.Add(new Parametro(arg.NombreParametro, arg.ValorParametro));
                        arg.Entidad.Buscar(p);
                        string d = DisplayMember;
                        string v = ValueMember;
                        DataSource = null;
                        DataSource = Entidad.TablaAColeccion();
                        DisplayMember = d;
                        ValueMember = v;
                        Cursor = Cursors.Default;
                        SelectedIndex = -1;
                    }
                }

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _ComboBoxPadre_TextChanged(object sender, EventArgs e)
        {
            if (_ComboBoxPadre.SelectedIndex == -1)
            {
                string d = DisplayMember;
                string v = ValueMember;
                DataSource = null;
                DisplayMember = d;
                ValueMember = v;
            }
        }

        private void SubProceso_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor = Cursors.Default;
                return;
            }

            if (Entidad.TotalRegistros > 0)
            {
                string d = DisplayMember;
                string v = ValueMember;
                DataSource = null;
                DataSource = Entidad.TablaAColeccion();
                DisplayMember = d;
                ValueMember = v;
                Cursor = Cursors.Default;
                SelectedIndex = -1;
            }
            else
            {
                string d = DisplayMember;
                string v = ValueMember;
                DataSource = null;
                DisplayMember = d;
                ValueMember = v;
            }
            Cursor = Cursors.Default;
        }

        private void SubProceso_DoWork(object sender, DoWorkEventArgs e)
        {
            var a = (Argumento) e.Argument;

            if (a.Coleccion == null && a.NombreParametro.Length == 0)
            {
                a.Entidad.Buscar();
            }
            else
            {
                if (a.Coleccion != null && a.NombreParametro.Length == 0)
                {
                    var p = new List<Parametro>();
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
                        var p = new List<Parametro>();
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
            foreach (Parametro i in ColeccionParametros)
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
            foreach (Parametro i in ColeccionParametros)
            {
                i.Valor = null;
            }
        }

        public void CargarEntidad()
        {
            Cursor = Cursors.WaitCursor;
            if (Entidad != null)
            {
                if (!SubProceso.IsBusy)
                {
                    Cursor = Cursors.WaitCursor;
                    var o = new Argumento(Entidad);
                    SubProceso.RunWorkerAsync(o);
                }
            }
        }

        public void CargarParametros()
        {
            Cursor = Cursors.WaitCursor;
            if (Entidad != null)
            {
                if (!SubProceso.IsBusy)
                {
                    var o = new Argumento(Entidad, ColeccionParametros);
                    SubProceso.RunWorkerAsync(o);
                }
            }
        }

        public void IncializarCarga()
        {
            try
            {
                if (ColeccionParametros.Count == 0)
                    Entidad.Buscar();
                else
                {
                    var p = new List<Parametro>();
                    foreach (ParametrosListaDesplegable i in ColeccionParametros)
                    {
                        p.Add(i);
                    }
                    ;
                    Entidad.Buscar(p);
                }

                if (Entidad.TotalRegistros > 0)
                {
                    string d = DisplayMember;
                    string v = ValueMember;
                    DataSource = null;
                    DataSource = Entidad.TablaAColeccion();
                    DisplayMember = d;
                    ValueMember = v;
                    Cursor = Cursors.Default;
                    //this.SelectedIndex = -1;
                }
                else
                {
                    string d = DisplayMember;
                    string v = ValueMember;
                    DataSource = null;
                    DisplayMember = d;
                    ValueMember = v;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Limpiar()
        {
            try
            {
                if (SubProceso.IsBusy)
                {
                    SubProceso.CancelAsync();
                    while (SubProceso.CancellationPending) ;
                }


                string d = DisplayMember;
                string v = ValueMember;
                DataSource = null;
                DisplayMember = d;
                ValueMember = v;
            }
            catch
            {
            }
        }

        #endregion

        #region ClaseParametros

        [Serializable]
        public class ParametrosListaDesplegable : Parametro
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
            public readonly List<ParametrosListaDesplegable> Coleccion;
            public readonly Entidad Entidad;
            public readonly string NombreParametro = string.Empty;
            public readonly string ValorParametro = string.Empty;

            public Argumento(Entidad entidad)
            {
                Entidad = entidad;
            }

            public Argumento(Entidad entidad, List<ParametrosListaDesplegable> coleccion)
            {
                Coleccion = coleccion;
                Entidad = entidad;
            }

            public Argumento(Entidad entidad, List<ParametrosListaDesplegable> coleccion, String nombreParametro,
                             string valorParametro)
            {
                Entidad = entidad;
                NombreParametro = nombreParametro;
                ValorParametro = valorParametro;
                Coleccion = coleccion;
            }
        }

        #endregion
    }
}