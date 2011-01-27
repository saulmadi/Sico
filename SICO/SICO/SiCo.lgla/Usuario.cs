using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using SiCo.dtla;


namespace SiCo.lgla
{
    
    public class Usuario : Mantenimientos
    {
        #region Declaraciones
        private string _contrasena = string.Empty; 
        #endregion

        #region Constructor
        public Usuario(): base()
        {
            //Texto temporal solo para el ingreso del control de persona natural y de entidad
            
            this.ColeccionParametrosMantenimiento.Add(new Parametro("usuario",null));
            this.ColeccionParametrosMantenimiento.Add(new Parametro("contrasena",null));
            this.ColeccionParametrosMantenimiento.Add(new Parametro("idsucursales",null));
            this.ColeccionParametrosMantenimiento.Add(new Parametro("idrol", null)); 
            this.TablaBusqueda = "usuarios";
            this.ColeccionParametrosBusqueda.Add(new Parametro(  "tabla", this.TablaBusqueda));
            this.ComandoMantenimiento = "Usuarios_Mant";


        
        }
        public Usuario(long? id, long? idEntidades,int estado,string usuario,string contrasena,long? sucursal): base(id,idEntidades,estado)
        {
            //Texto temporal solo para el ingreso del control de persona natural y de entidad
            
            this.ColeccionParametrosMantenimiento.Add(new Parametro("usuario", null));
            this.ColeccionParametrosMantenimiento.Add(new Parametro("contrasena", null));
            this.ColeccionParametrosMantenimiento.Add(new Parametro("idsucursales", null));
            this.ColeccionParametrosMantenimiento.Add(new Parametro("idrol", null)); 
            this.TablaBusqueda = "usuarios";
            this.ColeccionParametrosBusqueda.Add(new Parametro("tabla", this.TablaBusqueda));
            this.ComandoMantenimiento = "Usuarios_Mant";
            this.usuario = usuario;
            this.contrasena = contrasena;
            this.sucursal = sucursal;


        }
        #endregion
        
        #region Propiedades

        public string usuario
        {
            get;
            set;
        }

        public string contrasena
        {
            get { return _contrasena; }
            set { _contrasena = value; }
        }

        public long? sucursal
        {
            get;
            set;

        }

        public int rol
        {
            get;
            set;
        }

        public string Archivo 
        {
           
            get
            {
                SiCo.dtla.ClavesRegistro c = new ClavesRegistro();
                return c.Instalacion + "Usx.sco";
            } 
        }

        #endregion

        #region Metodos

        protected override void CargadoPropiedades(int Indice)
        {
             this.rol =Convert.ToInt32(   this.Registro(Indice, "idrol"));  
            this.usuario =(string) this.Registro(Indice, "usuario");
            this.contrasena =(string) this.Registro(Indice, "contrasena");
            this.sucursal = (long?)this.Registro(Indice, "idsucursales"); 
            base.CargadoPropiedades(Indice);
        }

        public override void Guardar()
        {
            NullParametrosMantenimiento();
            ValorParametrosMantenimiento("usuario",this.usuario);
            ValorParametrosMantenimiento("contrasena",this.contrasena);
            ValorParametrosMantenimiento("idrol", this.rol); 
            ValorParametrosMantenimiento("idsucursales",this.sucursal);              
            base.Guardar();
        }

        public void  Cargar()
        {
            try
            {
                Serializador s = new Serializador();
                UsuarioSerializable usu = new UsuarioSerializable(0, string.Empty);
                s.Objeto = usu;
                s.Directorio = this.Archivo;
                s.Cargar();
                this._Id = usu.id;
                this.usuario = usu.usuario;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al cargar el usuario favor volver a iniciar sesión", ex); 
            }           

        }

        public void Serializar()
        {
            try
            {
                Serializador s = new Serializador();
                UsuarioSerializable usu = new UsuarioSerializable(this.Id , this.usuario);
                s.Objeto = usu;
                s.Directorio = this.Archivo;
                s.Guardar();
                
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al guardar el usuario favor volver a iniciar sesión", ex);
            }
        }

        public bool Autenticar(string usuario, string contrasena)
        {
            NullParametrosBusqueda();
            ValorParametrosBusqueda("usuario", usuario);
            ValorParametrosBusqueda("contrasena", contrasena);
            LlenadoTabla(ColeccionParametrosBusqueda);
            if (this.TotalRegistros == 1)
                return true;

            return false;         
        }

        public string CrearUsuario(string nombreUsuario)
        {
            try
            {
                
                return (string)this.EjecutaFuncion("select CrearUsuario('"+nombreUsuario+"')");
            }
            catch (Exception ex)
            {
                throw new ApplicationException  (ex.Message); 
            }            
        }

        public override object TablaAColeccion()
        {
            List<Usuario> Lista = new List<Usuario>();
            if (this.TotalRegistros > 0)
            {
                for (int x = 0; x < this.TotalRegistros ; x++)
                {
                    this.CargadoPropiedades(x);
                    SiCo.lgla.Usuario tempUsu = new Usuario(this.Id , this.idEntidades, this.Estado, this.usuario, this.contrasena, this.sucursal);
                    tempUsu.PersonaJuridica = this.PersonaJuridica;
                    tempUsu.PersonaNatural = this.PersonaNatural;                       
 
                    Lista.Add(tempUsu);
                }

                this.CargadoPropiedades(0);
            }            

            return Lista ;
        }

        #endregion

        #region Eventos
        #endregion

        #region ClaseSerializable
        [Serializable()]
        public class UsuarioSerializable
        {
            public long? id;
            public string usuario;

            public UsuarioSerializable(long? id, string usuario)
            {
                this.id = id;
                this.usuario = usuario;
            }

        }
        #endregion        

    }
}
