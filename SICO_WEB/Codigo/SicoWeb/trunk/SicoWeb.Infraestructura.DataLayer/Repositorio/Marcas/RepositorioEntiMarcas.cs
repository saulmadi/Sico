using System;
using NHibernate;
using SicoWeb.Dominio.Core.Entidades.Mantenimientos;
using SicoWeb.Dominio.Core.Repositorio.Mantenimientos.Marcas;

namespace SicoWeb.Infraestructura.DataLayer.Repositorio.Marcas
{
    public class RepositorioEntiMarcas:ARepositorioMantenimientosComplejos<EntiMarcas,EntiModelos>,IRepositorioEntiMarcas
    {
        public RepositorioEntiMarcas(ISession session, ISessionFactory factory) : base(session, factory)
        {
        }


        
    }
}