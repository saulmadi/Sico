using System;
using System.Collections.Generic;

namespace SiCo.lgla

{
    public class PersonaNatural : Entidades
    {
        #region Declaraciones

        private TipoIdentidad _TipoIdentidad = new TipoIdentidad();

        #endregion

        #region constructor

        public PersonaNatural()
        {
            ComandoSelect = "PersonaNatural_buscar";
            _espersonanatural = true;
            ColeccionParametrosBusqueda.Add(new Parametro("nombrecompleto", null));
            ColeccionParametrosBusqueda.Add(new Parametro("identificacion", null));
            ColeccionParametrosBusqueda.Add(new Parametro("tipoidentificacion", null));
            ColeccionParametrosBusqueda.Add(new Parametro("nombrecompletoigual", null));
            ColeccionParametrosBusqueda.Add(new Parametro("rtn", null));
            tipoidentidad.Valor = "I";
        }

        public PersonaNatural(long? id, string NombreCompleto, TipoIdentidad TipoIdentidad, string Identificacion,
                              string correo, string direccion, string rtn, int? Telefono, int? telefono2)
        {
            ComandoSelect = "PersonaNatural_buscar";
            _espersonanatural = true;
            ColeccionParametrosBusqueda.Add(new Parametro("nombrecompleto", null));
            ColeccionParametrosBusqueda.Add(new Parametro("identificacion", null));
            ColeccionParametrosBusqueda.Add(new Parametro("tipoidentificacion", null));
            ColeccionParametrosBusqueda.Add(new Parametro("rtn", null));

            _Id = id;
            this.NombreCompleto = NombreCompleto;
            identificacion = Identificacion;
            tipoidentidad = TipoIdentidad;
            this.correo = correo;
            this.direccion = direccion;
            this.rtn = rtn;
            telefono = Telefono;
            this.telefono2 = telefono2;
        }

        #endregion

        #region Propiedades

        public string NombreCompleto { get; set; }

        public string identificacion { get; set; }

        public string IdentificacionMostrar
        {
            get
            {
                if (tipoidentidad.Valor == "N")
                    return string.Empty;
                else
                    return identificacion;
            }
        }

        public TipoIdentidad tipoidentidad
        {
            get { return _TipoIdentidad; }
            set { _TipoIdentidad = value; }
        }

        public string NombreCompletoMostrar
        {
            get { return NombreCompleto.Replace("@", "").Replace("%", "").Replace("&", "").Replace("$", ""); }
        }

        #endregion

        #region Metodos

        protected override void CargadoPropiedades(int Indice)
        {
            if (TotalRegistros > 0)
            {
                NombreCompleto = Registro(Indice, "NombreCompleto").ToString();
                identificacion = Registro(Indice, "identificacion").ToString();
                if (Registro(Indice, "tipoidentidad").ToString() == "I")
                    tipoidentidad = new TipoIdentidad("Identidad", "I");
                else if (Registro(Indice, "tipoidentidad").ToString() == "R")
                    tipoidentidad = new TipoIdentidad("Residencia", "R");
                else if (Registro(Indice, "tipoidentidad").ToString() == "N")
                    tipoidentidad = new TipoIdentidad("N");
                base.CargadoPropiedades(Indice);
            }
        }

        public void Buscar(string nombrecompleto, string identidad, string rtn)
        {
            NullParametrosBusqueda();
            ValorParametrosBusqueda("nombrecompleto", nombrecompleto);
            ValorParametrosBusqueda("nombrecompleto", nombrecompleto);
            ValorParametrosBusqueda("nombrecompleto", nombrecompleto);

            LlenadoTabla(ColeccionParametrosBusqueda);
        }

        public static string CrearNombreCompleto(string NombreCompleto, ref string PrimerNombre,
                                                 ref string SegundoNombre, ref string PrimerApellido,
                                                 ref string SegundoApellido)
        {
            if (NombreCompleto != string.Empty)
            {
                if (NombreCompleto.EndsWith("@"))
                {
                    string[] Nombre;
                    Nombre = NombreCompleto.Replace("@", "").Split(' ');
                    PrimerNombre = Nombre[0];
                    PrimerApellido = Nombre[1];
                    SegundoApellido = "";
                    SegundoNombre = "";
                }
                else if (NombreCompleto.EndsWith("$"))
                {
                    string[] Nombre;
                    Nombre = NombreCompleto.Replace("$", "").Split(' ');
                    PrimerNombre = Nombre[0];
                    SegundoNombre = "";
                    PrimerApellido = Nombre[1];
                    SegundoApellido = Nombre[2];
                }
                else if (NombreCompleto.EndsWith("%"))
                {
                    string[] Nombre;
                    Nombre = NombreCompleto.Replace("%", "").Split(' ');
                    PrimerNombre = Nombre[0];
                    SegundoNombre = Nombre[1];
                    PrimerApellido = Nombre[2];
                    SegundoApellido = "";
                }
                else if (NombreCompleto.EndsWith("&"))
                {
                    string[] Nombre;
                    Nombre = NombreCompleto.Replace("&", "").Split(' ');
                    PrimerNombre = Nombre[0];
                    SegundoNombre = Nombre[1];
                    PrimerApellido = Nombre[2];
                    SegundoApellido = Nombre[3];
                }
                else
                {
                    throw new ApplicationException("El nombre completo no tiene el formato correcto");
                }

                return NombreCompleto;
            }
            else
            {
                if (SegundoApellido.Trim() == string.Empty && SegundoNombre.Trim() == string.Empty)
                {
                    return PrimerNombre.Trim() + " " + PrimerApellido.Trim() + "@";
                }

                if (SegundoApellido.Trim() != string.Empty && SegundoNombre.Trim() == string.Empty)
                {
                    return PrimerNombre.Trim() + " " + PrimerApellido.Trim() + " " + SegundoApellido.Trim() + "$";
                }

                if (SegundoApellido.Trim() == string.Empty && SegundoNombre.Trim() != string.Empty)
                {
                    return PrimerNombre.Trim() + " " + SegundoNombre.Trim() + " " + PrimerApellido.Trim() + "%";
                }

                if (SegundoApellido.Trim() != string.Empty && SegundoNombre.Trim() != string.Empty)
                {
                    return PrimerNombre.Trim() + " " + SegundoNombre.Trim() + " " + PrimerApellido.Trim() + " " +
                           SegundoApellido.Trim() + "&";
                }
                throw new ApplicationException(
                    "El nombre completo no puede ser creado dado que la persona tiene que tener un nombre y un apellido");
            }
        }

        public override void Guardar()
        {
            NullParametrosMantenimiento();
            ValorParametrosMantenimiento("entidadnombre", NombreCompleto);
            ValorParametrosMantenimiento("identificacion", identificacion);
            ValorParametrosMantenimiento("tipoIdentidad", tipoidentidad.Valor);
            base.Guardar();
        }

        public override object TablaAColeccion()
        {
            base.TablaAColeccion();
            var lista = new List<PersonaNatural>();
            for (int i = 0; i < TotalRegistros; i++)
            {
                CargadoPropiedades(i);
                var pntemp = new PersonaNatural(_Id, NombreCompleto, tipoidentidad, identificacion, correo, direccion,
                                                rtn, telefono, telefono2);
                lista.Add(pntemp);
            }
            return lista;
        }

        #endregion
    }
}