using System;

namespace SiCo.lgla
{
    [Serializable]
    public class TipoIdentidad
    {
        public TipoIdentidad(string valor)
        {
            Valor = valor;
            if (valor.ToUpper() == "I")
            {
                Descripcion = "Identidad";
            }
            else if (valor.ToUpper() == "R")
            {
                Descripcion = "Residencia";
            }
            else
            {
                Descripcion = "Sin identificación";
            }
        }

        public TipoIdentidad()
        {
        }

        public TipoIdentidad(string Descripcion, string valor)
        {
            this.Descripcion = Descripcion;
            Valor = valor;
        }

        public string Descripcion { get; set; }

        public string Valor { get; set; }
    }

    public class Tipo
    {
        public Tipo()
        {
        }

        public Tipo(string Descripcion, string valor)
        {
            this.Descripcion = Descripcion;
            Valor = valor;
        }

        public string Descripcion { get; set; }

        public string Valor { get; set; }
    }
}