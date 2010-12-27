using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SiCo.ctrla.ControlesPersonalizados
{
    public partial class crtPanelBase : UserControl
    {
        public crtPanelBase()
        {
            InitializeComponent();
        }

        public string Titulo
        {
            get { return lblTitulo.Text; }
            set { lblTitulo.Text = value; }
        }
    }
}
