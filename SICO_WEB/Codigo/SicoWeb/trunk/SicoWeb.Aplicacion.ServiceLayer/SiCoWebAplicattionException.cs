using System;

namespace SicoWeb.Aplicacion.ServiceLayer
{
    public class SiCoWebAplicattionException:Exception 
    {
        

        public SiCoWebAplicattionException(Exception exception):base ("Error inesperado de la aplicación",exception)
        {
           
        }
    }
}