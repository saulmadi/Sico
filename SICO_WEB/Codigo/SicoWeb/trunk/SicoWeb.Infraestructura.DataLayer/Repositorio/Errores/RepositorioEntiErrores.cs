using NHibernate;
using SicoWeb.Dominio.Core.Entidades.Errores;
using SicoWeb.Dominio.Core.Repositorio.Errores;

namespace SicoWeb.Infraestructura.DataLayer.Repositorio.Errores
{
    public class RepositorioEntiErrores:ARepository<EntiErrores>, IRepositorioEntiErrores
    {
        public RepositorioEntiErrores(ISession session, ISessionFactory factory) : base(session, factory)
        {
        }
    }
}