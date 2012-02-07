using SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Entidades;
using SicoWeb.Dominio.Core.Entidades.Mantenimientos;
using SicoWeb.Dominio.Core.Querys.Mantenimientos.Departamentos;
using SicoWeb.Dominio.Core.Repositorio.Mantenimientos.Departamentos;
using SicoWeb.Dominio.Core.Transaction;
using SicoWeb.Dominio.Core.BuisnessRules.Mantenimientos;

namespace SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Servicios.Departamentos
{
    public class ServicioMantenimientosDepartamentos :
        AServicioMantenimiento<EntidadServicioMantenimiento, EntiDepartamentos>, IServicioMantenimientosDepartamentos
    {
        public ServicioMantenimientosDepartamentos(IRepositorioEntiDepartamentos repositorioMantimientos,
                                                   IEntiMantenimientosFactory entiMantenimientosFactory,
                                                   IQueryDeshabilitadoDepartamentos queryDeshabilitado,
                                                   IQueryHabilitadoDepartamentos queryHabilitado,
                                                   IUnitOfWork unitOfWork,
                                                   IBuisnessRulesMannagerMantenimientos<EntiDepartamentos>
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