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
            this.ColeccionParametrosBusqueda.Add(new Parametro("tipoidentificacion", null));
            this.ColeccionParametrosBusqueda.Add(new Parametro("nombrecompletoigual", null)); 
            this.ColeccionParametrosBusqueda.Add(new Parametro("rtn",null));
            this.tipoidentidad.Valor = "I";
            
        }
        public PersonaNatural(long? id, string NombreCompleto,TipoIdentidad TipoIdentidad, string Identificacion,string correo, string direccion, string rtn , int? Telefono,int? telefono2):base( )
        {
            this.ComandoSelect = "PersonaNatural_buscar";
            this._espersonanatural = true;
            this.ColeccionParametrosBusqueda.Add(new Parametro("nombrecompleto", null));
            this.ColeccionParametrosBusqueda.Add(new Parametro("identificacion", null));
            this.ColeccionParametrosBusqueda.Add(new Parametro("tipoidentificacion", null));
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

        public string IdentificacionMostrar
        {
            get 
            {
                if (this.tipoidentidad.Valor == "N")
                    return string.Empty;
                else
                    return this.identificacion;
            } 
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
                return NombreCompleto.Replace("@", "").Replace("%","").Replace("&","").Replace("$","")   ; 
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
                if (Registro(Indice,"tipoidentidad").ToString() == "I")
                    this.tipoidentidad = new TipoIdentidad("Identidad", "I");
                else if (Registro(Indice, "tipoidentidad").ToString() == "R")
                    this.tipoidentidad = new TipoIdentidad("Residencia", "R");     
                else if (Registro (Indice,"tipoidentidad").ToString() == "N")
                    this.tipoidentidad = new TipoIdentidad("N");     
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
                if (NombreCompleto.EndsWith("@"))
                {
                    string[] Nombre;
                    Nombre = NombreCompleto.Replace("@","") .Split(' ');                    
                    PrimerNombre = Nombre[0];                    
                    PrimerApellido =Nombre[1];
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
                    return PrimerNombre.Trim() + " " + PrimerApellido.Trim() +" " + SegundoApellido.Trim() + "$";
                }

                if (SegundoApellido.Trim() == string.Empty && SegundoNombre.Trim() != string.Empty)
                {
                    return PrimerNombre.Trim()+" "+ SegundoNombre.Trim()  + " " + PrimerApellido.Trim() + "%";
                }

                if (SegundoApellido.Trim() != string.Empty && SegundoNombre.Trim() != string.Empty)
                {
                    return PrimerNombre.Trim() + " " + SegundoNombre.Trim() + " " + PrimerApellido.Trim()+" " + SegundoApellido.Trim()  + "&";
                }
                throw new ApplicationException("El nombre completo no puede ser creado dado que la persona tiene que tener un nombre y un apellido"); 
            }


        }

        public  override void  Guardar()
        {
            this.NullParametrosMantenimiento(); 
            this.ValorParametrosMantenimiento("entidadnombre", this.NombreCompleto);
            this.ValorParametrosMantenimiento("identificacion", this.identificacion );
            this.ValorParametrosMantenimiento("tipoIdentidad", this.tipoidentidad.Valor );           
            base.Guardar();
        }

        public override object TablaAColeccion()
        {
            base.TablaAColeccion();
            List<PersonaNatural> lista = new List<PersonaNatural>();
            for (int i = 0; i < this.TotalRegistros ; i++)
            {
                this.CargadoPropiedades(i);
                PersonaNatural pntemp = new PersonaNatural(this._Id, this.NombreCompleto, this.tipoidentidad,this.identificacion , this.correo, this.direccion, this.rtn, this.telefono,this.telefono2);
                lista.Add(pntemp);
            }
            return lista; 
        }
        
        #endregion
    }
}
