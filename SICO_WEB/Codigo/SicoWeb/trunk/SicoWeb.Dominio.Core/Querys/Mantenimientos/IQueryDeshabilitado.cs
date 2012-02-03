using SicoWeb.Dominio.Core.Entidades.Mantenimientos;

namespace SicoWeb.Dominio.Core.Querys.Mantenimientos
{
    public interface IQueryDeshabilitado<TEnti> :IQueryMantenimientos<TEnti> 
        where TEnti:IEntiMantenimientos
    {


    }
}