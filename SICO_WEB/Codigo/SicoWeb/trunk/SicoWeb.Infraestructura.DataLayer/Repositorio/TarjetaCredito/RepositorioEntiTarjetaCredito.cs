using NHibernate;
using SicoWeb.Dominio.Core.Entidades.Mantenimientos;
using SicoWeb.Dominio.Core.Repositorio.Mantenimientos.TarjetaCredito;

namespace SicoWeb.Infraestructura.DataLayer.Repositorio.TarjetaCredito
{
    public class RepositorioEntiTarjetaCredito:ARepository<EntiTarjetacredito>, IRepositorioEntiTarjetaCredito
    {
        public RepositorioEntiTarjetaCredito(ISession session, ISessionFactory factory) : base(session, factory)
        {
        }
    }
}