//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using NHibernate template.
// Code is generated on: 05/03/2012 11:35:52 p.m.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace SicoWeb.Dominio.Core.Entidades.Mantenimientos
{

    /// <summary>
    /// There are no comments for SicoWeb.Dominio.Core.Entidades.Mantenimientos.EntiDepartamentos in the schema.
    /// </summary>
    public partial class EntiDepartamentos : Mantenimientos {

        private IList<EntiMunicipio> _EntiMunicipios;
    
        #region Extensibility Method Definitions
        
        partial void OnCreated();
        
        #endregion

        public EntiDepartamentos()
        {
            this._EntiMunicipios = new List<EntiMunicipio>();
            OnCreated();
        }

        public virtual IList<EntiMunicipio> EntiMunicipios
        {
            get
            {
                return this._EntiMunicipios;
            }
            set
            {
                this._EntiMunicipios = value;
            }
        }
    }

}
