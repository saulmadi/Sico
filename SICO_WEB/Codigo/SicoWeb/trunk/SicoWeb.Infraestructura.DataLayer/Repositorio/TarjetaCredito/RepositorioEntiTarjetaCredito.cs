using NHibernate;
using SicoWeb.Dominio.Core.Entidades.Mantenimientos;
using SicoWeb.Dominio.Core.Repositorio.Mantenimientos.TarjetaCredito;
using SicoWeb.Dominio.Core.Transaction;

namespace SicoWeb.Infraestructura.DataLayer.Repositorio.TarjetaCredito
{
    public class RepositorioEntiTarjetaCredito:ARepository<EntiTarjetacredito>, IRepositorioEntiTarjetaCredito
    {
        public RepositorioEntiTarjetaCredito(ISessionMannager sessionMannager)
            : base(sessionMannager)
        {
        }
    }
}