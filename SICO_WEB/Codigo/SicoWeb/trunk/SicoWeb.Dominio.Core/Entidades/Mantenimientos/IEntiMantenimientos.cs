

namespace SicoWeb.Dominio.Core.Entidades.Mantenimientos
{
    public interface IEntiMantenimientos:IEntiBase 
    {
        
      string Descripcion { get; set; }
       bool  Habilitado { get; set; }
        
    }
}