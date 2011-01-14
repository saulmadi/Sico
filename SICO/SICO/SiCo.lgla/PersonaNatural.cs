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
        public PersonaNatural(long? id, string NombreCompleto,TipoIdentidad TipoIdentidad, string Identificacion,string correo, string direccion, string rtn , int? Telefono,int? telefono2):base( )
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
            this.telefono2 = telefono2; 


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

        public string NombreCompletoMostrar
        {
            get
            {
                return NombreCompleto.Replace("@", " "); 
            } 
        }

        #endregion        
        
        #region Metodos

        protected override void CargadoPropiedades(int Indice)
        {
            if (this.TotalRegistros > 0)
            {
                this.NombreCompleto = this.Registro(Indice,"NombreCompleto").ToString() ;                
                this.identificacion = this.Registro(Indice,"identificacion").ToString();
                if (Registro(Indice,"tipo").ToString() == "I")
                    this.tipoidentidad = new TipoIdentidad("Identidad", "I");
                else if (Registro(Indice,"tipo").ToString() == "R")
                    this.tipoidentidad = new TipoIdentidad("Residencia", "R");                
                base.CargadoPropiedades( Indice);                
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

        public static string CrearNombreCompleto(string NombreCompleto, ref string PrimerNombre, ref string SegundoNombre, ref string PrimerApellido, ref string SegundoApellido)
        {
            
            if (NombreCompleto != string.Empty)
            {
                if (NombreCompleto.Contains(" "))
                {
                    string[] Nombre;
                    Nombre = NombreCompleto.Split(' ');                    
                    PrimerNombre = Nombre[0];
                    SegundoNombre = Nombre [1];
                    PrimerApellido =Nombre[2];
                    SegundoApellido = Nombre[3];
                }
                else
                {
                    PrimerNombre = NombreCompleto;
                
                }
                return NombreCompleto;
            }
            else 
            {
                return PrimerNombre.Trim()  + " "+ SegundoNombre.Trim() + " " + PrimerApellido .Trim()+" "+SegundoApellido.Trim();   
            }


        }

        public  override void  Guardar()
        {
            this.NullParametrosMantenimiento(); 
            this.ValorParametrosMantenimiento("entidadnombre", this.NombreCompleto.ToUpperInvariant());
            this.ValorParametrosMantenimiento("identificacion", this.identificacion );
            this.ValorParametrosMantenimiento("tipoIdentidad", this.tipoidentidad);           
            base.Guardar();
        }

        public override object TablaAColeccion()
        {
            base.TablaAColeccion();
            List<PersonaNatural> lista = new List<PersonaNatural>();
            for (int i = 0; i < this.TotalRegistros - 1; i++)
            {
                this.CargadoPropiedades(i);
                PersonaNatural pntemp = new PersonaNatural(this._Id, this.NombreCompleto, this.tipoidentidad,this.identificacion , this.correo, this.direccion, this.rtn, this.telefono,this.telefono2);
                
            }
            return lista; 
        }
        
        #endregion

    }
}
