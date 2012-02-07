using SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Entidades;
using SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Servicios.Marcas;

namespace SicoWeb.Controllers
{
    public class MarcasController : Plumbing.ControllerMantenimientos<EntidadServicioMantenimiento>
    {
        public MarcasController(IServicioMantenimientosMarcas servicio)
            : base(servicio)
        {
        }

        public override string Title()
        {
            return "Marcas";
        }
    }
}