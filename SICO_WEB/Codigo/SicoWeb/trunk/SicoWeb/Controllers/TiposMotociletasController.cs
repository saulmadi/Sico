using SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Entidades;
using SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Servicios.TiposMotocicletas ;
using SicoWeb.Plumbing;

namespace SicoWeb.Controllers
{
    public class TiposMotociletasController : ControllerMantenimientos<EntidadServicioMantenimiento>
    {
        public TiposMotociletasController(IServicioMantenimientosTiposMotocicletas servicio) : base(servicio)
        {
            
        }

        public override string Title()
        {
            return "Tipos Motocicletas";
        }
    }
}