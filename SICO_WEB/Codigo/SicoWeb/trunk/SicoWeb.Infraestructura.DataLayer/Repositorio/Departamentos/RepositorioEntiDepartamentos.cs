using NHibernate;
using SicoWeb.Dominio.Core.Entidades.Mantenimientos;
using SicoWeb.Dominio.Core.Repositorio.Mantenimientos.Departamentos;
namespace SicoWeb.Infraestructura.DataLayer.Repositorio.Departamentos
{
    public class RepositorioEntiDepartamentos:ARepositorioMantenimientosComplejos<EntiDepartamentos,EntiMunicipio>, IRepositorioEntiDepartamentos
    {
        public RepositorioEntiDepartamentos(ISession session, ISessionFactory factory) : base(session, factory)
        {
        }
    }
}