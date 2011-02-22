using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

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

        public void Inicialiazar()
        {
            try
            {
                this.Entidad = new SiCo.lgla.Sucursales();
                this.CargarEntidad();
                this.DisplayMember = "NombreMantenimiento";
                this.ValueMember = "Id";
                this.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
                this.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            }
            catch
            { 
            }
        }

        public new SiCo.lgla.Sucursales  SelectedItem
        {
            get
            {
                return (SiCo.lgla.Sucursales)  base.SelectedItem ;
            }
            set 
            {
                base.SelectedItem =value;  
            }
        }
    }
}
