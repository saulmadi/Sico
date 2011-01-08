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
        public PersonaJuridica(Int32 id, string RazonSocial,string correo, string direccion, string rtn , int Telefono):base()         
        {
            this.ComandoSelect = "PersonaJuridica_Buscar";
            this._espersonanatural = false;

            this.ColeccionParametrosBusqueda.Add(new Parametro("razonsocial", null));
            this.ColeccionParametrosBusqueda.Add(new Parametro("rtn", null));

            this._Id=id;
            this.RazonSocial=RazonSocial ;            
            this.correo = correo;
            this.direccion = direccion;
            this.rtn = rtn;
            this.telefono = Telefono;
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
        protected override void CargadoPropiedades(int Indice)
        {
            this.RazonSocial = this.Registro(Indice,"razonsocial").ToString() ; 
            
            base.CargadoPropiedades( Indice);
        }

        public override void Guardar()
        {
            this.NullParametrosMantenimiento();
            this.ValorParametrosMantenimiento("entidadnombre", this.RazonSocial.ToUpperInvariant() );

            base.Guardar();
        }

        public  void Buscar(string RazonSocial,string rtn,bool t) 
        {
            this.NullParametrosBusqueda();
            this.ValorParametrosBusqueda("razonsocial", RazonSocial);
            this.ValorParametrosBusqueda("rtn", rtn); 
            base.Buscar();
        }

        #endregion
        
    }
}
