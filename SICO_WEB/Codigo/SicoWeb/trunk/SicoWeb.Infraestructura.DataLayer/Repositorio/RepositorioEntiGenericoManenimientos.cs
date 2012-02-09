using NHibernate;
using SicoWeb.Dominio.Core.Entidades.Mantenimientos;
using SicoWeb.Dominio.Core.Repositorio.Mantenimientos;

namespace SicoWeb.Infraestructura.DataLayer.Repositorio
{
    public class RepositorioEntiGenericoManenimientos<TEnti> : RepositorioEntiGenerico<TEnti>, IRepositorioMantimientos<TEnti> 
        where TEnti : class, IEntiMantenimientos
    {
        public RepositorioEntiGenericoManenimientos(ISession session, ISessionFactory factory) : base(session, factory)
        {
        }
    }
}