using NHibernate;
using SicoWeb.Dominio.Core.Entidades.Mantenimientos;
using SicoWeb.Dominio.Core.Repositorio.Mantenimientos.TiposFacturas;
using SicoWeb.Dominio.Core.Transaction;

namespace SicoWeb.Infraestructura.DataLayer.Repositorio.TiposFacturas
{
    public class RepositorioEntiTiposFacturas:ARepository<EntiTiposfacturas>, IRepositorioEntiTiposFacturas
    {
        public RepositorioEntiTiposFacturas(ISessionMannager sessionMannager)
            : base(sessionMannager)
        {
        }
    }
}