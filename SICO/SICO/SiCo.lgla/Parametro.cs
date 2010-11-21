using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace SiCo.lgla
{
    public class Parametro
    {
        #region Constructor

        public Parametro(string Nombre, object Valor)
        {
            MySqlParameter d;

             

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
            get;
            set;
        }

        public object Valor
        {
            get;
            set;
        }

        public System.Data.ParameterDirection  TipoParametro
        {
            get;
            set;
        }
        
        #endregion

        
    }
}
