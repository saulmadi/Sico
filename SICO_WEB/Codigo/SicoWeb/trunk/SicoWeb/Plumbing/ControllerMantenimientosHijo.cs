using System.Web.Mvc;
using SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Entidades;
using SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Servicios;

namespace SicoWeb.Plumbing
{
    public abstract  class ControllerMantenimientosHijo<THijo,TPadre> : ControllerMantenimientos<THijo> 
        where THijo : class, IEntidadServicioMantenimientoHijo<TPadre>, new() where TPadre :IEntidadServicioMantenimiento 
    {
        private readonly IServicioMantenimientoHijo<THijo, TPadre> _servicio;

        protected ControllerMantenimientosHijo(IServicioMantenimientoHijo<THijo,TPadre> servicio) : base(servicio)
        {
            _servicio = servicio;
        }

        public override ActionResult Create()
        {

            var model = _servicio.GetById(0);
            model.Padres = _servicio.GetPosiblesPadres();

            return PartialView(model);
        }

        public abstract string DescripcionPadre();

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            ViewBag.DescripcionPadre= DescripcionPadre(); 
            base.OnActionExecuted(filterContext);
        }

    }
}