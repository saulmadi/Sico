using NHibernate;
using SicoWeb.Dominio.Core.Entidades.Mantenimientos;
using SicoWeb.Dominio.Core.Repositorio.Mantenimientos;
using SicoWeb.Dominio.Core.Transaction;

namespace SicoWeb.Infraestructura.DataLayer.Repositorio
{
    public class RepositorioEntiGenericoManenimientos<TEnti> : RepositorioEntiGenerico<TEnti>, IRepositorioMantimientos<TEnti> 
        where TEnti : class, IEntiMantenimientos
    {
        public RepositorioEntiGenericoManenimientos(ISessionMannager sessionMannager)
            : base(sessionMannager)
        {
        }
    }
}