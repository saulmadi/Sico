using NHibernate;
using SicoWeb.Dominio.Core.Entidades.Mantenimientos;
using SicoWeb.Dominio.Core.Repositorio.Mantenimientos.Departamentos;
using SicoWeb.Dominio.Core.Transaction;

namespace SicoWeb.Infraestructura.DataLayer.Repositorio.Departamentos
{
    public class RepositorioEntiDepartamentos:ARepositorioMantenimientosComplejos<EntiDepartamentos,EntiMunicipio>, IRepositorioEntiDepartamentos
    {
        public RepositorioEntiDepartamentos(ISessionMannager sessionMannager)
            : base(sessionMannager)
        {
        }
    }
}