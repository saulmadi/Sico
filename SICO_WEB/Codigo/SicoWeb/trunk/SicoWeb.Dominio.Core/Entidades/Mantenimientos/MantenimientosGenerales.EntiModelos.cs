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
    /// There are no comments for SicoWeb.Dominio.Core.Entidades.Mantenimientos.EntiModelos in the schema.
    /// </summary>
    public partial class EntiModelos : Mantenimientos {

        private string _Imagen;

        private EntiMarcas _EntiMarcas;
    
        #region Extensibility Method Definitions
        
        partial void OnCreated();
        
        #endregion

        public EntiModelos()
        {
            OnCreated();
        }

    
    /// <summary>
    /// There are no comments for Imagen in the schema.
    /// </summary>
        public virtual string Imagen
        {
            get
            {
                return this._Imagen;
            }
            set
            {
                this._Imagen = value;
            }
        }

        public virtual EntiMarcas EntiMarcas
        {
            get
            {
                return this._EntiMarcas;
            }
            set
            {
                this._EntiMarcas = value;
            }
        }
    }

}
