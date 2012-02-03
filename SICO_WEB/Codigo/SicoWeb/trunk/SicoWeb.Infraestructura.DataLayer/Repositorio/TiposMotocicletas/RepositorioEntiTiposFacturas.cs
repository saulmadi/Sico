using NHibernate;

using SicoWeb.Dominio.Core.Entidades.Mantenimientos;
using SicoWeb.Dominio.Core.Repositorio.Mantenimientos.TiposMotocicletas;

namespace SicoWeb.Infraestructura.DataLayer.Repositorio.TiposMotocicletas
{
    public class RepositorioEntiTiposMotocicletas : ARepository<EntiTiposmotocicletas>,IRepositorioEntiTiposMotociletas
    {
        public RepositorioEntiTiposMotocicletas(ISession session, ISessionFactory factory) : base(session, factory)
        {
        }
    }
}