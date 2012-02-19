using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Entidades
{
    public class EntidadServicioMantenimiento:EntidadServicio,  IEntidadServicioMantenimiento 
    {
        [Required(ErrorMessage="El campo Descripción no puede ser nulo")]
        [StringLength(100,ErrorMessage ="kaldfafd" )]
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }

        [DisplayName("Habilitado")]
        public bool Habilitado { get ; set; }
    }
}