using System.Collections.Generic;
using SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Entidades;
namespace SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Servicios
{
    public interface IServicioMantenimiento<T> where T:IEntidadServicioMantenimiento
    {
        
        IList<T> GetHabilitados();
        IList<T> GetDesHabilitados();
        IList<T> GetTodos();
        T GetById(int id);
        void AgregarMantenimiento(T mantenimiento);
    }
}