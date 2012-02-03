using NHibernate;
using SicoWeb.Dominio.Core.Entidades.Mantenimientos;
using SicoWeb.Dominio.Core.Repositorio.Mantenimientos.TiposFacturas;

namespace SicoWeb.Infraestructura.DataLayer.Repositorio.TiposFacturas
{
    public class RepositorioEntiTiposFacturas:ARepository<EntiTiposfacturas>, IRepositorioEntiTiposFacturas
    {
        public RepositorioEntiTiposFacturas(ISession session, ISessionFactory factory) : base(session, factory)
        {
        }
    }
}