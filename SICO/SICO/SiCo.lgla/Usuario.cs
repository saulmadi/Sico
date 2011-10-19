using System;
using System.Collections.Generic;
using SiCo.dtla;
using SiCo.sgla;

namespace SiCo.lgla
{
    public class Usuario : Mantenimientos
    {
        #region Declaraciones

        public string NombreUsuario;
        private string _contrasena = string.Empty;
        private int _rol = 1;

        #endregion

        #region Constructor

        public Usuario()
        {
            //Texto temporal solo para el ingreso del control de persona natural y de entidad

            ColeccionParametrosMantenimiento.Add(new Parametro("usuario", null));
            ColeccionParametrosMantenimiento.Add(new Parametro("contrasena", null));
            ColeccionParametrosMantenimiento.Add(new Parametro("idsucursales", null));
            ColeccionParametrosMantenimiento.Add(new Parametro("idrol", null));
            TablaBusqueda = "usuarios";
            ColeccionParametrosBusqueda.Add(new Parametro("tabla", TablaBusqueda));
            ComandoMantenimiento = "Usuarios_Mant";
            TablaEliminar = "usuarios";
        }

        public Usuario(long? id, long? idEntidades, int estado, string usuario, string contrasena, long? sucursal)
            : base(id, idEntidades, estado)
        {
            //Texto temporal solo para el ingreso del control de persona natural y de entidad

            ColeccionParametrosMantenimiento.Add(new Parametro("usuario", null));
            ColeccionParametrosMantenimiento.Add(new Parametro("contrasena", null));
            ColeccionParametrosMantenimiento.Add(new Parametro("idsucursales", null));
            ColeccionParametrosMantenimiento.Add(new Parametro("idrol", null));
            TablaBusqueda = "usuarios";
            ColeccionParametrosBusqueda.Add(new Parametro("tabla", TablaBusqueda));
            ComandoMantenimiento = "Usuarios_Mant";
            this.usuario = usuario;
            this.contrasena = contrasena;
            this.sucursal = sucursal;
            TablaEliminar = "usuarios";
        }

        #endregion

        #region Propiedades

        public string usuario { get; set; }

        public string contrasena
        {
            get { return _contrasena; }
            set { _contrasena = value; }
        }

        public long? sucursal { get; set; }

        public int rol
        {
            get { return _rol; }
            set { _rol = value; }
        }

        public string Archivo
        {
            get
            {
                var c = new ClavesRegistro();
                return c.Instalacion + "Usx.sco";
            }
        }

        #endregion

        #region Metodos

        protected override void CargadoPropiedades(int Indice)
        {
            rol = Convert.ToInt32(Registro(Indice, "idrol"));
            usuario = (string) Registro(Indice, "usuario");
            contrasena = Cripto.DesEncriptar((string) Registro(Indice, "contrasena"));
            sucursal = Convert.ToInt64(Registro(Indice, "idsucursales"));
            base.CargadoPropiedades(Indice);
        }

        public override void Guardar()
        {
            NullParametrosMantenimiento();
            ValorParametrosMantenimiento("usuario", usuario);
            ValorParametrosMantenimiento("contrasena", Cripto.Encriptar(contrasena));
            ValorParametrosMantenimiento("idrol", rol);
            ValorParametrosMantenimiento("idsucursales", sucursal);
            base.Guardar();
        }

        public void Cargar()
        {
            try
            {
                var s = new Serializador();
                var usu = new UsuarioSerializable(0, string.Empty, 0, "");
                s.Objeto = usu;
                s.Directorio = Archivo;
                s.Cargar();
                usu = (UsuarioSerializable) s.Objeto;
                _Id = usu.id;
                usuario = usu.usuario;
                rol = usu.rol;
                NombreUsuario = usu.Nombre;
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
                var s = new Serializador();
                var usu = new UsuarioSerializable(Id, usuario, rol, NombreMantenimiento);
                s.Objeto = usu;
                s.Directorio = Archivo;
                s.Guardar();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al guardar el usuario favor volver a iniciar sesión", ex);
            }
        }

        public bool Autenticar(string usuario, string contrasena, Parametro p)
        {
            NullParametrosBusqueda();
            ValorParametrosBusqueda("usuario", usuario);
            ValorParametrosBusqueda("estado", "1");
            ValorParametrosBusqueda(p.Nombre, p.Valor);

            LlenadoTabla(ColeccionParametrosBusqueda);
            if (this.contrasena == contrasena)
                return true;

            return false;
        }

        public string CrearUsuario(string nombreUsuario)
        {
            try
            {
                return (string) EjecutaFuncion("select CrearUsuario('" + nombreUsuario + "')");
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public override object TablaAColeccion()
        {
            var Lista = new List<Usuario>();
            if (TotalRegistros > 0)
            {
                for (int x = 0; x < TotalRegistros; x++)
                {
                    CargadoPropiedades(x);
                    var tempUsu = new Usuario(Id, idEntidades, Estado, usuario, contrasena, sucursal);
                    tempUsu.rol = rol;
                    tempUsu.PersonaJuridica = PersonaJuridica;
                    tempUsu.PersonaNatural = PersonaNatural;

                    Lista.Add(tempUsu);
                }

                CargadoPropiedades(0);
            }

            return Lista;
        }

        public void Buscar(int idRol, Boolean Solohabilitados)
        {
            NullParametrosBusqueda();
            ValorParametrosBusqueda("idrol", idRol.ToString());
            if (Solohabilitados)
                ValorParametrosBusqueda("estado", "1");
            LlenadoTabla();
        }

        #endregion

        #region Eventos

        #endregion

        #region ClaseSerializable

        [Serializable]
        public class UsuarioSerializable
        {
            public string Nombre;
            public long? id;
            public int rol;
            public string usuario;

            public UsuarioSerializable(long? id, string usuario, int rol, string nombre)
            {
                this.id = id;
                this.usuario = usuario;
                this.rol = rol;
                Nombre = nombre;
            }
        }

        #endregion
    }
}