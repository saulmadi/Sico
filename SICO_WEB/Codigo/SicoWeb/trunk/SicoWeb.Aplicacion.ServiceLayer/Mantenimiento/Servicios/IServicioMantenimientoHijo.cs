using System.Collections.Generic;
using SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Entidades;

namespace SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Servicios
{
    public interface IServicioMantenimientoHijo<TEntidadHijo, TEntidadPadre> : IServicioMantenimiento<TEntidadHijo>
        where TEntidadHijo : IEntidadServicioMantenimientoHijo<TEntidadPadre>
        where TEntidadPadre :IEntidadServicioMantenimiento 
    {
        IList<TEntidadPadre> GetPosiblesPadres();

        new IList<TEntidadHijo> GetTodos();
    }
}