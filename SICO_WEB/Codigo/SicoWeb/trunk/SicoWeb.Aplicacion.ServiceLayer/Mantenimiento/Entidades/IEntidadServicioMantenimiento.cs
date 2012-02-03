using System;

namespace SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Entidades
{
    public interface IEntidadServicioMantenimiento:IEntidadServicio 
    {
        string Descripcion { get; set; }
        Boolean Habilitado { get; set; }

    }
}