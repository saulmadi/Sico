using SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Servicios.Municipios;
using SicoWeb.Plumbing;
using SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Entidades;
namespace SicoWeb.Controllers
{
    public class MunicipiosController : ControllerMantenimientosHijo<EntidadServicioMantenimientoHijo<EntidadServicioMantenimiento>,EntidadServicioMantenimiento>
    {
        //
        // GET: /Municipios/

        public MunicipiosController(IServicioMantenimientoHijoMunicipios servicio)
            : base(servicio)
        {
        }

        public override string Title()
        {
            return  "Municipios";
        }
           
        public override string DescripcionPadre()
        {
            return "Departamentos";
        }
    
    }
}
