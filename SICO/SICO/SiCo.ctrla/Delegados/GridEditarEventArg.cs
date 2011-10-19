using System.Windows.Forms;

namespace SiCo.ctrla
{
    public class GridEditarEventArg
    {
        #region Propiedades

        public int Id { get; set; }

        public DataGridViewRow Fila { get; set; }

        public int IndiceFila { get; set; }

        public int IndiceColumna { get; set; }

        #endregion
    }
}