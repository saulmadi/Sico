namespace SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Entidades
{
    public interface IEntidadServicioMantenimientoHijo<TPadre>:IEntidadServicioMantenimiento  where TPadre :IEntidadServicioMantenimiento
    {
        TPadre Padre { get; set; }
    }
}