using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime;

namespace SiCo.dtla
{
    [Serializable]
    public  class ConexionMySql 
    { 
        #region Declaraciones
            [NonSerialized]private Serializador  _Serializador = new Serializador();
            [NonSerialized]private MySqlConnection _Conexion = new MySqlConnection();
            [NonSerialized]private ConexionMySql _Instancia;

            public event ErroresEventArgs Errores;
        #endregion                 

        #region Construtor

            /// <summary>
            /// Constructor de la conexión
            /// </summary>
            /// <param name="Cargar">Indica se van a cargar los datos del archivo de configuración</param>
         public ConexionMySql(bool Cargar)
        {           
            _Instancia = this; 
            if (Cargar)
                this.Cargar();
            _Serializador.Errores += new ErroresEventArgs(_Serializador_Errores);
 
        }               

        #endregion

        #region Propiedades

         /// <summary>
         /// Dirección del servidor en la red
         /// </summary>
        public string Servidor
        {
            get;
            set;
        }

        /// <summary>
        /// Puerto por el que corre el servidor de base de datos
        /// </summary>
        public int Puerto
        {
            get;
            set;

        }

        /// <summary>
        /// Usuario de autetificacón en el servidor de base de datos
        /// </summary>
        public string Usuario
        {
            get;
            set;
        }

        /// <summary>
        /// Contraseña de acceso del usuario de base de datos
        /// </summary>
        public string Contrasena
        {
            get;
            set;
        }

        /// <summary>
        /// Base de Datos selecionada segun el archivo de conexión
        /// </summary>
        public string BaseDatos
        {
            get;
            set;
        }

        /// <summary>
        /// Devuelve la cadena de conexion
        /// </summary>
        public string CadenaConexion
        {
            get
            {
                return "Server=" + Servidor + ";Port=" + Puerto.ToString() + "; database=" + BaseDatos + ";Uid=" + Usuario + ";Pwd=" + Contrasena + ";";
            }
        }

        /// <summary>
        /// Dirección raíz del archivo de conexión
        /// </summary>
        public string Archivo
        {
            get
            {
                return System.AppDomain.CurrentDomain.BaseDirectory + "Cnx.sco";
            }
        }

        /// <summary>
        /// Objeto de conexión al servidor
        /// </summary>
       public MySql.Data.MySqlClient.MySqlConnection Conexion
        {
            get
            {
                return _Conexion;
            }
        }

        #endregion      
        
        #region Eventos

        void _Serializador_Errores(string Mensaje)
        {
            Errores (Mensaje); 
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Abre la conexión con el servidor
        /// </summary>
        public bool AbrirConexion()
        {
            bool flag =false;
            try
            {
                if (this.Conexion.State == System.Data.ConnectionState.Closed)
                {
                    this.Conexion.ConnectionString = CadenaConexion;
                    this.Conexion.Open();                                        
                }
                if (this.Conexion.State==System.Data.ConnectionState.Open)
                {
                    flag = true;
                }
            }
            catch( Exception ex)
            {
                if (Errores != null)
                Errores (ex.Message);

                throw new ApplicationException("Error en la conexión con el servidor, revise la configuración de conexión. " +
                     "\n Contacte al administador de Sistema  " , ex);  
            }
            return flag;  

        }

        /// <summary>
        /// Cierrra la Conexión  con el servidor
        /// </summary>
        public bool CerrarConexion()
        {
            bool flag = false;
            try
            {
                if (this.Conexion.State == System.Data.ConnectionState.Open)
                {                    
                    this.Conexion.Close();
                }
                if (this.Conexion.State == System.Data.ConnectionState.Closed )
                {
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                if (Errores != null)
                Errores (ex.Message);

                throw new ApplicationException("Error en la conexión con el servidor, revise la configuración de conexión. " +
                     "\n Contacte al administador de Sistema  ", ex);  
            }
            return flag;
        }

        /// <summary>
        /// Guarda los datos del objeto de conexión
        /// </summary>
        public void Guardar()
        {
            _Serializador.Directorio = Archivo;
            _Serializador.Objeto = _Instancia;
            _Serializador.Guardar(); 
        }

        /// <summary>
        /// Carga los datos de la conexión del archivo de configuración
        /// </summary>
        public void Cargar()
        {
            
            _Instancia = this;           
            
            _Serializador.Objeto = _Instancia ;
            _Serializador.Directorio = Archivo;
           _Instancia=(ConexionMySql) _Serializador.Cargar();
           this.BaseDatos = _Instancia.BaseDatos;
           this.Servidor = _Instancia.Servidor;
           this.Usuario = _Instancia.Usuario;
           this.Contrasena = _Instancia.Contrasena;
           this.Puerto = _Instancia.Puerto;
           
        }

        /// <summary>
        /// Prueba si existe conectividad con el servidor, segun los datos ingresados.
        /// </summary>
        /// <returns>Devuelve True si es sactifactoria la conexión y False si no</returns>
        public bool ProbarConexion()
        {
            bool flag = AbrirConexion();             
            CerrarConexion();
            return flag;
             
        }

        #endregion        
    }
}
