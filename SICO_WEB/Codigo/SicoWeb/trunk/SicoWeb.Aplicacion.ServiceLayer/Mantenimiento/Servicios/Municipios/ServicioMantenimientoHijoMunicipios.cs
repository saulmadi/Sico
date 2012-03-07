using SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Entidades;
using SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Servicios.Departamentos;
using SicoWeb.Dominio.Core.BuisnessRules.Mantenimientos;
using SicoWeb.Dominio.Core.Entidades.Mantenimientos;
using SicoWeb.Dominio.Core.Querys.Mantenimientos;
using SicoWeb.Dominio.Core.Repositorio.Mantenimientos;
using SicoWeb.Dominio.Core.Transaction;

namespace SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Servicios.Municipios
{
    public class ServicioMantenimientoHijoMunicipios :
        AServicioMantenimientoHijo
            <EntidadServicioMantenimientoHijo<EntidadServicioMantenimiento>, EntidadServicioMantenimiento, EntiMunicipio,EntiDepartamentos>,
        IServicioMantenimientoHijoMunicipios

    {
        public ServicioMantenimientoHijoMunicipios(IRepositorioMantimientos<EntiMunicipio> repositorioMantimientos,
                                                IEntiMantenimientosFactory entiMantenimientosFactory,
                                                IQueryDeshabilitado<EntiMunicipio> queryDeshabilitado,
                                                IQueryHabilitado<EntiMunicipio> queryHabilitado,
                                                IUnitOfWork unitOfWork,
                                                IBuisnessRulesMannagerMantenimientos<EntiMunicipio>
                                                    buisnessRulesMannagerMantenimientos,
                                                IServicioMantenimientosDepartamentos
                                                    servicioMantenimiento,IRepositorioMantimientos<EntiDepartamentos > repositorioMantimientosPadre) : base(
                repositorioMantimientos, entiMantenimientosFactory, queryDeshabilitado, queryHabilitado, unitOfWork,
                buisnessRulesMannagerMantenimientos, servicioMantenimiento,repositorioMantimientosPadre)
        {
        }
    }
}