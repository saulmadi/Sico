using System.ComponentModel;
using System.Windows.Forms;
using SiCo.lgla;

namespace SiCo.ctrla.ControlesBasicos
{
    public partial class ListaSucursales : ListaDesplegable
    {
        public ListaSucursales()
        {
            InitializeComponent();
        }

        public ListaSucursales(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public new Sucursales SelectedItem
        {
            get { return (Sucursales) base.SelectedItem; }
            set { base.SelectedItem = value; }
        }

        public void Inicialiazar()
        {
            try
            {
                Entidad = new Sucursales();
                CargarEntidad();
                DisplayMember = "NombreMantenimiento";
                ValueMember = "Id";
                AutoCompleteSource = AutoCompleteSource.ListItems;
                AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            }
            catch
            {
            }
        }
    }
}