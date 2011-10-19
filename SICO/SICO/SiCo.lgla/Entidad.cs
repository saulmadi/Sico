using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SiCo.dtla;

namespace SiCo.lgla
{
    [Serializable]
    public abstract class Entidad
    {
        #region Declaraciones

        [NonSerialized] private readonly ConexionMySql _Conexion = new ConexionMySql();
        [NonSerialized] private List<Parametro> _ColeccionParametrosBusqueda = new List<Parametro>();
        [NonSerialized] protected List<Parametro> _ColeccionParametrosMantenimiento = new List<Parametro>();
        [NonSerialized] private MySqlCommand _Comando = new MySqlCommand();
        protected long? _Id = 0;
        [NonSerialized] private DataTable _Tabla = new DataTable();
        [NonSerialized] private Usuario _Usuario;
        private string _tablaEliminar = string.Empty;
        public event ErroresEventHandler Errores;
        public event CambioIdEventHandler CambioId;

        public event CargoTablaEventHandler CargoTabla;

        #endregion

        #region Construtor

        public Entidad()
        {
            try
            {
                _Conexion.Cargar();
                CargoTabla += Entidad_CargoTabla;
                CambioId += Entidad_CambioId;
                ColeccionParametrosBusqueda.Add(new Parametro("id", null));
                ColeccionParametrosMantenimiento.Add(new Parametro("id", null, ParameterDirection.InputOutput));
                ColeccionParametrosMantenimiento.Add(new Parametro("usu", null));
                ColeccionParametrosMantenimiento.Add(new Parametro("fmodif", null));
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }

        #endregion

        #region Propiedades

        /// <summary>
        /// Tabla de la entidad
        /// </summary>
        public DataTable Tabla
        {
            get { return _Tabla; }
        }

        /// <summary>
        /// Comando de Selección
        /// </summary>
        protected string ComandoSelect { get; set; }

        /// <summary>
        /// Comando de Modificación
        /// </summary>
        protected string ComandoMantenimiento { get; set; }

        /// <summary>
        /// Comando de eliminación
        /// </summary>
        protected string ComandoDelete { get; set; }

        protected List<Parametro> ColeccionParametrosBusqueda
        {
            get { return _ColeccionParametrosBusqueda; }
            set { _ColeccionParametrosBusqueda = value; }
        }

        protected List<Parametro> ColeccionParametrosMantenimiento
        {
            get { return _ColeccionParametrosMantenimiento; }
            set { _ColeccionParametrosMantenimiento = value; }
        }

        /// <summary>
        /// Id de la entidad
        /// </summary>
        public long? Id
        {
            get { return _Id; }
            set
            {
                _Id = value;
                if (value > 0)
                    if (CambioId != null)
                        CambioId();
            }
        }

        public int TotalRegistros
        {
            get { return _Tabla.Rows.Count; }
        }

        public DateTime fmodif
        {
            get { return DateTime.Now; }
        }

        public Usuario Usuario
        {
            get
            {
                if (_Usuario == null)
                    _Usuario = new Usuario();
                try
                {
                    _Usuario.Cargar();
                }
                catch
                {
                }
                return _Usuario;
            }
        }

        protected string TablaEliminar
        {
            get { return _tablaEliminar; }
            set { _tablaEliminar = value; }
        }

        #endregion

        #region Metodos

        protected void LlamadoErrores(string Mensaje)
        {
            if (Errores != null)
                Errores(Mensaje);
        }

        /// <summary>
        /// Ejecuta un comando ingresado manualmente
        /// </summary>
        /// <param name="Comando">Comando SQL con el que desea que se llene la Tabla</param>
        protected void LlenadoTabla(string Comando)
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
        protected void LlenadoTabla(string Comando, Parametro[] Parametro)
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

        protected void LlenadoTabla(List<Parametro> ColeccionParametros)
        {
            LlenadoTabla(ComandoSelect, ColeccionParametros);
        }

        protected void LlenadoTabla(string Comando, List<Parametro> ColeccionParametros)
        {
            InicializarComando();
            _Comando.CommandType = CommandType.StoredProcedure;
            _Comando.CommandText = Comando;
            LLenadoParametros(ref ColeccionParametros);
            EjecutarDataSet();
        }

        /// <summary>
        /// Ejecuta el comando de la propiedad con los parametros necesarios
        /// </summary>
        /// <param name="Parametro">Parametros necesarios para la ejecución del comando</param>
        protected void LlenadoTabla(Parametro[] Parametro)
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
        protected void LlenadoTabla()
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
        protected void Mantenimiento(ref List<Parametro> Parametro)
        {
            InicializarComando();
            _Comando.CommandType = CommandType.StoredProcedure;
            _Comando.CommandText = ComandoMantenimiento;
            LLenadoParametros(ref Parametro);

            EjecutarComando();
            LLenadoParmaetrosSalida(ref Parametro);
        }

        /// <summary>
        /// Modifica el registro de la entidad
        /// </summary>
        /// <param name="Parametro">Parametros Necesarios para la modificación</param>
        protected void MantenimientoTransaccion(ref List<Parametro> Parametro)
        {
            InicializarComando();
            _Comando.CommandType = CommandType.StoredProcedure;
            _Comando.CommandText = ComandoMantenimiento;
            LLenadoParametros(ref Parametro);

            EjecutarComando(true);
            LLenadoParmaetrosSalida(ref Parametro);
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
                MySqlTransaction Transaccion = _Comando.Connection.BeginTransaction();
                try
                {
                    _Comando.ExecuteNonQuery();
                    Transaccion.Commit();
                }
                catch (Exception ex)
                {
                    Transaccion.Rollback();

                    throw new ApplicationException("Error en la ejecución de guardado \n" + ex.Message);
                }
                finally
                {
                    _Conexion.CerrarConexion();
                }
            }
            catch (Exception ex)
            {
                if (Errores != null)
                    Errores(ex.Message);
                throw new ApplicationException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Ejecuta el comando que tenga seleccionado
        /// </summary>
        private void EjecutarComando(bool Transccion)
        {
            try
            {
                _Comando.Connection = _Conexion.Conexion;
                _Comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error en la ejecución de guardado \n" + ex.Message);
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

                var _Adapter = new MySqlDataAdapter(_Comando);

                _Conexion.AbrirConexion();
                _Comando.Connection = _Conexion.Conexion.Clone();
                _Adapter.Fill(Tabla);

                _Conexion.CerrarConexion();
                if (TotalRegistros > 0)
                {
                    if (CargoTabla != null)
                        CargoTabla();
                }
            }
            catch (MySqlException  ex)
            {
                if (Errores != null)
                    Errores(ex.Message);
                throw new ApplicationException(
                    "Error en conexión al servidor. se presento el siguinete error: \n" + ex.Message, ex);
            }
        }

        protected object EjecutaFuncion(string comando)
        {
            try
            {
                var o = new object();
                InicializarComando();
                _Comando.CommandType = CommandType.Text;
                _Comando.CommandText = comando;
                _Comando.Connection = _Conexion.Conexion;
                _Conexion.AbrirConexion();
                o = _Comando.ExecuteScalar();
                _Conexion.CerrarConexion();
                return o;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(
                    "Error en la ejecuación de la función " + comando +
                    " \n pongase contacto el administrador del sistema. ", ex);
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
            try
            {
                if (_Tabla.Rows[Fila][Columna] != DBNull.Value)
                    return _Tabla.Rows[Fila][Columna];
                else return null;
            }
            catch
            {
                return null;
            }
        }

        protected object PrimerRegistro(string Columna)
        {
            return Registro(0, Columna);
        }

        private void LLenadoParametros(ref List<Parametro> parametro)
        {
            foreach (Parametro i in parametro)
            {
                _Comando.Parameters.AddWithValue(i.Nombre, i.Valor);
                _Comando.Parameters[i.Nombre].IsNullable = true;
                _Comando.Parameters[i.Nombre].Direction = i.TipoParametro;
                if (i.Valor == null)
                    _Comando.Parameters[i.Nombre].DbType = DbType.Object;
                //_Comando.Parameters[i.Nombre].MySqlDbType = MySqlDbType.String;
            }
        }

        private void LLenadoParmaetrosSalida(ref List<Parametro> parametro)
        {
            foreach (MySqlParameter i in _Comando.Parameters)
            {
                for (int x = 0; x < parametro.Count; x++)
                {
                    if (parametro[x].Nombre == i.ParameterName && i.Direction != ParameterDirection.Input)
                    {
                        parametro[x].Valor = i.Value;
                        if (i.ParameterName == "id")
                            _Id = (long?) i.Value;
                    }
                }
            }
        }

        protected virtual void CargadoPropiedades(int Indice)
        {
            if (TotalRegistros > 0)
                _Id = (int) Registro(Indice, "id");
        }

        public virtual void Buscar()
        {
            NullParametrosBusqueda();
            LlenadoTabla(ComandoSelect, ColeccionParametrosBusqueda);
        }

        public void Buscar(string parametro, string valor)
        {
            NullParametrosBusqueda();
            ValorParametrosBusqueda(parametro, valor);
            LlenadoTabla(ComandoSelect, ColeccionParametrosBusqueda);
        }

        public void Buscar(List<Parametro> ColeccionParametrosBusqueda)
        {
            NullParametrosBusqueda();
            foreach (Parametro p in ColeccionParametrosBusqueda)
            {
                ValorParametrosBusqueda(p.Nombre, p.Valor);
            }
            LlenadoTabla(ComandoSelect, this.ColeccionParametrosBusqueda);
        }

        public virtual object TablaAColeccion()
        {
            return null;
        }

        public virtual void Buscar(long? id)
        {
            NullParametrosBusqueda();
            ValorParametrosBusqueda("id", id.ToString());
            LlenadoTabla(ComandoSelect, ColeccionParametrosBusqueda);
        }

        public virtual void Guardar()
        {
            ValorParametrosMantenimiento("id", Id);
            ValorParametrosMantenimiento("usu", Usuario.Id);
            ValorParametrosMantenimiento("fmodif", fmodif);
            Mantenimiento(ref _ColeccionParametrosMantenimiento);
        }

        public virtual void Guardar(bool transaccion)
        {
            ValorParametrosMantenimiento("id", Id);
            ValorParametrosMantenimiento("usu", Usuario.Id);
            ValorParametrosMantenimiento("fmodif", fmodif);
            MantenimientoTransaccion(ref _ColeccionParametrosMantenimiento);
        }

        protected void ValorParametrosBusqueda(string Nombre, object valor)
        {
            Parametro para = ColeccionParametrosBusqueda.FirstOrDefault(c => c.Nombre.ToLower().Equals(Nombre.ToLower()));
            if (para != null)
            {
                para.Valor = valor;
                return;
            }
            //foreach (Parametro i in this.ColeccionParametrosBusqueda)
            //{
            //    if (i.Nombre.ToLower() == Nombre.ToLower())
            //    {
            //        i.Valor = valor;
            //        return; 
            //    } 
            //}
            throw new ApplicationException("El parámetro no se encuentra en la colección");
        }

        protected void ValorParametrosMantenimiento(string Nombre, object valor)
        {
            Parametro para =
                _ColeccionParametrosMantenimiento.FirstOrDefault(c => c.Nombre.ToLower().Equals(Nombre.ToLower()));
            if (para != null)
            {
                para.Valor = valor;
                return;
            }
            //foreach (Parametro i in this.ColeccionParametrosMantenimiento)
            //{
            //    if (i.Nombre.ToLower() == Nombre.ToLower())
            //    {
            //        i.Valor = valor;
            //        return; 
            //    } 
            //}

            throw new ApplicationException("El parámetro no se encuentra en la colección");
        }

        protected object ValorParametrosMantenimiento(string Nombre)
        {
            Parametro para =
                _ColeccionParametrosMantenimiento.FirstOrDefault(c => c.Nombre.ToLower().Equals(Nombre.ToLower()));
            if (para != null)
                return para.Valor;

            //foreach (Parametro i in this.ColeccionParametrosMantenimiento)
            //{
            //    if (i.Nombre.ToLower() == Nombre.ToLower())
            //    {
            //        return i.Valor;

            //    }
            //}

            throw new ApplicationException("El parámetro no se encuentra en la colección");
        }

        protected void NullParametrosBusqueda()
        {
            foreach (Parametro i in _ColeccionParametrosBusqueda)
            {
                if (i.Nombre != "tabla" && i.Nombre != "campos")
                    i.Valor = null;
            }
        }

        protected void NullParametrosMantenimiento()
        {
            foreach (Parametro i in _ColeccionParametrosMantenimiento)
            {
                i.Valor = null;
            }
        }

        private bool TieneColumna(string ColumnaNombre)
        {
            return
                Tabla.Columns.OfType<DataColumn>().Where(c => c.ColumnName.ToLower().Equals(ColumnaNombre.ToLower())).
                    Count() == 1;
        }

        public T CargarClase<T>(int indice, T obj) where T : Entidad
        {
            try
            {
                Type type = typeof (T);

                PropertyInfo[] campos = type.GetProperties();
                T v = obj;
                if (campos.Count() == 0)
                    return null;
                foreach (PropertyInfo i in campos)
                {
                    try
                    {
                        if (TieneColumna(i.Name.ToLower()))
                        {
                            object d = Registro(indice, i.Name.ToLower());
                            if (d != null)
                            {
                                if (i.Name.ToLower() == "id")

                                    obj._Id = (int) d;
                                else if (i.CanWrite)
                                    i.SetValue(obj, d, null);
                            }
                        }
                    }
                    catch
                    {
                    }
                }
                return v;
            }
            catch
            {
                return null;
            }
        }

        public List<T> CaragarColeccion<T>() where T : Entidad, new()
        {
            var l = new List<T>();
            for (int x = 0; x < TotalRegistros; x++)
            {
                T valor = CargarClase(x, new T());
                if (valor != null) l.Add(valor);
            }
            return l;
        }

        public Boolean Eliminar()
        {
            try
            {
                if (Id > 0)
                {
                    switch (
                        MessageBox.Show("¿Esta seguro de eliminar el registro?", "Confirmación", MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            InicializarComando();
                            _Comando.CommandType = CommandType.Text;
                            _Comando.CommandText = "Delete from " + TablaEliminar + " where id = " + Id.ToString();
                            _Comando.Connection = _Conexion.Conexion;
                            _Conexion.AbrirConexion();
                            _Comando.ExecuteNonQuery();
                            _Conexion.CerrarConexion();
                            MessageBox.Show("Se ha eliminado correcamete el registro", "Información",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return true;
                        default:
                            return false;
                    }
                }
                else
                {
                    throw new ApplicationException("No se puede eliminar el registro porque todavía no esta registrado.");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(
                    "No se puede eliminar el registro, dado que esta siendo utilizada por otra transacción.", ex);
            }
        }

        public void IniciarTransaccion()
        {
            _Conexion.InciarTransaccion();
        }

        public void CommitTransaccion()
        {
            _Conexion.ComitTransaccion();
        }

        public void RollBackTransaccion()
        {
            _Conexion.RollBackTransaccion();
        }

        #endregion

        #region Eventos

        /// <summary>
        /// </summary>
        /// 
        private void _Conexion_Errores(string Mensaje)
        {
            if (Errores != null)
                Errores(Mensaje);
        }

        private void Entidad_CargoTabla()
        {
            if (TotalRegistros > 0)
                CargadoPropiedades(0);
        }

        private void Entidad_CambioId()
        {
            Buscar(Id);
        }

        #endregion
    }
}