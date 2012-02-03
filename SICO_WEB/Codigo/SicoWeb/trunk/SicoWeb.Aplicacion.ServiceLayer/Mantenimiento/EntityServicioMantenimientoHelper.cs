using System.Collections.Generic;
using System.Linq;
using SicoWeb.Dominio.Core.Entidades.Mantenimientos;
using SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Entidades; 
namespace SicoWeb.Aplicacion.ServiceLayer.Mantenimiento
{ 
   
    public static class EntityServicioMantenimientoHelper 
    {
         public static T ToEntidadServicioMantenimiento<T>(this IEntiMantenimientos mantenimientos) where T :IEntidadServicioMantenimiento, new()
         {
             return mantenimientos.ToEntidadServicio<T>().
                 Asignador(c => c.Descripcion = mantenimientos.Descripcion,
                           d => d.Habilitado = mantenimientos.Habilitado);
         }

        public static IList<T> ToListOfEntidadMantenimiento<T, TEntiM>(this ICollection<TEntiM> mantenimientos)
            where T:  IEntidadServicioMantenimiento, new()
            where TEntiM: IEntiMantenimientos
        {

            return mantenimientos.Select(entiMantenimientose => entiMantenimientose.
                                                                    ToEntidadServicioMantenimiento<T>())
                                        .ToList();
        }

        public static T ToEntiMantenimientos<T>(this IEntidadServicioMantenimiento entidadServicioMantenimiento ) where T: IEntiMantenimientos, new()
        {
            return entidadServicioMantenimiento.ToEntiBase<T>().Asignador(
                    c => c.Descripcion = entidadServicioMantenimiento.Descripcion,
                    d => d.Habilitado = entidadServicioMantenimiento.Habilitado);
        }
    }
}