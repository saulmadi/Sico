using System;

namespace SicoWeb.Aplicacion.ServiceLayer
{
    public interface IEntidadServicio
    {
        int Id { get; set; }
        int Usu { get; set; }
        DateTime Fmodif { get; set; }
    }
}