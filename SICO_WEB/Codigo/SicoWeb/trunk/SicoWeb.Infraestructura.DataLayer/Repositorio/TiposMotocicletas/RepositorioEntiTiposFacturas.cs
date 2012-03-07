using NHibernate;

using SicoWeb.Dominio.Core.Entidades.Mantenimientos;
using SicoWeb.Dominio.Core.Repositorio.Mantenimientos.TiposMotocicletas;
using SicoWeb.Dominio.Core.Transaction;

namespace SicoWeb.Infraestructura.DataLayer.Repositorio.TiposMotocicletas
{
    public class RepositorioEntiTiposMotocicletas : ARepository<EntiTiposmotocicletas>,IRepositorioEntiTiposMotociletas
    {
        public RepositorioEntiTiposMotocicletas(ISessionMannager sessionMannager)
            : base(sessionMannager)
        {
        }
    }
}