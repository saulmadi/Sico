using System;
using System.Collections.Generic;
using System.Text;

namespace SiCo.lgla
{
    [Serializable()]
    public class TipoIdentidad
    {
        public TipoIdentidad(string valor)
        {
            this.Valor = valor;
            if( valor.ToUpper()=="I")
            {
                this.Descripcion = "Identidad";
            }
            else if (valor.ToUpper() == "R")
            {
                this.Descripcion = "Residencia";
            }
            else
            {
                this.Descripcion = "Sin identificación";
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

    public class Tipo
    {
        
        public Tipo()
        {
        }
        public Tipo(string Descripcion, string valor)
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
