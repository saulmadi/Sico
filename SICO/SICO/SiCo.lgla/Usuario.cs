using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using SiCo.dtla;
using SiCo.sgla; 

namespace SiCo.lgla
{
    
    public class Usuario : Mantenimientos
    {
        #region Declaraciones
        private string _contrasena = string.Empty;
        private int  _rol =1 ;
        public  string NombreUsuario;
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
            this.TablaEliminar = "usuarios";

        
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
            this.TablaEliminar = "usuarios";

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

        public int  rol
        {
            get { return _rol; }
            set { _rol = value; }
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
            this.contrasena = SiCo.sgla.Cripto.DesEncriptar((string)this.Registro(Indice, "contrasena"));
            this.sucursal = Convert.ToInt64(  this.Registro(Indice, "idsucursales")); 
            base.CargadoPropiedades(Indice);
        }

        public override void Guardar()
        {
            NullParametrosMantenimiento();
            ValorParametrosMantenimiento("usuario",this.usuario);
            ValorParametrosMantenimiento("contrasena",SiCo.sgla.Cripto.Encriptar (this.contrasena));
            ValorParametrosMantenimiento("idrol", this.rol); 
            ValorParametrosMantenimiento("idsucursales",this.sucursal);              
            base.Guardar();
        }

        public void  Cargar()
        {
            try
            {
                Serializador s = new Serializador();
                UsuarioSerializable usu = new UsuarioSerializable(0, string.Empty,0,"");
                s.Objeto = usu;
                s.Directorio = this.Archivo;
                s.Cargar();
                usu =(UsuarioSerializable) s.Objeto;
                this._Id = usu.id;
                this.usuario = usu.usuario;
                this.rol = usu.rol;
                this.NombreUsuario = usu.Nombre; 
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
                UsuarioSerializable usu = new UsuarioSerializable(this.Id , this.usuario,this.rol,this.NombreMantenimiento  );
                s.Objeto = usu;
                s.Directorio = this.Archivo;
                s.Guardar();
                
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al guardar el usuario favor volver a iniciar sesión", ex);
            }
        }

        public bool Autenticar(string usuario, string contrasena,Parametro p )
        {
            NullParametrosBusqueda();
            ValorParametrosBusqueda("usuario", usuario);            
            ValorParametrosBusqueda("estado", "1");
           ValorParametrosBusqueda(p.Nombre, p.Valor); 

            LlenadoTabla(ColeccionParametrosBusqueda);
            if (this.contrasena == contrasena)
                return true ;

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
                    tempUsu.rol  = this.rol;
                    tempUsu.PersonaJuridica = this.PersonaJuridica;
                    tempUsu.PersonaNatural = this.PersonaNatural;                       
 
                    Lista.Add(tempUsu);
                }

                this.CargadoPropiedades(0);
            }            

            return Lista ;
        }

        public void Buscar(int idRol, Boolean Solohabilitados)
        {
            this.NullParametrosBusqueda();
            this.ValorParametrosBusqueda("idrol", idRol.ToString());
            if (Solohabilitados)
                this.ValorParametrosBusqueda("estado", "1");
            LlenadoTabla();        
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
            public int rol;
            public string Nombre;
            public UsuarioSerializable(long? id, string usuario,int rol,string nombre)
            {
                this.id = id;
                this.usuario = usuario;
                this.rol = rol;
                this.Nombre = nombre; 
            }

        }
        #endregion        

    }
}
