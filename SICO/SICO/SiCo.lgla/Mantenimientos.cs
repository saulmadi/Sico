using System;

namespace SiCo.lgla
{
    [Serializable]
    public abstract class Mantenimientos : Entidad
    {
        #region Declaraciones

        private int _Estado;
        private PersonaJuridica _PersonaJuridica = new PersonaJuridica();
        private PersonaNatural _PersonaNatural = new PersonaNatural();
        private long? _idEntidades;

        #endregion

        #region Constructor

        public Mantenimientos()
        {
            ColeccionParametrosBusqueda.Add(new Parametro("identidades", null));
            ColeccionParametrosBusqueda.Add(new Parametro("entidadnombre", null));
            ColeccionParametrosBusqueda.Add(new Parametro("espersonanatural", null));
            ColeccionParametrosBusqueda.Add(new Parametro("usuario", null));
            ColeccionParametrosBusqueda.Add(new Parametro("contrasena", null));
            ColeccionParametrosBusqueda.Add(new Parametro("estado", null));
            ColeccionParametrosBusqueda.Add(new Parametro("idrol", null));

            ColeccionParametrosMantenimiento.Add(new Parametro("identidades", null));
            ColeccionParametrosMantenimiento.Add(new Parametro("estado", null));

            ComandoSelect = "MantenimientosComplejos_Buscar";
        }

        public Mantenimientos(long? id, long? idEntidades, int estado)
        {
            ColeccionParametrosBusqueda.Add(new Parametro("identidades", null));
            ColeccionParametrosBusqueda.Add(new Parametro("entidadnombre", null));
            ColeccionParametrosBusqueda.Add(new Parametro("espersonanatural", null));
            ColeccionParametrosBusqueda.Add(new Parametro("usuario", null));
            ColeccionParametrosBusqueda.Add(new Parametro("contrasena", null));
            ColeccionParametrosBusqueda.Add(new Parametro("estado", null));
            ColeccionParametrosBusqueda.Add(new Parametro("idrol", null));

            ColeccionParametrosMantenimiento.Add(new Parametro("identidades", null));
            ColeccionParametrosMantenimiento.Add(new Parametro("estado", null));

            ComandoSelect = "MantenimientosComplejos_Buscar";
            _Id = id;
            _idEntidades = idEntidades;
            Estado = estado;
        }

        #endregion

        #region Propiedades

        public long? idEntidades
        {
            get { return _idEntidades; }
            set { _idEntidades = value; }
        }

        public string NombreMantenimiento
        {
            get
            {
                if (PersonaJuridica != null)
                {
                    return PersonaJuridica.RazonSocial;
                }
                if (PersonaNatural != null)
                {
                    return PersonaNatural.NombreCompletoMostrar;
                }
                return string.Empty;
            }
        }

        public PersonaNatural PersonaNatural
        {
            get
            {
                if (_PersonaNatural != null)
                {
                    if (_PersonaNatural.Id > 0)
                        return _PersonaNatural;
                }
                _PersonaNatural = CrearPersonaNatural(0);
                return _PersonaNatural;
            }

            set { _PersonaNatural = value; }
        }

        public PersonaJuridica PersonaJuridica
        {
            get
            {
                if (_PersonaJuridica != null)
                {
                    if (_PersonaJuridica.Id > 0)
                        return _PersonaJuridica;
                }
                _PersonaJuridica = CrearPersonaJuridica(0);
                return _PersonaJuridica;
            }
            set { _PersonaJuridica = value; }
        }

        public string TablaBusqueda { get; set; }

        public int Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        #endregion

        #region Metodos

        public override void Guardar()
        {
            ValorParametrosMantenimiento("estado", Estado);
            ValorParametrosMantenimiento("identidades", idEntidades);
            base.Guardar();
        }

        public void Buscar(int identidades)
        {
            NullParametrosBusqueda();
            ValorParametrosBusqueda("identidades", identidades);
            LlenadoTabla(ColeccionParametrosBusqueda);
        }

        public void Buscar(string EntidadNombre)
        {
            NullParametrosBusqueda();
            ValorParametrosBusqueda("entidadnombre", EntidadNombre);
            LlenadoTabla(ColeccionParametrosBusqueda);
        }

        protected override void CargadoPropiedades(int Indice)
        {
            Estado = Convert.ToInt32(Registro(Indice, "estado"));
            idEntidades = Convert.ToInt64((Registro(Indice, "identidades")));
            _PersonaJuridica = CrearPersonaJuridica(Indice);
            _PersonaNatural = CrearPersonaNatural(Indice);

            base.CargadoPropiedades(Indice);
        }

        protected PersonaNatural CrearPersonaNatural(int Indice)
        {
            if (TotalRegistros > 0)
            {
                var p = new PersonaNatural();
                if (!(idEntidades == null) && Convert.ToInt32(Registro(Indice, "espersonanatural")) == 1)
                {
                    p = new PersonaNatural(idEntidades, (string) Registro(Indice, "entidadnombre"),
                                           new TipoIdentidad((string) Registro(Indice, "tipoidentidad")),
                                           (string) Registro(Indice, "identificacion"),
                                           (string) Registro(Indice, "correo"), (string) Registro(Indice, "direccion"),
                                           (string) Registro(Indice, "rtn"), (int?) Registro(Indice, "telefono"),
                                           (int?) Registro(Indice, "telefono2"));
                }
                else
                    p = null;


                return p;
            }
            return null;
        }

        protected PersonaJuridica CrearPersonaJuridica(int Indice)
        {
            if (TotalRegistros > 0)
            {
                var p = new PersonaJuridica();
                if (!(idEntidades == null) && Convert.ToInt32(Registro(Indice, "espersonanatural")) == 0)
                {
                    p = new PersonaJuridica(idEntidades, (string) Registro(Indice, "entidadnombre"),
                                            (string) Registro(Indice, "correo"), (string) Registro(Indice, "direccion"),
                                            (string) Registro(Indice, "rtn"), (int?) Registro(Indice, "telefono"),
                                            (int?) Registro(Indice, "telefono2"));
                }
                else
                    p = null;

                return p;
            }
            return null;
        }

        #endregion
    }
}