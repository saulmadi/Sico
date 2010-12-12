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

        public bool espersonanatural
        {
            get
            {
                return _espersonanatural;
            }
        }

        #endregion                

        #region Metodos

        protected override  void CargadoPropiedades()
        {
            if (this.TotalRegistros > 0)
            {
               
                telefono = (int)PrimerRegistro("telefono");                
                direccion = PrimerRegistro("direccion").ToString();
                correo = PrimerRegistro("correo").ToString();
                rtn = (string)PrimerRegistro("RTN");
                base.CargadoPropiedades();
            }
           

 
        }       

        public override void Guardar()
        {
            this.ValorParametrosMantenimiento("telefono", this.telefono);
            this.ValorParametrosMantenimiento("direccion", this.direccion);
            this.ValorParametrosMantenimiento("correo", this.correo);
            this.ValorParametrosMantenimiento("rtn", this.rtn);
            this.ValorParametrosMantenimiento("espersonanatural", this.espersonanatural);
            base.Guardar(); 
        }

        #endregion       

    }
}
