using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using SiCo.lgla;

namespace SiCo.ctrla.ControlesBasicos
{
    public partial class AutoCompleteCajaTexto : CajaTexto
    {
        #region Declaraciones

        //private Entidad _Entidad;
        private List<string> ListaAutoCompletado = new List<string>();
        private string _CampoMostrar = string.Empty;
        private int _CaracteresInicio = 3;
        private string _ParametroBusqueda = string.Empty;

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

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Parametro> ColeccionParametros
        {
            get { return null; }
            set { }
        }

        public string ParameteroBusqueda
        {
            get { return _ParametroBusqueda; }
            set { _ParametroBusqueda = value; }
        }

        public string CampoMostrar
        {
            get { return _CampoMostrar; }
            set { _CampoMostrar = value; }
        }

        public bool AutoCompletar { get; set; }

        public int CaracteresInicio
        {
            get { return _CaracteresInicio; }
            set { _CaracteresInicio = value; }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Entidad Entidad { get; set; }

        public string Procedimiento { get; set; }

        #endregion

        #region Metodos

        private void InicializarComponente()
        {
            AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteSource = AutoCompleteSource.CustomSource;
            TextChanged += AutoCompleteCajaTexto_TextChanged;
            AutoCompletar = true;
        }

        #endregion

        #region Eventos

        private void AutoCompleteCajaTexto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (AutoCompletar)
                {
                    if (Text.Length == CaracteresInicio)
                    {
                        if (!SubProceso.IsBusy)
                        {
                            var arg = new Argumento(Entidad, ParameteroBusqueda, Text);
                            Cursor = Cursors.WaitCursor;
                            if (!SubProceso.IsBusy) SubProceso.RunWorkerAsync(arg);
                        }
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
                var en = (Argumento) e.Argument;
                en._Entidad.Buscar(en.ParaBusqueda, en.valor);
            }
        }

        private void SubProceso_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Cursor = Cursors.Default;
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Entidad.TotalRegistros > 0)
            {
                AutoCompleteCustomSource.Clear();
                for (int x = 0; x < Entidad.TotalRegistros; x++)
                {
                    if ((string) Entidad.Registro(x, CampoMostrar) != "")
                        AutoCompleteCustomSource.Add((string) Entidad.Registro(x, CampoMostrar));
                }
            }
        }

        #endregion

        #region ClaseArgumento

        private class Argumento
        {
            public readonly string ParaBusqueda;
            public readonly Entidad _Entidad;
            public readonly string valor;

            public Argumento(Entidad entidad, string parametro, string val)
            {
                _Entidad = entidad;
                ParaBusqueda = parametro;
                valor = val;
            }
        }

        #endregion
    }
}