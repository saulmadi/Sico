using SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Entidades;
using SicoWeb.Dominio.Core.Entidades.Mantenimientos;
using SicoWeb.Dominio.Core.Querys.Mantenimientos.TiposMotocicletas;
using SicoWeb.Dominio.Core.Repositorio.Mantenimientos.TiposMotocicletas;
using SicoWeb.Dominio.Core.Transaction;
using SicoWeb.Dominio.Core.BuisnessRules.Mantenimientos ;

namespace SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Servicios.TiposMotocicletas
{
    public class ServicioMantenimientosTiposMotocicletas :
        AServicioMantenimiento<EntidadServicioMantenimiento, EntiTiposmotocicletas>,
        IServicioMantenimientosTiposMotocicletas
    {
        public ServicioMantenimientosTiposMotocicletas(IRepositorioEntiTiposMotociletas repositorioMantimientos,
                                                       IEntiMantenimientosFactory entiMantenimientosFactory,
                                                       IQueryDeshabilitadoTiposMotocicletas queryDeshabilitado,
                                                       IQueryHabilitadoTiposMotocicletas queryHabilitado,
                                                       IUnitOfWork unitOfWork,
                                                       IBuisnessRulesMannagerMantenimientos<EntiTiposmotocicletas>
                                                           buisnessRulesMannagerMantenimientos) :
                                                               base(
                                                               repositorioMantimientos, entiMantenimientosFactory,
                                                               queryDeshabilitado, queryHabilitado, unitOfWork,
                                                               buisnessRulesMannagerMantenimientos)
        {
        }
    }
}