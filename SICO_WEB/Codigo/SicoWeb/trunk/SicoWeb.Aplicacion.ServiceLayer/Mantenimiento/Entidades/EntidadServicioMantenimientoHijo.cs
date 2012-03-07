using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Entidades
{
    public class EntidadServicioMantenimientoHijo<TPadre> : EntidadServicioMantenimiento,  IEntidadServicioMantenimientoHijo<TPadre>
        where TPadre : IEntidadServicioMantenimiento
    {
        
        public TPadre Padre{get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public int PadreId { get; set; }
        public IEnumerable<TPadre> Padres { get; set; }
    }
}