using System.Collections.Generic;

namespace SicoWeb.Aplicacion.ServiceLayer
{
    public interface IServicio
    {
        IList<IError> Errores { get; set; }
        bool HasError();
        
    }
}