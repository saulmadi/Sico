using SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Servicios.TiposFacturas;
using SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Entidades;
using SicoWeb.Plumbing;

namespace SicoWeb.Controllers
{
    public  class TiposFacturasController: ControllerMantenimientos<EntidadServicioMantenimiento>
    {
      public TiposFacturasController(IServicioMantenimientosTiposFacturas servicio):base (servicio)
        {
           
            Editable = false;
            Eliminable = false;
            Agregable = false;
        }

        //
        // GET: /TiposFacturas/

       

        public override string Title()
        {
            return "Tipos de Facturas";
        }
      
    }
}
