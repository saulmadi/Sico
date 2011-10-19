using System;
using System.Data;

namespace SiCo.lgla
{
    [Serializable]
    public class Parametro
    {
        #region Declaraciones

        private string _Nombre = string.Empty;
        [NonSerialized] private ParameterDirection _TipoParametro;
        private object _valor = new object();

        #endregion

        #region Constructor

        public Parametro()
        {
            TipoParametro = ParameterDirection.Input;
            Valor = null;
            Nombre = string.Empty;
        }

        public Parametro(string Nombre)
        {
            TipoParametro = ParameterDirection.Input;
            Valor = null;
            this.Nombre = Nombre;
        }

        public Parametro(string Nombre, object Valor)
        {
            this.Nombre = Nombre;
            this.Valor = Valor;
            TipoParametro = ParameterDirection.Input;
        }

        public Parametro(string Nombre, object Valor, ParameterDirection Tipo)
        {
            this.Nombre = Nombre;
            this.Valor = Valor;
            TipoParametro = Tipo;
        }

        #endregion

        #region Propiedes

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public object Valor
        {
            get { return _valor; }
            set { _valor = value; }
        }

        public ParameterDirection TipoParametro
        {
            get { return _TipoParametro; }
            set { _TipoParametro = value; }
        }

        #endregion
    }
}