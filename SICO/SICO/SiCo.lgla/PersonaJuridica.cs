using System;
using System.Collections.Generic;
using System.Text;

namespace SiCo.lgla
{
    public class PersonaJuridica:Entidades 
    {
       
        #region Declaraciones
        #endregion

        #region Constructor
        public PersonaJuridica():base()
        {
            this.ComandoSelect = "PersonaJuridica_Buscar";
            this._espersonanatural = false;

            this.ColeccionParametrosBusqueda.Add(new Parametro("razonsocial",null));
            this.ColeccionParametrosBusqueda.Add(new Parametro("rtn", null));  
            

        }
        #endregion

        #region Propiedades
        public string RazonSocial
        {
            get;
            set;
        }
        #endregion
        
        #region Metodos
        protected override void CargadoPropiedades()
        {
            this.RazonSocial = this.PrimerRegistro("razonsocial").ToString() ; 
            
            base.CargadoPropiedades();
        }

        public override void Guardar()
        {
            this.NullParametrosMantenimiento();
            this.ValorParametrosMantenimiento("entidadnombre", this.RazonSocial);

            base.Guardar();
        }

        public  void Buscar(string RazonSocial,string rtn) 
        {
            this.NullParametrosBusqueda();
            this.ValorParametrosBusqueda("razonsocial", RazonSocial);
            this.ValorParametrosBusqueda("rtn", rtn); 
            base.Buscar();
        }

        #endregion

        
    }
}
