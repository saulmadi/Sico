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
        private PersonaNatural  _PersonaNatural= new PersonaNatural () ;
        private PersonaJuridica  _PersonaJuridica = new PersonaJuridica() ;
        private int _Estado = 0;
        #endregion

        #region Constructor
        public Mantenimientos()
        {
            this.ColeccionParametrosBusqueda.Add(new Parametro("identidades", null));
            this.ColeccionParametrosBusqueda.Add(new Parametro("entidadnombre", null));
            this.ColeccionParametrosBusqueda.Add(new Parametro("espersonanatural", null));
            this.ColeccionParametrosBusqueda.Add(new Parametro("usuario", null));
            this.ColeccionParametrosBusqueda.Add(new Parametro("contrasena", null));
            this.ColeccionParametrosBusqueda.Add(new Parametro("estado", null));
            this.ColeccionParametrosBusqueda.Add(new Parametro("idrol", null));

            this.ColeccionParametrosMantenimiento.Add(new Parametro("identidades", null));
            this.ColeccionParametrosMantenimiento.Add(new Parametro("estado", null));

            this.ComandoSelect = "MantenimientosComplejos_Buscar";
            
        }
        public Mantenimientos(long? id, long? idEntidades,int estado)
        {
            this.ColeccionParametrosBusqueda.Add(new Parametro("identidades", null));
            this.ColeccionParametrosBusqueda.Add(new Parametro("entidadnombre", null));
            this.ColeccionParametrosBusqueda.Add(new Parametro("espersonanatural", null));
            this.ColeccionParametrosBusqueda.Add(new Parametro("usuario", null));
            this.ColeccionParametrosBusqueda.Add(new Parametro("contrasena", null));
            this.ColeccionParametrosBusqueda.Add(new Parametro("estado", null));
            this.ColeccionParametrosBusqueda.Add(new Parametro("idrol", null));

            this.ColeccionParametrosMantenimiento.Add(new Parametro("identidades", null));
            this.ColeccionParametrosMantenimiento.Add(new Parametro("estado", null));

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
                if (_PersonaNatural != null)
                {
                    if (_PersonaNatural.Id  > 0)
                        return _PersonaNatural;
                                         
                }
                _PersonaNatural = CrearPersonaNatural(0);
                return _PersonaNatural;
            }

            set 
            {
                _PersonaNatural = value;
            }
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
            set 
            {
                _PersonaJuridica = value;
            }
        }

        public string TablaBusqueda
        {
            get;
            set;
        }

        public int Estado
        {
            get { return _Estado ;}
            set { _Estado = value; }
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

        public void Buscar(string EntidadNombre)
        {
            this.NullParametrosBusqueda();
            this.ValorParametrosBusqueda("entidadnombre", EntidadNombre);            
            this.LlenadoTabla(this.ColeccionParametrosBusqueda);
        }

        protected override void CargadoPropiedades(int Indice)
        {
            this.Estado = Convert.ToInt32( this.Registro(Indice, "estado")); 
            this.idEntidades = Convert.ToInt64(  (  this.Registro(Indice, "identidades")));
            this._PersonaJuridica = CrearPersonaJuridica(Indice );
            this._PersonaNatural = CrearPersonaNatural(Indice ); 

            base.CargadoPropiedades(Indice);
        }

        protected   PersonaNatural CrearPersonaNatural(int Indice)
        {
            if (this.TotalRegistros > 0)
            {
                
                PersonaNatural p = new PersonaNatural();
                if (!(this.idEntidades == null) && Convert.ToInt32(Registro(Indice, "espersonanatural")) == 1)
                {

                    p = new PersonaNatural(this.idEntidades, (string)Registro(Indice, "entidadnombre"), new TipoIdentidad((string)Registro(Indice, "tipoidentidad")), (string)Registro(Indice, "identificacion"), (string)Registro(Indice, "correo"), (string)Registro(Indice, "direccion"), (string)Registro(Indice, "rtn"), (int?)Registro(Indice, "telefono"), (int?)Registro(Indice, "telefono2"));
                }
                else
                    p = null;

                
                return p;                
            
            }
            return null;
        }

        protected  PersonaJuridica CrearPersonaJuridica(int Indice)
        {
            if (this.TotalRegistros > 0)
            {
                
                PersonaJuridica p = new PersonaJuridica();
                if (!(this.idEntidades == null) && Convert.ToInt32(Registro(Indice, "espersonanatural")) == 0)
                {
                    p = new PersonaJuridica(this.idEntidades, (string)Registro(Indice, "entidadnombre"), (string)Registro(Indice, "correo"), (string)Registro(Indice, "direccion"), (string)Registro(Indice, "rtn"), (int?)Registro(Indice, "telefono"), (int?)Registro(Indice, "telefono2"));
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
