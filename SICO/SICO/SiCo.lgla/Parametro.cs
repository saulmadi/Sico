using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Runtime.Serialization;

namespace SiCo.lgla
{
    [Serializable() ]
    public class Parametro
    {
        #region Declaraciones
        private string _Nombre = string.Empty;
        private object _valor = new object();
        [NonSerialized()]private System.Data.ParameterDirection _TipoParametro = new System.Data.ParameterDirection();
        #endregion

        #region Constructor
        public Parametro()
        {
            this.TipoParametro = System.Data.ParameterDirection.Input;
            this.Valor = null;
            this.Nombre = string.Empty;
        }

        public Parametro(string Nombre)
        {
            this.TipoParametro = System.Data.ParameterDirection.Input;
            this.Valor = null;
            this.Nombre = Nombre ;
        }

        public Parametro(string Nombre, object Valor)
        {                      

            this.Nombre = Nombre;
            this.Valor = Valor;
            this.TipoParametro = System.Data.ParameterDirection.Input; 
        }

        public Parametro(string Nombre, object Valor, System.Data.ParameterDirection  Tipo)
        {

            this.Nombre = Nombre;
            this.Valor = Valor;
            this.TipoParametro = Tipo;
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
            set { _valor = value;}
        }
        
        public System.Data.ParameterDirection  TipoParametro
        {
            get { return _TipoParametro; }
            set { _TipoParametro = value; }
        }
        
        #endregion        
    }
}
