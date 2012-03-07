using SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Entidades;
using SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Servicios.Marcas;
using SicoWeb.Dominio.Core.BuisnessRules.Mantenimientos;
using SicoWeb.Dominio.Core.Entidades.Mantenimientos;
using SicoWeb.Dominio.Core.Querys.Mantenimientos;
using SicoWeb.Dominio.Core.Repositorio;
using SicoWeb.Dominio.Core.Repositorio.Mantenimientos;
using SicoWeb.Dominio.Core.Transaction;

namespace SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Servicios.Modelos
{
    public class ServicioMantenimientoHijoModelos :
        AServicioMantenimientoHijo
            <EntidadServicioMantenimientoHijo<EntidadServicioMantenimiento>, EntidadServicioMantenimiento, EntiModelos,EntiMarcas>,
        IServicioMantenimientoHijoModelos

    {
        public ServicioMantenimientoHijoModelos(IRepositorioMantimientos<EntiModelos> repositorioMantimientos,
                                                IEntiMantenimientosFactory entiMantenimientosFactory,
                                                IQueryDeshabilitado<EntiModelos> queryDeshabilitado,
                                                IQueryHabilitado<EntiModelos> queryHabilitado,
                                                IUnitOfWork unitOfWork,
                                                IBuisnessRulesMannagerMantenimientos<EntiModelos>
                                                    buisnessRulesMannagerMantenimientos,
                                                IServicioMantenimientosMarcas 
                                                    servicioMantenimiento,
                                                   IRepositorioMantimientos<EntiMarcas> repositorioMantimientosPadres )
            : base(
                repositorioMantimientos, entiMantenimientosFactory, queryDeshabilitado, queryHabilitado, unitOfWork,
                buisnessRulesMannagerMantenimientos, servicioMantenimiento, repositorioMantimientosPadres)
        {
        }
    }
}