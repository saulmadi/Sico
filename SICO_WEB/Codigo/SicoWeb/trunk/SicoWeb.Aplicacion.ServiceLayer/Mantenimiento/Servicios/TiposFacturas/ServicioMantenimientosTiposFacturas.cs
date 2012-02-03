using SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Entidades;
using SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Servicios.TiposMotocicletas;

using SicoWeb.Dominio.Core.Entidades.Mantenimientos;
using SicoWeb.Dominio.Core.Querys.Mantenimientos.TiposFacturas;
using SicoWeb.Dominio.Core.Repositorio.Mantenimientos.TiposFacturas;
using SicoWeb.Dominio.Core.Transaction;

namespace SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Servicios.TiposFacturas
{
    public class ServicioMantenimientosTiposFacturas :
        AServicioMantenimiento<EntidadServicioMantenimiento, EntiTiposfacturas>, IServicioMantenimientosTiposFacturas
    {
        public ServicioMantenimientosTiposFacturas(IRepositorioEntiTiposFacturas repositorioMantimientos,
                                                   IEntiMantenimientosFactory entiMantenimientosFactory,
                                                   IQueryDeshabilitadoTiposFactura queryDeshabilitado,
                                                   IQueryHabilitadoTiposFactura queryHabilitado,
                                                   IUnitOfWork unitOfWork) :
                                                       base(
                                                       repositorioMantimientos, entiMantenimientosFactory,
                                                       queryDeshabilitado, queryHabilitado, unitOfWork)
        {
        }
    }
}