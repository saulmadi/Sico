using System;
using System.Collections.Generic;
using System.Text;

namespace SiCo.lgla
{
    public class TipoIdentidad
    {
        public TipoIdentidad(string valor)
        {
            this.Valor = valor;
            if( valor.ToUpper()=="I")
            {
                this.Descripcion = "Identidad";
            }
            else
            {
                this.Descripcion="Pasaporte";
            }

        }
        public TipoIdentidad()
        { 
        }
        public TipoIdentidad(string Descripcion, string valor)
        {
            this.Descripcion = Descripcion;
            this.Valor = valor;
            
        }

        public string Descripcion
        {
            get;
            set;
        }

        public string Valor
        {
            get;
            set;
        }
    }
}
