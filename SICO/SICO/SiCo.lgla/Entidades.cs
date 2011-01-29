using System;
using System.Collections.Generic;
using System.Text;

namespace SiCo.lgla
{
    public abstract class Entidades : Entidad
    {
        
        #region Declaraciones
        protected bool _espersonanatural= true ;

        #endregion

        #region Constructores

        public Entidades():base()
        {
            this.ComandoMantenimiento = "Entidades_Mant";  

            this.ColeccionParametrosMantenimiento.Add (new Parametro("telefono",null));
            this.ColeccionParametrosMantenimiento.Add(new Parametro("direccion", null));
            this.ColeccionParametrosMantenimiento.Add(new Parametro("correo", null));
            this.ColeccionParametrosMantenimiento.Add(new Parametro("espersonanatural", null));
            this.ColeccionParametrosMantenimiento.Add(new Parametro("rtn", null));
            this.ColeccionParametrosMantenimiento.Add(new Parametro("entidadnombre", null));
            this.ColeccionParametrosMantenimiento.Add(new Parametro("identificacion", null));
            this.ColeccionParametrosMantenimiento.Add(new Parametro("tipoIdentidad", null));
            this.ColeccionParametrosMantenimiento.Add(new Parametro("telefono2", null));
            this.TablaEliminar = "entidades";
            
        }       

        #endregion

        #region Propiedades

        public int? telefono
        {
            get;
            set;
        }

        public string direccion
        {
            get;
            set;
        }

        public string correo
        {
            get;
            set;
        }

        public string  rtn
        {
            get;
            set;
        }

        public int? telefono2
        {
            get;
            set;
        }

        public bool espersonanatural
        {
            get
            {
                return _espersonanatural;
            }
        }

        #endregion                

        #region Metodos

        protected override  void CargadoPropiedades(int indice)
        {
            if (this.TotalRegistros > 0)
            {
               
                telefono = (int?) Registro (indice ,"telefono");                
                direccion =(string)Registro(indice ,"direccion");
                correo =(string)  Registro(indice,"correo");
                rtn = (string)Registro(indice,"RTN");
                telefono2 = (int?)Registro(indice, "telefono2"); 
                base.CargadoPropiedades(indice);
            }
           

 
        }       

        public override void Guardar()
        {
            this.ValorParametrosMantenimiento("telefono", this.telefono);
            this.ValorParametrosMantenimiento("direccion", this.direccion);
            this.ValorParametrosMantenimiento("correo", this.correo);
            this.ValorParametrosMantenimiento("rtn", this.rtn);
            this.ValorParametrosMantenimiento("espersonanatural", this.espersonanatural);
            this.ValorParametrosMantenimiento("telefono2", this.telefono2); 
            base.Guardar(); 
        }

        #endregion       

    }
}
