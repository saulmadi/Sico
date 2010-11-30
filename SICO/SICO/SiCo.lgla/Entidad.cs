using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient; 
using SiCo.dtla;

namespace SiCo.lgla
{
    [Serializable()]public class Entidad
    {
        #region Declaraciones
        public event ErroresEventsArgs Errores;
        public event CambioIdEventArgs CambioId;
        [NonSerialized]private DataTable _Tabla =new DataTable();
        [NonSerialized]private SiCo.dtla.ConexionMySql _Conexion = new ConexionMySql(true);
        [NonSerialized]private MySql.Data.MySqlClient.MySqlCommand _Comando = new MySqlCommand();
        [NonSerialized]private Usuario _Usuario;
        protected int? _Id ;
        
        #endregion

        #region Construtor
        public Entidad()
        {
            _Conexion.Errores += new ErroresEventArgs(_Conexion_Errores);
            _Id = null;         
            
        }

        #endregion

        #region Eventos

        /// <summary>
        /// </summary>
        void _Conexion_Errores(string Mensaje)
        {
            if (Errores != null)
            Errores(Mensaje); 
        }

        #endregion

        #region Propiedades

        /// <summary>
        /// Tabla de la entidad
        /// </summary>
        public System.Data.DataTable Tabla
        {
            get
            {
                return _Tabla;
            }            
        }

        /// <summary>
        /// Comando de Selección
        /// </summary>
        public string ComandoSelect
        {
            get;
            set;
        }       

        /// <summary>
        /// Comando de Modificación
        /// </summary>
        public string ComandoMantenimiento
        {
            get;
            set;
        }

        /// <summary>
        /// Comando de eliminación
        /// </summary>
        public string ComandoDelete
        {
            get;
            set;
        }

        /// <summary>
        /// Id de la entidad
        /// </summary>
        public int? Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
                if(CambioId!=null)
                CambioId();
            }
        }

        public int TotalRegistros
        {
            get
            {
                return _Tabla.Rows.Count;
            }
        }

        public DateTime fmodif
        {
            get
            {
                return DateTime.Now;
            }
        }

        public Usuario Usuario
        {
            get 
            {
                _Usuario= new Usuario(); 
                return _Usuario;
            }
            
        }

        #endregion

        #region Metodos

        protected void LlamadoErrores(string Mensaje)
        {
            if(Errores !=null)
            Errores(Mensaje);                   
        }

        /// <summary>
        /// Ejecuta un comando ingresado manualmente
        /// </summary>
        /// <param name="Comando">Comando SQL con el que desea que se llene la Tabla</param>
        public void LlenadoTabla(string Comando)
        {
            InicializarComando();
            _Comando.CommandType = CommandType.Text;
            _Comando.CommandText = Comando;
            EjecutarDataSet(); 
 
        }

        /// <summary>
        /// Ejecuta el comando que se ingresa con los parametros necesarios
        /// </summary>
        /// <param name="Comando">Comando a ejecutar</param>
        /// <param name="Parametro">Parametros necesarios para la ejecución del comando</param>
        public void LlenadoTabla(string Comando, SiCo.lgla.Parametro[] Parametro)
        {
            InicializarComando();
            _Comando.CommandType = CommandType.StoredProcedure;
            foreach (Parametro i in Parametro)
            {
                _Comando.Parameters.AddWithValue(i.Nombre, i.Valor);    
            }
            _Comando.CommandText = Comando;
            EjecutarDataSet();
        }

        //public void LlenadoTabla(object[] Personalizado)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public void LlenadoTabla(object[][] Personalizado)
        //{
        //    throw new System.NotImplementedException();
        //}

        /// <summary>
        /// Ejecuta el comando de la propiedad con los parametros necesarios
        /// </summary>
        /// <param name="Parametro">Parametros necesarios para la ejecución del comando</param>
        public void LlenadoTabla(Parametro[] Parametro)
        {
            InicializarComando();
            _Comando.CommandType = CommandType.StoredProcedure;
            foreach (Parametro i in Parametro)
            {
                _Comando.Parameters.AddWithValue(i.Nombre, i.Valor);
            }
            _Comando.CommandText = ComandoSelect;
            EjecutarDataSet();
        }

        /// <summary>
        /// Ejecuta el comando ingresado en la propiedad ComandoSelect
        /// </summary>
        public void LlenadoTabla()
        {
            InicializarComando();            
            _Comando.CommandType = CommandType.StoredProcedure;
            _Comando.CommandText = ComandoSelect;
            EjecutarDataSet(); 
        }
       
        /// <summary>
        /// Modifica el registro de la entidad
        /// </summary>
        /// <param name="Parametro">Parametros Necesarios para la modificación</param>
        protected void Mantenimiento(ref Parametro[] Parametro)
        {
            InicializarComando();
            _Comando.CommandType = CommandType.StoredProcedure;
            LLenadoParametros(ref Parametro);           
            _Comando.CommandText = ComandoMantenimiento;
            EjecutarComando();
        }

        /// <summary>
        /// Elimina el registro de la entidad
        /// </summary>
        protected void Eliminar(Parametro[] Parametro)
        {
            InicializarComando();
            _Comando.CommandType = CommandType.StoredProcedure;
            foreach (Parametro i in Parametro)
            {
                _Comando.Parameters.AddWithValue(i.Nombre, i.Valor);
            }
            _Comando.CommandText = ComandoDelete;
            EjecutarComando();
        }

        /// <summary>
        /// Ejecuta el comando que tenga seleccionado
        /// </summary>
        private void EjecutarComando()
        {
            try
            {
               
                _Comando.Connection = _Conexion.Conexion;
                _Conexion.AbrirConexion();                
                _Conexion.CerrarConexion();  

            }
            catch (Exception ex)
            {
                if (Errores != null)
               Errores(ex.Message);
                throw new ApplicationException(ex.Message, ex); 
            }
 
        }

        /// <summary>
        /// Ejecuta el comando SELECT para llenar la tabla
        /// </summary>
        private void EjecutarDataSet()
        {
            try
            {
                _Tabla = new DataTable(); 
                _Comando.Connection=_Conexion.Conexion;
                MySqlDataAdapter _Adapter = new MySqlDataAdapter(_Comando);
                _Conexion.AbrirConexion(); 
                _Adapter.Fill(Tabla);
                _Conexion.CerrarConexion();  
            }
            catch (Exception ex)
            {
                if (Errores != null)
                Errores(ex.Message);
                throw new ApplicationException(ex.Message, ex); 
            }
             
        }

        private void InicializarComando()
        {
            _Comando = new MySqlCommand();  
        }

        /// <summary>
        /// Devuelve el registro de la tabla segun los parametros
        /// </summary>
        /// <param name="Fila">Número de fila en el que se encuentra el registro</param>
        /// <param name="Columna">Nombre de la columna en el que se encuentra el registro</param>
        public object Registro(int Fila, String Columna)
        {
            return _Tabla.Rows[Fila][Columna];
        }
        public object PrimerRegistro(string Columna)
        {
            return Registro(0, Columna); 
        }

        private void LLenadoParametros(ref Parametro[] Parametros)
        {
            foreach (Parametro i in Parametros)
            {
                _Comando.Parameters.AddWithValue(i.Nombre, i.Valor);
                _Comando.Parameters[i.Nombre].Direction = i.TipoParametro; 
            }
 
        }

        private void  LLenadoParmaetrosSalida(ref Parametro[] Parametro) 
        {
            foreach (MySqlParameter i in _Comando.Parameters)
            {
                for (int x = 0; x < Parametro.GetUpperBound(0); x++)
                {
                    if (Parametro[x].Nombre == i.ParameterName)
                    {
                        Parametro[x].Valor = i.Value; 
                    } 
                } 
            }                       
        }

        protected  virtual void CargadoValores()
        {
            _Id = (int) Registro(0, "id");            
 
        }


       

        #endregion             

    }
}