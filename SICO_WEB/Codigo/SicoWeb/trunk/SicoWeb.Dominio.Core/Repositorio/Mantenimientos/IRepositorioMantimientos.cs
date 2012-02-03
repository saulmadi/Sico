using SicoWeb.Dominio.Core.Entidades.Mantenimientos;

namespace SicoWeb.Dominio.Core.Repositorio.Mantenimientos
{
    public interface IRepositorioMantimientos<T>:IRepository<T> where T : IEntiMantenimientos
    {
         
        
    }
}