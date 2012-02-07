using SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Entidades;
using SicoWeb.Dominio.Core.Entidades.Mantenimientos;
using SicoWeb.Dominio.Core.Querys.Mantenimientos.Marcas;
using SicoWeb.Dominio.Core.Repositorio.Mantenimientos.Marcas;
using SicoWeb.Dominio.Core.Transaction;
using SicoWeb.Dominio.Core.BuisnessRules.Mantenimientos;

namespace SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Servicios.Marcas
{
    public class ServicioMantenimientosMarcas:
        AServicioMantenimiento<EntidadServicioMantenimiento, EntiMarcas>, IServicioMantenimientosMarcas
    {
        public ServicioMantenimientosMarcas(IRepositorioEntiMarcas repositorioMantimientos,
                                                     IEntiMantenimientosFactory entiMantenimientosFactory,
                                                     IQueryDeshabilitadoMarca queryDeshabilitado,
                                                     IQueryHabilitadoMarca queryHabilitado,
                                                     IUnitOfWork unitOfWork,
                                                     IBuisnessRulesMannagerMantenimientos<EntiMarcas>
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