using SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Entidades;
using SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Servicios.Departamentos ;
using SicoWeb.Plumbing;
namespace SicoWeb.Controllers
{
    public class DepartamentosController:ControllerMantenimientos<EntidadServicioMantenimiento>
    {
        public DepartamentosController( IServicioMantenimientosDepartamentos servicio) : base(servicio)
        {
        }

        public override string Title()
        {
            return "Departamentos";
        }
    }
}