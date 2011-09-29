using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;  
namespace SiCo.ctrla.ControlesBasicos
{
    public class Mensaje
    {
        
        public static DialogResult  MensajeError(string Msj)
        {
            return MessageBox.Show(Msj, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static DialogResult SioNo(string Msj)
        {
            return MessageBox.Show(Msj, "Advertencia", MessageBoxButtons.YesNo , MessageBoxIcon.Question);
        }
        public static DialogResult Informacion(string Msj)
        {
            return MessageBox.Show(Msj, "Información",MessageBoxButtons.OK , MessageBoxIcon.Information );
        }
    }
}
