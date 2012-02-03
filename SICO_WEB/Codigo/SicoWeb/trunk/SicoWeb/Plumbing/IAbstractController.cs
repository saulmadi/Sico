using System.Web.Mvc;
using SicoWeb.Aplicacion.ServiceLayer;

namespace SicoWeb.Plumbing
{
    public interface IAbstractController<in TEntidadServicio>  where TEntidadServicio:IEntidadServicio
    {
    


    }
}