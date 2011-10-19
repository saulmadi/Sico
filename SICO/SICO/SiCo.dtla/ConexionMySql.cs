﻿using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace SiCo.dtla
{
    [Serializable]
    public class ConexionMySql
    {
        #region Declaraciones

        [NonSerialized] private static MySqlConnection _Conexion = new MySqlConnection();
        [NonSerialized] private readonly Serializador _Serializador = new Serializador();
        [NonSerialized] private ClavesRegistro _ClavesRegistro = new ClavesRegistro();
        [NonSerialized] private ConexionMySql _Instancia;
        [NonSerialized] private MySqlTransaction _Transaccion;

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
        }

        public ConexionMySql()
        {
            _Instancia = this;
        }

        #endregion

        #region Propiedades

        /// <summary>
        /// Dirección del servidor en la red
        /// </summary>
        public string Servidor { get; set; }

        /// <summary>
        /// Puerto por el que corre el servidor de base de datos
        /// </summary>
        public int Puerto { get; set; }

        /// <summary>
        /// Usuario de autetificacón en el servidor de base de datos
        /// </summary>
        public string Usuario { get; set; }

        /// <summary>
        /// Contraseña de acceso del usuario de base de datos
        /// </summary>
        public string Contrasena { get; set; }

        /// <summary>
        /// Base de Datos selecionada segun el archivo de conexión
        /// </summary>
        public string BaseDatos { get; set; }

        /// <summary>
        /// Devuelve la cadena de conexion
        /// </summary>
        public string CadenaConexion
        {
            get
            {
                return "Server=" + Servidor + ";Port=" + Puerto.ToString() + "; database=" + BaseDatos + ";Uid=" +
                       Usuario + ";Pwd=" + Contrasena + ";";
            }
        }

        /// <summary>
        /// Dirección raíz del archivo de conexión
        /// </summary>
        public string Archivo
        {
            get { return AppDomain.CurrentDomain.BaseDirectory + "Cnx.sco"; }
        }

        /// <summary>
        /// Objeto de conexión al servidor
        /// </summary>
        public MySqlConnection Conexion
        {
            get { return _Conexion; }
        }

        #endregion

        #region Eventos

        private void _Serializador_Errores(string Mensaje)
        {
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Abre la conexión con el servidor
        /// </summary>
        public bool AbrirConexion()
        {
            bool flag = false;
            try
            {
                if (Conexion.State != ConnectionState.Open)
                {
                    _Conexion = new MySqlConnection(CadenaConexion);
                    Conexion.ConnectionString = CadenaConexion;
                    Conexion.Open();
                }

                if (Conexion.State == ConnectionState.Open)
                {
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(
                    "Error en la conexión con el servidor, revise la configuración de conexión. " +
                    "\n        Contacte al administador de Sistema o intente más tarde.  " + ex.Message, ex);
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
                if (Conexion.State != ConnectionState.Closed)
                {
                    //this.Conexion.Close(); 
                }
                if (Conexion.State == ConnectionState.Closed)
                {
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(
                    "Error en la conexión con el servidor, revise la configuración de conexión. " +
                    "\n       Contacte al administador de Sistema  ", ex);
            }
            return flag;
        }

        public bool CerrarConexionVerdadero()
        {
            bool flag = false;
            try
            {
                if (Conexion.State != ConnectionState.Closed)
                {
                    Conexion.Close();
                }
                if (Conexion.State == ConnectionState.Closed)
                {
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(
                    "Error en la conexión con el servidor, revise la configuración de conexión. " +
                    "\n       Contacte al administador de Sistema  ", ex);
            }
            return flag;
        }

        /// <summary>
        /// Guarda los datos del objeto de conexión
        /// </summary>
        public void Guardar()
        {
            try
            {
                _Serializador.Directorio = Archivo;
                _Serializador.Objeto = _Instancia;
                _Serializador.Guardar();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Carga los datos de la conexión del archivo de configuración
        /// </summary>
        public void Cargar()
        {
            try
            {
                _Instancia = this;

                _Serializador.Objeto = _Instancia;
                _Serializador.Directorio = Archivo;
                _Instancia = (ConexionMySql) _Serializador.Cargar();
                BaseDatos = _Instancia.BaseDatos;
                Servidor = _Instancia.Servidor;
                Usuario = _Instancia.Usuario;
                Contrasena = _Instancia.Contrasena;
                Puerto = _Instancia.Puerto;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
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

        public bool InciarTransaccion()
        {
            try
            {
                CerrarConexionVerdadero();
                AbrirConexion();
                _Transaccion = null;
                _Transaccion = _Conexion.BeginTransaction();


                if (_Transaccion == null)
                {
                    _Transaccion = null;
                    AbrirConexion();
                    _Transaccion = _Conexion.BeginTransaction();
                    if (_Transaccion != null)
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }


                throw new ApplicationException(
                    "Error en la conexión con el servidor, revise la configuración de conexión. " +
                    "\n        Contacte al administador de Sistema o intente más tarde.");
            }
            catch (Exception ex)
            {
                throw new ApplicationException(
                    "Error en la conexión con el servidor, revise la configuración de conexión. " +
                    "\n        Contacte al administador de Sistema o intente más tarde.  " + ex.Message, ex);
            }
        }

        public bool ComitTransaccion()
        {
            try
            {
                if (_Transaccion != null)
                {
                    _Transaccion.Commit();
                    CerrarConexion();
                    return true;
                }

                throw new ApplicationException(
                    "Error en la conexión con el servidor, revise la configuración de conexión. " +
                    "\n        Contacte al administador de Sistema o intente más tarde.  ");
            }
            catch (Exception ex)
            {
                throw new ApplicationException(
                    "Error en la conexión con el servidor, revise la configuración de conexión. " +
                    "\n        Contacte al administador de Sistema o intente más tarde.  " + ex.Message, ex);
            }
        }

        public bool RollBackTransaccion()
        {
            try
            {
                if (_Transaccion != null)
                {
                    _Transaccion.Rollback();
                    CerrarConexion();
                    return true;
                }

                throw new ApplicationException(
                    "Error en la conexión con el servidor, revise la configuración de conexión. " +
                    "\n        Contacte al administador de Sistema o intente más tarde.  ");
            }
            catch (Exception ex)
            {
                throw new ApplicationException(
                    "Error en la conexión con el servidor, revise la configuración de conexión. " +
                    "\n        Contacte al administador de Sistema o intente más tarde.  " + ex.Message, ex);
            }
        }

        #endregion
    }
}