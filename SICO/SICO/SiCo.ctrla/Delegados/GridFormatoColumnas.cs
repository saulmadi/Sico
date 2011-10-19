namespace SiCo.ctrla
{
    public class GridFormatoColumnas
    {
        #region Constructores

        public GridFormatoColumnas(string ColumnaNombre, string ColumnaTitulo)
        {
            this.ColumnaNombre = ColumnaNombre;
            this.ColumnaTitulo = ColumnaTitulo;
            SoloLectura = true;
            Visible = true;
        }

        public GridFormatoColumnas(string ColumnaNombre, string ColumnaTitulo, bool SoloLectura)
        {
            this.ColumnaNombre = ColumnaNombre;
            this.ColumnaTitulo = ColumnaTitulo;
            this.SoloLectura = SoloLectura;
            Visible = true;
        }

        public GridFormatoColumnas(string ColumnaNombre, string ColumnaTitulo, bool SoloLectura, bool Visible)
        {
            this.ColumnaNombre = ColumnaNombre;
            this.ColumnaTitulo = ColumnaTitulo;
            this.SoloLectura = SoloLectura;
            this.Visible = Visible;
        }

        #endregion

        #region Propiedades

        public string ColumnaNombre { get; set; }

        public string ColumnaTitulo { get; set; }

        public bool Visible { get; set; }

        public bool SoloLectura { get; set; }

        #endregion
    }
}