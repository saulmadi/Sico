using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace SiCo.ctrla
{
    public partial class Grid : DataGridView
    {
        #region Declaraciones

        private readonly List<GridFormatoColumnas> _ListaFormatos = new List<GridFormatoColumnas>();
        private bool _BotoElimar;
        private bool _BotonBuscar;
        private bool _BotonEditar;
        public event GridEditarEventHandler Editar;
        public event GridEliminarEventHandler Eliminar;
        public event GridBuscarEventHandler Buscar;

        #endregion

        #region Constructores

        public Grid()
        {
            InitializeComponent();
            InicializarDelegados();
            FormatoDefectoGeneral();
        }

        public Grid(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            InicializarDelegados();
            FormatoDefectoGeneral();
        }

        #endregion

        #region Propiedades

        public string CampoId { get; set; }

        public bool BotonEditar
        {
            get { return _BotonEditar; }
            set
            {
                _BotonEditar = value;

                VisiblesColumnasEditarEliminar();
            }
        }

        public bool BotonEliminar
        {
            get { return _BotoElimar; }
            set
            {
                _BotoElimar = value;

                VisiblesColumnasEditarEliminar();
            }
        }

        public bool BotonBuscar
        {
            get { return _BotonBuscar; }
            set
            {
                _BotonBuscar = value;
                VisiblesColumnasEditarEliminar();
            }
        }

        public object Item
        {
            get
            {
                if (CurrentRow != null)
                    if (CurrentRow.DataBoundItem != null)
                        return CurrentRow.DataBoundItem;

                return null;
            }
        }

        public List<GridFormatoColumnas> ListaFormatos
        {
            get { return _ListaFormatos; }
        }

        #endregion

        #region Eventos

        private void Grid_DataSourceChanged(object sender, EventArgs e)
        {
            if (DataSource != null)
            {
                FormatoColumnas();
                if (BotonEditar)
                {
                    var columna = new DataGridViewButtonColumn();
                    columna.Text = "Ver";
                    columna.HeaderText = "Ver";
                    columna.Name = "BtnEditar";
                    columna.Resizable = DataGridViewTriState.False;
                    columna.ReadOnly = true;
                    columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    columna.UseColumnTextForButtonValue = true;
                    columna.Visible = true;
                    Columns.Add(columna);
                }

                if (BotonBuscar)
                {
                    var columna = new DataGridViewButtonColumn();
                    columna.Text = "Buscar";
                    columna.HeaderText = "Buscar";
                    columna.Name = "BtnBuscar";
                    columna.Resizable = DataGridViewTriState.False;
                    columna.ReadOnly = true;
                    columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    columna.UseColumnTextForButtonValue = true;
                    columna.Visible = true;
                    Columns.Add(columna);
                }

                if (BotonEliminar)
                {
                    var columna = new DataGridViewButtonColumn();
                    columna.Text = "Eliminar";
                    columna.HeaderText = "Eliminar";
                    columna.Name = "BtnEliminar";
                    columna.Resizable = DataGridViewTriState.False;
                    columna.ReadOnly = true;
                    columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    columna.UseColumnTextForButtonValue = true;
                    columna.Visible = true;
                    Columns.Add(columna);
                }
            }
        }

        private void Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Columns[e.ColumnIndex].Name == "BtnEditar")
            {
                if (e.RowIndex >= 0)
                {
                    var h = new GridEditarEventArg();
                    try
                    {
                        if (CampoId != null)
                        {
                            h.Id = Convert.ToInt32(Rows[e.RowIndex].Cells[CampoId].ToString());
                        }
                        {
                            h.Id = 0;
                        }
                        if (e.RowIndex > 0)
                            h.Fila = Rows[e.RowIndex];
                    }
                    catch
                    {
                    }


                    h.IndiceColumna = e.ColumnIndex;
                    h.IndiceFila = e.RowIndex;

                    if (Editar != null)
                        Editar(h);
                }
            }
            if (Columns[e.ColumnIndex].Name == "BtnBuscar")
            {
                if (e.RowIndex >= 0)
                    if (Buscar != null)
                        Buscar();
            }

            if (Columns[e.ColumnIndex].Name == "BtnEliminar")
            {
                if (e.RowIndex >= 0)
                {
                    var h = new GridEliminarEventArg();

                    h.Fila = Rows[e.RowIndex];
                    if (CampoId != null)
                    {
                        try
                        {
                            h.Id = Convert.ToInt32(Rows[e.RowIndex].Cells[CampoId].Value.ToString());
                        }
                        catch
                        {
                            h.Id = 0;
                        }
                    }
                    else
                    {
                        h.Id = 0;
                    }

                    h.IndiceColumna = e.ColumnIndex;
                    h.IndiceFila = e.RowIndex;

                    if (Eliminar != null)
                        Eliminar(h);
                }

                Refresh();
            }
        }

        private void Grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Refresh();
        }

        #endregion

        #region Metodos

        private void InicializarDelegados()
        {
            DataSourceChanged += Grid_DataSourceChanged;
            CellContentClick += Grid_CellContentClick;
            DataError += Grid_DataError;
            CellEndEdit += Grid_CellEndEdit;
        }


        private void FormatoDefectoGeneral()
        {
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            MultiSelect = false;
            RowHeadersVisible = false;
        }

        private void FormatoColumnas()
        {
            foreach (DataGridViewColumn i in Columns)
            {
                i.Visible = false;
            }

            foreach (GridFormatoColumnas f in _ListaFormatos)
            {
                if (Columns.Contains(f.ColumnaNombre))
                {
                    var c = new DataGridViewTextBoxColumn();
                    c.HeaderText = f.ColumnaTitulo;
                    c.Name = f.ColumnaNombre;
                    c.DataPropertyName = f.ColumnaNombre;
                    c.Visible = f.Visible;
                    Columns.Add(c);
                }
            }
        }

        private void VisiblesColumnasEditarEliminar()
        {
            if (Columns.Contains("BtnEditar"))
            {
                Columns["BtnEditar"].Visible = BotonEditar;
            }

            if (Columns.Contains("BtnEliminar"))
            {
                Columns["BtnEliminar"].Visible = BotonEliminar;
            }
            if (Columns.Contains("BtnBuscar"))
            {
                Columns["BtnBuscar"].Visible = BotonEliminar;
            }
        }

        public void DarFormato(GridFormatoColumnas ColumnaFormato)
        {
            _ListaFormatos.Add(ColumnaFormato);
            FormatoColumnas();
        }

        public void DarFormato(GridFormatoColumnas[] ColumnaFormato)
        {
            foreach (GridFormatoColumnas f in ColumnaFormato)
            {
                _ListaFormatos.Add(f);
            }
            FormatoColumnas();
        }

        public void DarFormato(string ColumnaNombre, string ColumnaTitulo)
        {
            _ListaFormatos.Add(new GridFormatoColumnas(ColumnaNombre, ColumnaTitulo));
            FormatoColumnas();
        }

        public void DarFormato(string ColumnaNombre, string ColumnaTitulo, bool SoloLectura)
        {
            _ListaFormatos.Add(new GridFormatoColumnas(ColumnaNombre, ColumnaTitulo, SoloLectura));
            FormatoColumnas();
        }

        public void DarFormato(string ColumnaNombre, string ColumnaTitulo, bool SoloLectura, bool Visible)
        {
            _ListaFormatos.Add(new GridFormatoColumnas(ColumnaNombre, ColumnaTitulo, SoloLectura, Visible));
            FormatoColumnas();
        }

        #endregion
    }
}