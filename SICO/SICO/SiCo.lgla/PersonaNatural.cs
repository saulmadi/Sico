using System;
using System.Collections.Generic;
using System.Text;

namespace SiCo.lgla

{
    public class PersonaNatural: Entidades
    {
        #region Declaraciones
        private TipoIdentidad _TipoIdentidad = new TipoIdentidad();       

        #endregion

        #region constructor
        public PersonaNatural():base()
        {            
            this.ComandoSelect = "PersonaNatural_buscar";
            this._espersonanatural = true;
            this.ColeccionParametrosBusqueda.Add(new Parametro("nombrecompleto",null));
            this.ColeccionParametrosBusqueda.Add(new Parametro("identificacion", null));
            this.ColeccionParametrosBusqueda.Add(new Parametro("rtn",null));  
            
        }
        public PersonaNatural(Int32 id, string NombreCompleto,TipoIdentidad TipoIdentidad, string Identificacion,string correo, string direccion, string rtn , int Telefono):base( )
        {
            this.ComandoSelect = "PersonaNatural_buscar";
            this._espersonanatural = true;
            this.ColeccionParametrosBusqueda.Add(new Parametro("nombrecompleto", null));
            this.ColeccionParametrosBusqueda.Add(new Parametro("identificacion", null));
            this.ColeccionParametrosBusqueda.Add(new Parametro("rtn", null)); 
            this._Id=id;
            this.NombreCompleto=NombreCompleto;
            this.identificacion = Identificacion;
            this.tipoidentidad = TipoIdentidad;
            this.correo = correo;
            this.direccion = direccion;
            this.rtn = rtn;
            this.telefono = Telefono;


        }
        #endregion

        #region Propiedades

        public string NombreCompleto
        {
            get;
            set;
        }

        public string identificacion
        {
            get;
            set;
        }

        public TipoIdentidad tipoidentidad
        {
            get { return _TipoIdentidad; }
            set{ _TipoIdentidad=value ;}
        }

        #endregion        
        
        #region Metodos
        protected override void CargadoPropiedades()
        {
            if (this.TotalRegistros > 0)
            {
                this.NombreCompleto = this.PrimerRegistro("NombreCompleto").ToString() ;                
                this.identificacion = this.PrimerRegistro("identificacion").ToString();
                if (PrimerRegistro("tipo").ToString() == "I")
                    this.tipoidentidad = new TipoIdentidad("Identidad", "I");
                else if (PrimerRegistro("tipo").ToString() == "P")
                    this.tipoidentidad = new TipoIdentidad("Pasaporte", "P");
                else this.tipoidentidad = new TipoIdentidad("Menor de Edad", "M");
                base.CargadoPropiedades();                
            }            
        }       

        public void Buscar(string nombrecompleto,string identidad,string rtn)
        {
            this.NullParametrosBusqueda();
            this.ValorParametrosBusqueda("nombrecompleto", nombrecompleto);
            this.ValorParametrosBusqueda("nombrecompleto", nombrecompleto);
            this.ValorParametrosBusqueda("nombrecompleto", nombrecompleto);

            LlenadoTabla(this.ColeccionParametrosBusqueda); 
            
        }

        public  override void  Guardar()
        {
            this.NullParametrosMantenimiento(); 
            this.ValorParametrosMantenimiento("entidadnombre", this.NombreCompleto.ToUpperInvariant());
            this.ValorParametrosMantenimiento("identificacion", this.identificacion );
            this.ValorParametrosMantenimiento("tipoIdentidad", this.tipoidentidad);           
            base.Guardar();
        }
        
        
        #endregion

    }
}
