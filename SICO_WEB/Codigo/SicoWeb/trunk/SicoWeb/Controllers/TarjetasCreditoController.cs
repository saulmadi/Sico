using SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Entidades;
using SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Servicios.TarjetaCredito;

namespace SicoWeb.Controllers
{
    public class TarjetasCreditoController:Plumbing.ControllerMantenimientos<EntidadServicioMantenimiento>
    {
         public TarjetasCreditoController(IServicioMantenimientosTarjetaCredito servicio) : base(servicio)
        {
        }

        public override string Title()
        {
            return "Tarjetas de Credito";
        }
    }
}