using SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Entidades;

namespace SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Servicios.Municipios
{
    public interface IServicioMantenimientoHijoMunicipios :
        IServicioMantenimientoHijo<EntidadServicioMantenimientoHijo<EntidadServicioMantenimiento >, EntidadServicioMantenimiento>
        
    {
    }
}