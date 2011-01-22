using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms ;

namespace SiCo.ctrla
{
    public partial class Grid : DataGridView
    {
        #region Declaraciones

        public event GridEditarEventHandler Editar;
        public event GridEliminarEventHandler Eliminar;

        private bool _BotonEditar = false;
        private bool _BotoElimar = false;
        private bool _AgregadoBotonEditar = false;
        private bool _AgregadoBotonEliminar = false;
        private List<GridFormatoColumnas> _ListaFormatos= new List<GridFormatoColumnas> ();

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

        public string CampoId
        {
            get;
            set;
        }

        public bool BotonEditar
        {
            get 
            {
                return _BotonEditar; 
            }
            set 
            {
                _BotonEditar = value;

                VisiblesColumnasEditarEliminar(); 

            }
        }

        public bool BotonEliminar
        {
            get             
            {
                return _BotoElimar;
            }
            set 
            {
                _BotoElimar = value;

                VisiblesColumnasEditarEliminar();
            }
        }

        public object Item
        {
            get
            {
                if(this.CurrentRow.DataBoundItem !=null)
                return this.CurrentRow.DataBoundItem;

                return null;
            }
        }

        #endregion

        #region Eventos

        void Grid_DataSourceChanged(object sender, EventArgs e)
        {
            if (this.DataSource != null)
            {
                FormatoColumnas();
                if (this.BotonEditar && !_AgregadoBotonEditar)
                {
                    DataGridViewButtonColumn columna = new DataGridViewButtonColumn();
                    columna.Text = "Editar";
                    columna.HeaderText = "Editar";
                    columna.Name = "BtnEditar";
                    columna.Resizable = DataGridViewTriState.False;
                    columna.ReadOnly = true;
                    columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    columna.UseColumnTextForButtonValue = true;

                    this.Columns.Add(columna);
                    _AgregadoBotonEditar = true;

                }
                if (this.BotonEliminar && !_AgregadoBotonEliminar)
                {
                    DataGridViewButtonColumn columna = new DataGridViewButtonColumn();
                    columna.Text = "Eliminar";
                    columna.HeaderText = "Eliminar";
                    columna.Name = "BtnEliminar";
                    columna.Resizable = DataGridViewTriState.False;
                    columna.ReadOnly = true;
                    columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    columna.UseColumnTextForButtonValue = true;

                    this.Columns.Add(columna);
                    _AgregadoBotonEliminar = true;

                }
            }
        }

        void Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (this.Columns[e.ColumnIndex].Name == "BtnEditar")
            {
                GridEditarEventArg h = new GridEditarEventArg();

                h.Fila = this.Rows[e.RowIndex];
                if (CampoId != null)
                {
                    h.Id = Convert.ToInt32 (this.Rows[e.RowIndex].Cells[CampoId].ToString());
                }
                {
                    h.Id = 0;
                }

                h.IndiceColumna = e.ColumnIndex;
                h.IndiceFila = e.RowIndex;

                if (Editar != null)
                    Editar(h);
            }

            if (this.Columns[e.ColumnIndex].Name == "BtnEliminar")
            {

                GridEliminarEventArg h = new GridEliminarEventArg();

                h.Fila = this.Rows[e.RowIndex];
                if (CampoId != null)
                {
                    
                    h.Id = Convert.ToInt32(this.Rows[e.RowIndex].Cells[CampoId].ToString());
                }
                else
                {
                    h.Id = 0 ;
                }

                h.IndiceColumna = e.ColumnIndex;
                h.IndiceFila = e.RowIndex;

                if (Eliminar  != null)
                    Eliminar (h);
                
            }


        }

        #endregion

        #region Metodos

        private void InicializarDelegados()
        {
            
            this.DataSourceChanged += new EventHandler(Grid_DataSourceChanged);
            this.CellContentClick += new DataGridViewCellEventHandler(Grid_CellContentClick);
        }        

        private void FormatoDefectoGeneral()
        {            
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.MultiSelect = false;
            this.RowHeadersVisible = false;
        }

        private void FormatoColumnas()
        {
            foreach (DataGridViewColumn i in this.Columns)
            {
                i.Visible = false;
            }

            foreach (GridFormatoColumnas f in _ListaFormatos)
            {
                if (this.Columns.Contains(f.ColumnaNombre))
                {

                    DataGridViewTextBoxColumn c = new DataGridViewTextBoxColumn();
                    c.HeaderText=f.ColumnaTitulo ;
                    c.Name = f.ColumnaNombre;
                    c.DataPropertyName = f.ColumnaNombre;
                    c.Visible = f.Visible;                    
                     this.Columns.Add(c);
                    
                }     
            }            
        }        

        private void VisiblesColumnasEditarEliminar()
        {
            if(this.Columns.Contains("BtnEditar"))
            {
                this.Columns["BtnEditar"].Visible = this.BotonEditar;
            }

            if (this.Columns.Contains("BtnEliminar"))
            {
                this.Columns["BtnEliminar"].Visible = this.BotonEliminar;
            }
            
        }
        
        public void DarFormato(GridFormatoColumnas ColumnaFormato)
        {
            _ListaFormatos.Add(ColumnaFormato);
            FormatoColumnas();
        }

        public void DarFormato(GridFormatoColumnas[] ColumnaFormato)
        {
            foreach(GridFormatoColumnas f in ColumnaFormato )
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

        public void DarFormato(string ColumnaNombre, string ColumnaTitulo,bool SoloLectura)
        {
            _ListaFormatos.Add(new GridFormatoColumnas(ColumnaNombre, ColumnaTitulo,SoloLectura));
            FormatoColumnas();
        }

        public void DarFormato(string ColumnaNombre, string ColumnaTitulo, bool SoloLectura, bool Visible)
        {
            _ListaFormatos .Add(new GridFormatoColumnas (ColumnaNombre,ColumnaTitulo,SoloLectura,Visible));
            FormatoColumnas();
        }        


        #endregion           

    }
}
