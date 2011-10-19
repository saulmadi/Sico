using System;
using System.Collections.Generic;
using SiCo.dtla;

namespace SiCo.lgla
{
    public class Sucursales : Mantenimientos
    {
        #region "Declaraciones"

        public string NombreSucursal;
        public string PieSucursal;

        #endregion

        #region Constructor

        public Sucursales()
        {
            ColeccionParametrosMantenimiento.Add(new Parametro("idusuario", null));
            ColeccionParametrosMantenimiento.Add(new Parametro("idmunicipio", null));
            ColeccionParametrosMantenimiento.Add(new Parametro("numerofactura", null));

            TablaBusqueda = "Sucursales";
            ColeccionParametrosBusqueda.Add(new Parametro("tabla", TablaBusqueda));

            ComandoMantenimiento = "Sucursales_Mant";
            TablaEliminar = "Sucursales";
        }

        public Sucursales(long? id, long? identidad, int Estado, long? idusuario, long? idmunicipios)
            : base(id, identidad, Estado)
        {
            idUsuario = idusuario;
            idMunicipio = idmunicipios;

            ColeccionParametrosMantenimiento.Add(new Parametro("idusuario", null));
            ColeccionParametrosMantenimiento.Add(new Parametro("idmunicipio", null));
            ColeccionParametrosMantenimiento.Add(new Parametro("numerofactura", null));

            TablaBusqueda = "Sucursales";
            ColeccionParametrosBusqueda.Add(new Parametro("tabla", TablaBusqueda));
            ComandoMantenimiento = "Sucursales_Mant";
            TablaEliminar = "Sucursales";
        }

        public Sucursales(long? id, long? identidad, string descripcion)
            : base(id, identidad, 1)
        {
            PersonaJuridica = new PersonaJuridica(identidad, descripcion);

            ColeccionParametrosMantenimiento.Add(new Parametro("idusuario", null));
            ColeccionParametrosMantenimiento.Add(new Parametro("idmunicipio", null));
            ColeccionParametrosMantenimiento.Add(new Parametro("numerofactura", null));

            TablaBusqueda = "Sucursales";
            ColeccionParametrosBusqueda.Add(new Parametro("tabla", TablaBusqueda));
            ComandoMantenimiento = "Sucursales_Mant";
            TablaEliminar = "Sucursales";
        }

        #endregion

        #region "Propiedades"

        public long? idUsuario { get; set; }

        public long? idMunicipio { get; set; }

        public string Archivo
        {
            get
            {
                var c = new ClavesRegistro();
                return c.Instalacion + "Scx.sco";
            }
        }

        public Int64 NumeroFactura { get; set; }

        #endregion

        #region "Metodos"

        protected override void CargadoPropiedades(int Indice)
        {
            idUsuario = Convert.ToInt64(Registro(Indice, "idusuario"));
            idMunicipio = Convert.ToInt64(Registro(Indice, "idmunicipio"));
            NumeroFactura = Convert.ToInt64(Registro(Indice, "numerofactura"));
            base.CargadoPropiedades(Indice);
        }

        public override void Guardar()
        {
            NullParametrosMantenimiento();
            ValorParametrosMantenimiento("idusuario", idUsuario);
            ValorParametrosMantenimiento("idmunicipio", idMunicipio);
            ValorParametrosMantenimiento("numerofactura", NumeroFactura);
            base.Guardar();
        }

        public override object TablaAColeccion()
        {
            var lista = new List<Sucursales>();
            if (TotalRegistros > 0)
            {
                for (int x = 0; x < TotalRegistros; x++)
                {
                    CargadoPropiedades(x);
                    var tempsucu = new Sucursales(Id, idEntidades, Estado, idUsuario, idMunicipio);
                    tempsucu.NumeroFactura = NumeroFactura;
                    tempsucu.PersonaJuridica = PersonaJuridica;
                    tempsucu.PersonaNatural = PersonaNatural;

                    lista.Add(tempsucu);
                }

                CargadoPropiedades(0);
            }
            return lista;
        }

        public void Cargar()
        {
            try
            {
                var s = new Serializador();


                var usu = new SucursalSerializable(0, 0, "", PieSucursal);
                s.Objeto = usu;
                s.Directorio = Archivo;
                s.Cargar();
                usu = (SucursalSerializable) s.Objeto;
                _Id = usu.id;
                PieSucursal = usu.PieReporte;
                idUsuario = usu.idusuario;
                NombreSucursal = usu.NombreSucursal;
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
                PieSucursal = PersonaJuridica.RazonSocial.Trim() + ";";
                if (PersonaJuridica.telefono != null)
                    PieSucursal += " Teléfonos: " + PersonaJuridica.telefono.ToString();

                if (PersonaJuridica.telefono2 != null)
                    PieSucursal += "/ " + PersonaJuridica.telefono2;

                if (PersonaJuridica.direccion != null)
                    PieSucursal += "; " + PersonaJuridica.direccion;
                var usu = new SucursalSerializable(Id, idUsuario, NombreMantenimiento, PieSucursal);
                s.Objeto = usu;
                s.Directorio = Archivo;
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

        [Serializable]
        public class SucursalSerializable
        {
            public string NombreSucursal;
            public string PieReporte;
            public long? id;
            public long? idusuario;

            public SucursalSerializable(long? id, long? usuario, string nombresucursal, string PieReporte)
            {
                this.id = id;
                idusuario = usuario;
                NombreSucursal = nombresucursal;
                this.PieReporte = PieReporte;
            }
        }

        #endregion
    }
}