namespace SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Entidades
{
    public class EntidadServicioMantenimientoHijo<TPadre> : EntidadServicioMantenimiento,  IEntidadServicioMantenimientoHijo<TPadre>
        where TPadre : IEntidadServicioMantenimiento
    {
        public TPadre Padre{get; set; }
    }
}