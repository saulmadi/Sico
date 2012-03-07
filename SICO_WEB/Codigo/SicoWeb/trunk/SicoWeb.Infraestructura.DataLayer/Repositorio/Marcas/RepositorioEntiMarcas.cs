using System;
using NHibernate;
using SicoWeb.Dominio.Core.Entidades.Mantenimientos;
using SicoWeb.Dominio.Core.Repositorio.Mantenimientos.Marcas;
using SicoWeb.Dominio.Core.Transaction;

namespace SicoWeb.Infraestructura.DataLayer.Repositorio.Marcas
{
    public class RepositorioEntiMarcas:ARepositorioMantenimientosComplejos<EntiMarcas,EntiModelos>,IRepositorioEntiMarcas
    {
        public RepositorioEntiMarcas(ISessionMannager sessionMannager)
            : base(sessionMannager)
        {
        }


        
    }
}