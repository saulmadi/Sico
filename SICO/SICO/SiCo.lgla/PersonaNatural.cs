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
            this.ComandoMantenimiento = "PersonaNatural_Mant";
            this.ComandoSelect = "PersonaNatural_buscar";            
            
        }
        #endregion

        #region Propiedades

        public string nombre
        {
            get;
            set;
        }

        public string apellidos
        {
            get;
            set;
        }

        public string identidad
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
                this.nombre = this.PrimerRegistro("nombre").ToString() ;
                this.apellidos = this.PrimerRegistro("apellidos").ToString() ;
                this.identidad = this.PrimerRegistro("identidad").ToString();

                if (PrimerRegistro("tipo").ToString() == "I")
                    this.tipoidentidad = new TipoIdentidad("Identidad", "I");
                else if (PrimerRegistro("tipo").ToString() == "P")
                    this.tipoidentidad = new TipoIdentidad("Pasaporte", "P");
                else this.tipoidentidad = new TipoIdentidad("Menor de Edad", "M");

                
            }

            base.CargadoPropiedades();
        }

        public void Buscar(string id,string nombrecompleto,string identidad,string rtn,string nombre,string apellidos )        
        {
            Parametro[] Parametro= {new Parametro("id",id),
                                    new Parametro("nombrecompleto",nombrecompleto),
                                    new Parametro("Identidad",identidad), 
                                    new Parametro("rtn",rtn),
                                    new Parametro("nombre",nombre),
                                    new Parametro ("apellidos",apellidos) };

            LlenadoTabla(Parametro);

            this.CargadoPropiedades();             
        }

        public void Guardar()
        { }
        
        #endregion

    }
}
