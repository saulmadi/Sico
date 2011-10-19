using System;
using System.Collections.Generic;

namespace SiCo.lgla
{
    public class PersonaJuridica : Entidades
    {
        #region Declaraciones

        #endregion

        #region Constructor

        public PersonaJuridica()
        {
            ComandoSelect = "PersonaJuridica_Buscar";
            _espersonanatural = false;

            ColeccionParametrosBusqueda.Add(new Parametro("razonsocial", null));
            ColeccionParametrosBusqueda.Add(new Parametro("razonsocialigual", null));
            ColeccionParametrosBusqueda.Add(new Parametro("rtn", null));
        }

        public PersonaJuridica(long? id, string RazonSocial, string correo, string direccion, string rtn, int? Telefono,
                               int? Telefono2)
        {
            ComandoSelect = "PersonaJuridica_Buscar";
            _espersonanatural = false;

            ColeccionParametrosBusqueda.Add(new Parametro("razonsocial", null));
            ColeccionParametrosBusqueda.Add(new Parametro("razonsocialigual", null));
            ColeccionParametrosBusqueda.Add(new Parametro("rtn", null));

            _Id = id;
            this.RazonSocial = RazonSocial;
            this.correo = correo;
            this.direccion = direccion;
            this.rtn = rtn;
            telefono = Telefono;
            telefono2 = Telefono2;
        }

        public PersonaJuridica(long? id, string RazonSocial)
        {
            ComandoSelect = "PersonaJuridica_Buscar";
            _espersonanatural = false;

            ColeccionParametrosBusqueda.Add(new Parametro("razonsocial", null));
            ColeccionParametrosBusqueda.Add(new Parametro("razonsocialigual", null));
            ColeccionParametrosBusqueda.Add(new Parametro("rtn", null));

            _Id = id;
            this.RazonSocial = RazonSocial;
        }

        #endregion

        #region Propiedades

        public string RazonSocial { get; set; }

        #endregion

        #region Metodos

        protected override void CargadoPropiedades(int Indice)
        {
            RazonSocial = Registro(Indice, "razonsocial").ToString();

            base.CargadoPropiedades(Indice);
        }

        public override void Guardar()
        {
            NullParametrosMantenimiento();
            ValorParametrosMantenimiento("entidadnombre", RazonSocial.Trim());
            ValorParametrosMantenimiento("identificacion", Guid.NewGuid().ToString());
            ValorParametrosMantenimiento("tipoIdentidad", "J");

            base.Guardar();
        }

        public void Buscar(string RazonSocial, string rtn, bool t)
        {
            NullParametrosBusqueda();
            ValorParametrosBusqueda("razonsocial", RazonSocial);
            ValorParametrosBusqueda("rtn", rtn);
            base.Buscar();
        }

        public override object TablaAColeccion()
        {
            base.TablaAColeccion();
            var lista = new List<PersonaJuridica>();
            for (int i = 0; i < TotalRegistros; i++)
            {
                CargadoPropiedades(i);
                var pntemp = new PersonaJuridica(_Id, RazonSocial, correo, direccion, rtn, telefono, telefono2);
                lista.Add(pntemp);
            }
            return lista;
        }

        #endregion
    }
}