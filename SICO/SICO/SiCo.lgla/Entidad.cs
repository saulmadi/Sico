using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient; 
using SiCo.dtla;

namespace SiCo.lgla
{
    [Serializable()]abstract  public class Entidad
    {
        #region Declaraciones
        public event ErroresEventHandler Errores;
        public event CambioIdEventHandler CambioId;

        public event CargoTablaEventHandler CargoTabla;
    
        [NonSerialized]private DataTable _Tabla =new DataTable();
        [NonSerialized]private SiCo.dtla.ConexionMySql _Conexion = new ConexionMySql(true);
        [NonSerialized]private MySql.Data.MySqlClient.MySqlCommand _Comando = new MySqlCommand();
        [NonSerialized]private Usuario _Usuario;
        [NonSerialized]private List<Parametro> _ColeccionParametrosBusqueda= new List<Parametro> ();
        [NonSerialized]protected  List<Parametro> _ColeccionParametrosMantenimiento = new List<Parametro>();
        protected int? _Id =0;
        
        #endregion

        #region Construtor
        public Entidad()
        {
            this.ColeccionParametrosBusqueda.Add(new Parametro("id", null));
            this.ColeccionParametrosMantenimiento.Add(new Parametro("id", Id));
            this.ColeccionParametrosMantenimiento.Add(new Parametro("usu", this.Usuario.Id));
            this.ColeccionParametrosMantenimiento.Add(new Parametro("fmodif", this.fmodif));

            _Conexion.Errores += new ErroresEventArgs(_Conexion_Errores);
            this.CargoTabla += new CargoTablaEventHandler(Entidad_CargoTabla);
            this.CambioId += new CambioIdEventHandler(Entidad_CambioId);
             
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
        protected string ComandoSelect
        {
            get;
            set;
        }       

        /// <summary>
        /// Comando de Modificación
        /// </summary>
        protected string ComandoMantenimiento
        {
            get;
            set;
        }

        /// <summary>
        /// Comando de eliminación
        /// </summary>
        protected string ComandoDelete
        {
            get;
            set;
        }

        protected List<Parametro> ColeccionParametrosBusqueda
        {
            get { return _ColeccionParametrosBusqueda; }
            set { _ColeccionParametrosBusqueda = value; }}

        protected List<Parametro> ColeccionParametrosMantenimiento
        {
            get { return _ColeccionParametrosMantenimiento;}
            set { _ColeccionParametrosMantenimiento = value;}        
        }

        /// <summary>
        /// Id de la entidad
        /// </summary>
        public Int32? Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
                if(value>0)
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
        protected  void LlenadoTabla(string Comando)
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
        protected void LlenadoTabla(string Comando, SiCo.lgla.Parametro[] Parametro)
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

        protected void LlenadoTabla(List<SiCo.lgla.Parametro> ColeccionParametros)
        {
            LlenadoTabla(ComandoSelect, ColeccionParametros);

        }

        protected void LlenadoTabla(string Comando, List<SiCo.lgla.Parametro> ColeccionParametros)
        {
            InicializarComando();
            _Comando.CommandType = CommandType.StoredProcedure;
            foreach (Parametro i in ColeccionParametros)  
            {
                _Comando.Parameters.AddWithValue(i.Nombre, i.Valor); 
            }

        } 
        
        /// <summary>
        /// Ejecuta el comando de la propiedad con los parametros necesarios
        /// </summary>
        /// <param name="Parametro">Parametros necesarios para la ejecución del comando</param>
        protected void LlenadoTabla(SiCo.lgla.Parametro[] Parametro)
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
            LLenadoParametros(ref Parametro);           
            _Comando.CommandText = ComandoMantenimiento;
            EjecutarComando();
            LLenadoParametros(ref Parametro);
        }

        /// <summary>
        /// Elimina el registro de la entidad
        /// </summary>
        protected void Eliminar(SiCo.lgla.Parametro[] Parametro)
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
                 MySqlTransaction Transaccion = _Conexion.Conexion.BeginTransaction();   
                try
                {                   
                    _Comando.ExecuteNonQuery();
                    Transaccion.Commit(); 
                }
                catch 
                {
                    Transaccion.Rollback();                   
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
                if (this.TotalRegistros > 0)
                {
                    if (this.CargoTabla != null)
                        this.CargoTabla();
                }
            }
            catch (MySqlException  ex)
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
        protected object Registro(int Fila, String Columna)
        {
            return _Tabla.Rows[Fila][Columna];
        }

        protected object PrimerRegistro(string Columna)
        {
            return Registro(0, Columna); 
        }

        private void LLenadoParametros(ref List<Parametro> parametro)
        {
            foreach (Parametro i in parametro )
            {
                _Comando.Parameters.AddWithValue(i.Nombre, i.Valor);
                _Comando.Parameters[i.Nombre].IsNullable = true;    
                _Comando.Parameters[i.Nombre].Direction = i.TipoParametro ; 
            }
 
        }

        private void LLenadoParmaetrosSalida(ref List<Parametro> parametro) 
        {
            foreach (MySqlParameter i in _Comando.Parameters)
            {
                for (int x = 0; x < parametro.Count ; x++)
                {
                    if (parametro[x].Nombre  == i.ParameterName && i.Direction!=ParameterDirection.Input)
                    {
                        parametro[x].Valor = i.Value;
                        if (i.ParameterName == "id")
                            _Id =(Int32?) i.Value;
                    } 
                } 
            }                       
        }

        protected  virtual void CargadoPropiedades()
        {

            _Id = (int) Registro(0, "id");            
 
        }
       
        public virtual void Buscar()
        {
            this.NullParametrosBusqueda();
            LlenadoTabla(ComandoSelect, this.ColeccionParametrosBusqueda); 
        }

        public virtual  void Buscar(Int32? id)
        {
            NullParametrosBusqueda();
            ValorParametrosBusqueda("id", id.ToString());
            LlenadoTabla(ComandoSelect, this.ColeccionParametrosBusqueda);
        }

        public virtual void Guardar()
        {            
            this.ValorParametrosMantenimiento("id", this.Id);
            this.ValorParametrosMantenimiento("usu", this.Usuario.Id );
            this.ValorParametrosMantenimiento("fmodif", this.fmodif);
            this.Mantenimiento(ref this._ColeccionParametrosMantenimiento);
        }

        protected void ValorParametrosBusqueda(string Nombre, object valor)
        {
            foreach (Parametro i in this.ColeccionParametrosBusqueda)
            {
                if (i.Nombre.ToLower() == Nombre.ToLower())
                {
                    i.Valor = valor;
                    continue; 
                } 
            }
        }

        protected void ValorParametrosMantenimiento(string Nombre, object valor)
        {
            foreach (Parametro i in this.ColeccionParametrosMantenimiento)
            {
                if (i.Nombre.ToLower() == Nombre.ToLower())
                {
                    i.Valor = valor;
                    continue;
                }
            }
        }

        protected void NullParametrosBusqueda()
        {
            foreach (Parametro i in _ColeccionParametrosBusqueda)
            {
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
        

        #endregion             

        #region Eventos

        /// <summary>
        /// </summary>
        /// 
        void _Conexion_Errores(string Mensaje)
        {
            if (Errores != null)
                Errores(Mensaje);
        }

        void Entidad_CargoTabla()
        {
            this.CargadoPropiedades(); 

        }

        void Entidad_CambioId()
        {
            this.Buscar(this.Id);
        }

        #endregion       

    }

    [Serializable()]
     public class EntidadInstanciable
    {
        #region Declaraciones
        public event ErroresEventHandler Errores;
        public event CambioIdEventHandler CambioId;

        public event CargoTablaEventHandler CargoTabla;

        [NonSerialized]
        private DataTable _Tabla = new DataTable();
        [NonSerialized]
        private SiCo.dtla.ConexionMySql _Conexion = new ConexionMySql(true);
        [NonSerialized]
        private MySql.Data.MySqlClient.MySqlCommand _Comando = new MySqlCommand();
        [NonSerialized]
        private Usuario _Usuario;
        [NonSerialized]
        private List<Parametro> _ColeccionParametrosBusqueda = new List<Parametro>();
        [NonSerialized]
        protected List<Parametro> _ColeccionParametrosMantenimiento = new List<Parametro>();
        protected int? _Id = 0;

        #endregion

        #region Construtor
        public EntidadInstanciable()
        {
            this.ColeccionParametrosBusqueda.Add(new Parametro("id", null));
            this.ColeccionParametrosMantenimiento.Add(new Parametro("id", Id));
            this.ColeccionParametrosMantenimiento.Add(new Parametro("usu", this.Usuario.Id));
            this.ColeccionParametrosMantenimiento.Add(new Parametro("fmodif", this.fmodif));

            _Conexion.Errores += new ErroresEventArgs(_Conexion_Errores);
            this.CargoTabla += new CargoTablaEventHandler(Entidad_CargoTabla);
            this.CambioId += new CambioIdEventHandler(Entidad_CambioId);

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

        public List<Parametro> ColeccionParametrosBusqueda
        {
            get { return _ColeccionParametrosBusqueda; }
            set { _ColeccionParametrosBusqueda = value; }
        }

        public List<Parametro> ColeccionParametrosMantenimiento
        {
            get { return _ColeccionParametrosMantenimiento; }
            set { _ColeccionParametrosMantenimiento = value; }
        }

        /// <summary>
        /// Id de la entidad
        /// </summary>
        public Int32? Id
        {
            get
            {
                return _Id;
            }
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
                _Usuario = new Usuario();
                return _Usuario;
            }

        }

        #endregion

        #region Metodos

        public void LlamadoErrores(string Mensaje)
        {
            if (Errores != null)
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

        public void LlenadoTabla(List<SiCo.lgla.Parametro> ColeccionParametros)
        {
            LlenadoTabla(ComandoSelect, ColeccionParametros);

        }

        public void LlenadoTabla(string Comando, List<SiCo.lgla.Parametro> ColeccionParametros)
        {
            InicializarComando();
            _Comando.CommandType = CommandType.StoredProcedure;
            foreach (Parametro i in ColeccionParametros)
            {
                _Comando.Parameters.AddWithValue(i.Nombre, i.Valor);
            }

        }

        /// <summary>
        /// Ejecuta el comando de la propiedad con los parametros necesarios
        /// </summary>
        /// <param name="Parametro">Parametros necesarios para la ejecución del comando</param>
        public void LlenadoTabla(SiCo.lgla.Parametro[] Parametro)
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
        public void Mantenimiento(ref List<Parametro> Parametro)
        {
            InicializarComando();
            _Comando.CommandType = CommandType.StoredProcedure;
            LLenadoParametros(ref Parametro);
            _Comando.CommandText = ComandoMantenimiento;
            EjecutarComando();
            LLenadoParametros(ref Parametro);
        }

        /// <summary>
        /// Elimina el registro de la entidad
        /// </summary>
        protected void Eliminar(SiCo.lgla.Parametro[] Parametro)
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
                MySqlTransaction Transaccion = _Conexion.Conexion.BeginTransaction();
                try
                {
                    _Comando.ExecuteNonQuery();
                    Transaccion.Commit();
                }
                catch
                {
                    Transaccion.Rollback();
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
        /// Ejecuta el comando SELECT para llenar la tabla
        /// </summary>
        private void EjecutarDataSet()
        {
            try
            {
                _Tabla = new DataTable();
                _Comando.Connection = _Conexion.Conexion;
                MySqlDataAdapter _Adapter = new MySqlDataAdapter(_Comando);
                _Conexion.AbrirConexion();
                _Adapter.Fill(Tabla);
                _Conexion.CerrarConexion();
                if (this.TotalRegistros > 0)
                {
                    if (this.CargoTabla != null)
                        this.CargoTabla();
                }
            }
            catch (MySqlException ex)
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

        private void LLenadoParametros(ref List<Parametro> parametro)
        {
            foreach (Parametro i in parametro)
            {
                _Comando.Parameters.AddWithValue(i.Nombre, i.Valor);
                _Comando.Parameters[i.Nombre].IsNullable = true;
                _Comando.Parameters[i.Nombre].Direction = i.TipoParametro;
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
                            _Id = (Int32?)i.Value;
                    }
                }
            }
        }

        public virtual void CargadoPropiedades()
        {

            _Id = (int)Registro(0, "id");

        }

        public virtual void Buscar()
        {
            this.NullParametrosBusqueda();
            LlenadoTabla(ComandoSelect, this.ColeccionParametrosBusqueda);
        }

        public virtual void Buscar(Int32? id)
        {
            NullParametrosBusqueda();
            ValorParametrosBusqueda("id", id.ToString());
            LlenadoTabla(ComandoSelect, this.ColeccionParametrosBusqueda);
        }

        public virtual void Guardar()
        {
            this.ValorParametrosMantenimiento("id", this.Id);
            this.ValorParametrosMantenimiento("usu", this.Usuario.Id);
            this.ValorParametrosMantenimiento("fmodif", this.fmodif);
            this.Mantenimiento(ref this._ColeccionParametrosMantenimiento);
        }

        public void ValorParametrosBusqueda(string Nombre, object valor)
        {
            foreach (Parametro i in this.ColeccionParametrosBusqueda)
            {
                if (i.Nombre.ToLower() == Nombre.ToLower())
                {
                    i.Valor = valor;
                    continue;
                }
            }
        }

        public void ValorParametrosMantenimiento(string Nombre, object valor)
        {
            foreach (Parametro i in this.ColeccionParametrosMantenimiento)
            {
                if (i.Nombre.ToLower() == Nombre.ToLower())
                {
                    i.Valor = valor;
                    continue;
                }
            }
        }

        public void NullParametrosBusqueda()
        {
            foreach (Parametro i in _ColeccionParametrosBusqueda)
            {
                i.Valor = null;
            }
        }

        public void NullParametrosMantenimiento()
        {
            foreach (Parametro i in _ColeccionParametrosMantenimiento)
            {
                i.Valor = null;
            }
        }


        #endregion

        #region Eventos

        /// <summary>
        /// </summary>
        /// 
        void _Conexion_Errores(string Mensaje)
        {
            if (Errores != null)
                Errores(Mensaje);
        }

        void Entidad_CargoTabla()
        {
            this.CargadoPropiedades();

        }

        void Entidad_CambioId()
        {
            this.Buscar(this.Id);
        }

        #endregion

    }
}