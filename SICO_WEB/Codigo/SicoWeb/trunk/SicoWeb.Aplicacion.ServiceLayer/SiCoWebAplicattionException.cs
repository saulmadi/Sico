using System;
using System.Collections.Generic;

namespace SicoWeb.Aplicacion.ServiceLayer
{
    public class SiCoWebAplicattionException:Exception 
    {
        public IList<IError> Errores { get; set; }

        public SiCoWebAplicattionException(IList<IError> errores):base ("El servicio tiene errores")
        {
            Errores = errores;
        }
    }
}