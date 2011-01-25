using System;
using System.Collections.Generic;
using System.Text;

namespace SiCo.lgla
{
    [Serializable()]
    public abstract class Mantenimientos : SiCo.lgla.Entidad
    {
        #region Declaraciones
        private long? _idEntidades;
        #endregion

        #region Constructor
        public Mantenimientos()
        {
            this.ColeccionParametrosBusqueda.Add(new Parametro("identidades", null));
            this.ColeccionParametrosBusqueda.Add(new Parametro("entidadnombre", null));
            this.ColeccionParametrosBusqueda.Add(new Parametro("espersonanatural", null));
            this.ColeccionParametrosBusqueda.Add(new Parametro("usuario", null));
            this.ColeccionParametrosBusqueda.Add(new Parametro("contrasena", null));

            this.ColeccionParametrosMantenimiento.Add(new Parametro("identidades", null));

            this.ComandoSelect = "MantenimientosComplejos_Buscar";
            
        }
        public Mantenimientos(long? id, long? idEntidades,int estado)
        {
            this.ColeccionParametrosBusqueda.Add(new Parametro("identidades", null));
            this.ColeccionParametrosBusqueda.Add(new Parametro("entidadnombre", null));
            this.ColeccionParametrosBusqueda.Add(new Parametro("espersonnatural", null));
            this.ColeccionParametrosBusqueda.Add(new Parametro("usuario", null));
            this.ColeccionParametrosBusqueda.Add(new Parametro("contrasena", null));

            this.ColeccionParametrosMantenimiento.Add(new Parametro("identidades", null));

            this.ComandoSelect = "MantenimientosComplejos_Buscar";
            this._Id = id;
            this. _idEntidades=idEntidades;
            this.Estado = estado;

        }

        #endregion

        #region Propiedades
        public long? idEntidades
        {
            get
            {
                return _idEntidades;
            }
            set
            {
                _idEntidades = value;
            }
        }

        public string NombreMantenimiento
        {
            get
            {
                if (this.PersonaJuridica != null)
                {
                    return this.PersonaJuridica.RazonSocial; 
                }
                if (this.PersonaNatural != null)
                {
                    return this.PersonaNatural.NombreCompletoMostrar ;
                }
                return string.Empty;
            }
        }


        public PersonaNatural PersonaNatural
        {
            get
            {
                return CrearPersonaNatural();
            }
        }

        public PersonaJuridica PersonaJuridica
        {
            get
            {
                return CrearPersonaJuridica();
            }
        }

        public string TablaBusqueda
        {
            get;
            set;
        }

        public int Estado
        {
            get;
            set;
        }

        #endregion

        #region Metodos
        public override void Guardar()
        {
            this.ValorParametrosMantenimiento("estado", this.Estado); 
            this.ValorParametrosMantenimiento("identidades", this.idEntidades);
            base.Guardar();
        }

        public void Buscar(int identidades)
        {
            this.NullParametrosBusqueda();
            this.ValorParametrosBusqueda("identidades", identidades);
            this.LlenadoTabla(ColeccionParametrosBusqueda);
        }

        public void buscar(string EntidadNombre)
        {
            this.NullParametrosBusqueda();
            this.ValorParametrosBusqueda("entidadnombre", EntidadNombre);            
            this.LlenadoTabla(this.ColeccionParametrosBusqueda);
        }

        protected override void CargadoPropiedades(int Indice)
        {
            this.Estado = (int)this.Registro(Indice, "estado"); 
            this.idEntidades = (long)this.Registro(Indice, "identidades");
            base.CargadoPropiedades(Indice);
        }

        protected   PersonaNatural CrearPersonaNatural()
        {
            if (this.TotalRegistros > 0)
            { 

                long? i = (long?)PrimerRegistro("identidades");
                if (!(i == null) && (int)PrimerRegistro("espersonanatural") == 1 )
                {
                    return new PersonaNatural(i, (string)PrimerRegistro("entidadnombre"), new TipoIdentidad((string)PrimerRegistro("tipoidentificacion")), (string)PrimerRegistro("identificacion"), (string)PrimerRegistro("correo"), (string)PrimerRegistro("direccion"), (string)PrimerRegistro("rtn"), (int?)PrimerRegistro("telefono"), (int?)PrimerRegistro("telefono2"));
                }
            
            }
            return null;
        }

        protected  PersonaJuridica CrearPersonaJuridica()
        {
            if (this.TotalRegistros > 0)
            {
                long? i = (long?)PrimerRegistro("identidades");
                if (!(i == null) && (int)PrimerRegistro("espersonanatural") == 0)
                {
                    return new PersonaJuridica(i, (string)PrimerRegistro("entidadnombre"), (string)PrimerRegistro("correo"), (string)PrimerRegistro("direccion"), (string)PrimerRegistro("rtn"), (int?)PrimerRegistro("telefono"), (int?)PrimerRegistro("telefono2"));
                }
            }
            return null;
        }

        #endregion      
     
    }
}
