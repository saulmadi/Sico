using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using SiCo.dtla;


namespace SiCo.lgla
{
    [Serializable()]
    public class Usuario : Entidad
    {
        private string _Usuario=string.Empty ;
        public Usuario() :base()
        {
            //Texto temporal solo para el ingreso del control de persona natural y de entidad
            base.Id = 1;
        
        }

        public string usuario
        {
            get
            {
                return _Usuario;
            }
            set
            {
                _Usuario=value;
            }
        }
    }
}
