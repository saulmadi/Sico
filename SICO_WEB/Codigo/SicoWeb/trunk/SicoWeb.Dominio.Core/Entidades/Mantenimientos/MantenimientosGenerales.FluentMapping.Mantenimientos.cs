//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using NHibernate Fluent Mapping template.
// Code is generated on: 21/01/2012 10:48:48 p.m.
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
using FluentNHibernate.Mapping;
using FluentNHibernate.MappingModel.Collections;

namespace SicoWeb.Dominio.Core.Entidades.Mantenimientos
{
    public class MantenimientosMap : ClassMap<Mantenimientos>
    {
        public MantenimientosMap()
        {
              Table("Mantenimientos");
              LazyLoad();
              Id(x => x.Id)
                .Column("Id")
                .CustomType("Int32")
                .Access.Property()                
                .GeneratedBy.Increment();
              DiscriminateSubClassesOnColumn("Class", @"AMantenimientos").Not.Nullable();
              Map(x => x.Descripcion)
        .Column("Descripcion")
        .CustomType("String")
        .Access.Property()
        .Generated.Never();
              Map(x => x.Habilitado)
        .Column("Habilitado")
        .CustomType("Boolean")
        .Access.Property()
        .Generated.Never();
              Map(x => x.Usu)
        .Column("Usu")
        .CustomType("Int32")
        .Access.Property()
        .Generated.Never();
              Map(x => x.Fmodif)
        .Column("Fmodif")
        .CustomType("DateTime")
        .Access.Property()
        .Generated.Never();
        }
    }

}
