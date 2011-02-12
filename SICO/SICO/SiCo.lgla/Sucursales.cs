using System;
using System.Collections.Generic;
using System.Text;
using SiCo.dtla;

namespace SiCo.lgla
{
    public class Sucursales:Mantenimientos
    {
        #region "Declaraciones"
        #endregion

        #region Constructor
        public Sucursales()
        {
            this.ColeccionParametrosMantenimiento.Add(new Parametro("idusuario", null));
            this.ColeccionParametrosMantenimiento.Add(new Parametro("idmunicipio", null));
            this.ColeccionParametrosMantenimiento.Add(new Parametro("numerofactura", null));

            this.TablaBusqueda = "Sucursales";
            this.ColeccionParametrosBusqueda.Add(new Parametro("tabla", this.TablaBusqueda));

            this.ComandoMantenimiento = "Sucursales_Mant";
            this.TablaEliminar = "Sucursales";

        }

        public Sucursales(long? id, long? identidad, int Estado, long? idusuario, long? idmunicipios)
            : base(id, identidad, Estado)
        {
            this.idUsuario  = idusuario;
            this.idMunicipio = idmunicipios;

            this.ColeccionParametrosMantenimiento.Add(new Parametro("idusuario", null));
            this.ColeccionParametrosMantenimiento.Add(new Parametro("idmunicipio", null));
            this.ColeccionParametrosMantenimiento.Add(new Parametro("numerofactura", null));

            this.TablaBusqueda = "Sucursales";
            this.ColeccionParametrosBusqueda.Add(new Parametro("tabla", this.TablaBusqueda));
            this.ComandoMantenimiento = "Sucursales_Mant";
            this.TablaEliminar = "Sucursales";
        }

        #endregion

        #region "Propiedades"

        public long? idUsuario
        {
            get;
            set;
        }

        public long? idMunicipio
        {
            get;
            set;
        }

        public string Archivo
        {

            get
            {
                SiCo.dtla.ClavesRegistro c = new SiCo.dtla.ClavesRegistro();
                return c.Instalacion + "Scx.sco";
            }
        }

        public Int64 NumeroFactura
        {
            get;
            set;
        }


        #endregion

        #region "Metodos"

        protected override void CargadoPropiedades(int Indice)
        {
            this.idUsuario =Convert.ToInt64(Registro(Indice, "idusuario"));   
            this.idMunicipio = Convert.ToInt64 (Registro(Indice,"idmunicipio"));
            this.NumeroFactura = Convert.ToInt64(Registro(Indice, "numerofactura"));
            base.CargadoPropiedades(Indice);
        }

        public override void Guardar()
        {
            this.NullParametrosMantenimiento();
            this.ValorParametrosMantenimiento("idusuario", this.idUsuario);
            this.ValorParametrosMantenimiento("idmunicipio", this.idMunicipio );
            this.ValorParametrosMantenimiento("numerofactura", this.NumeroFactura); 
            base.Guardar();
        }

        public override object TablaAColeccion()
        {
            List<Sucursales> lista = new List<Sucursales>();
            if (this.TotalRegistros > 0)
            {
                for (int x = 0; x < this.TotalRegistros; x++)
                {
                    this.CargadoPropiedades(x);
                    Sucursales tempsucu = new Sucursales(this.Id, this.idEntidades,this.Estado , this.idUsuario,this.idMunicipio );
                    tempsucu.NumeroFactura = this.NumeroFactura; 
                    tempsucu.PersonaJuridica = this.PersonaJuridica;
                    tempsucu.PersonaNatural = this.PersonaNatural;

                    lista.Add(tempsucu);
                }

                this.CargadoPropiedades(0);
            }            
            return lista;
        }

        public void Cargar()
        {
            try
            {
                Serializador s = new Serializador();
                SucursalSerializable  usu = new SucursalSerializable (0,0);
                s.Objeto = usu;
                s.Directorio = this.Archivo;
                s.Cargar();
                usu = (SucursalSerializable )s.Objeto;
                this._Id = usu.id;
                this.idUsuario = usu.idusuario;                
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
                SucursalSerializable  usu = new SucursalSerializable (this.Id, this.idUsuario);
                s.Objeto = usu;
                s.Directorio = this.Archivo;
                s.Guardar();

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al guardar el usuario favor volver a iniciar sesión", ex);
            }
        }

        #endregion

        #region "Eventos"
        #endregion

        #region ClaseSerializable
        [Serializable()]
        public class SucursalSerializable
        {
            public long? id;
            public long? idusuario;

            public SucursalSerializable(long? id, long? usuario)
            {
                this.id = id;
                this.idusuario = usuario;
            }

        }
        #endregion        
    }
}
