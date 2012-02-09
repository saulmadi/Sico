using NHibernate;
using SicoWeb.Dominio.Core.Entidades;

namespace SicoWeb.Infraestructura.DataLayer.Repositorio
{
    public class RepositorioEntiGenerico<TEnti>:ARepository<TEnti> where TEnti : class, IEntiBase
    {
        public RepositorioEntiGenerico(ISession session, ISessionFactory factory) : base(session, factory)
        {
        }
    }
}