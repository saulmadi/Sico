using SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Entidades;

using SicoWeb.Dominio.Core.Entidades.Mantenimientos;
using SicoWeb.Dominio.Core.Querys.Mantenimientos.TarjetasCredito;
using SicoWeb.Dominio.Core.Repositorio.Mantenimientos.TarjetaCredito;
using SicoWeb.Dominio.Core.Transaction;
using SicoWeb.Dominio.Core.BuisnessRules.Mantenimientos;

namespace SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Servicios.TarjetaCredito
{
    public class ServicioMantenimientosTarjetaCreditos :
        AServicioMantenimiento<EntidadServicioMantenimiento, EntiTarjetacredito>, IServicioMantenimientosTarjetaCredito
    {
        public ServicioMantenimientosTarjetaCreditos(IRepositorioEntiTarjetaCredito repositorioMantimientos,
                                                     IEntiMantenimientosFactory entiMantenimientosFactory,
                                                     IQueryDeshabilitadoTarjetaCredito queryDeshabilitado,
                                                     IQueryHabilitadoTarjetaCredito queryHabilitado,
                                                     IUnitOfWork unitOfWork,
                                                     IBuisnessRulesMannagerMantenimientos<EntiTarjetacredito>
                                                         buisnessRulesMannagerMantenimientos) :
                                                             base(
                                                             repositorioMantimientos,
                                                             entiMantenimientosFactory,
                                                             queryDeshabilitado,
                                                             queryHabilitado,
                                                             unitOfWork,
                                                             buisnessRulesMannagerMantenimientos)
        {
        }
    }

}