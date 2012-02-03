using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SicoWeb.Aplicacion.ServiceLayer
{

    public class EntidadServicio:IEntidadServicio
    {
    
        public int Id { get; set; }
     
        public int Usu { get; set; }

     
        public DateTime Fmodif { get; set; }
    }
}