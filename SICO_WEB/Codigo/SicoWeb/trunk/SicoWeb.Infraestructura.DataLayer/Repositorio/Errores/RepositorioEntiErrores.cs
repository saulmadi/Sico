using NHibernate;
using SicoWeb.Dominio.Core.Entidades.Errores;
using SicoWeb.Dominio.Core.Repositorio.Errores;
using SicoWeb.Dominio.Core.Transaction;

namespace SicoWeb.Infraestructura.DataLayer.Repositorio.Errores
{
    public class RepositorioEntiErrores:ARepository<EntiErrores>, IRepositorioEntiErrores
    {
        public RepositorioEntiErrores(ISessionMannager sessionMannager ) : base(sessionMannager)
        {
        }
    }
}