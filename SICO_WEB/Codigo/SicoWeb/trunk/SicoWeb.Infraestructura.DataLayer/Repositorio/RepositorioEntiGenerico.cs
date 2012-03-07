using NHibernate;
using SicoWeb.Dominio.Core.Entidades;
using SicoWeb.Dominio.Core.Transaction;

namespace SicoWeb.Infraestructura.DataLayer.Repositorio
{
    public class RepositorioEntiGenerico<TEnti>:ARepository<TEnti> where TEnti : class, IEntiBase
    {
        public RepositorioEntiGenerico(ISessionMannager sessionMannager)
            : base(sessionMannager)
        {
        }
    }
}