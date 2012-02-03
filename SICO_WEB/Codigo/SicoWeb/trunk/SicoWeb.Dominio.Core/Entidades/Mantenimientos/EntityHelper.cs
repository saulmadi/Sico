using System.Collections.Generic;
using System.Linq;

namespace SicoWeb.Dominio.Core.Entidades.Mantenimientos
{
    internal  static class EntityHelper
    {
         public static IList<IEntiMantenimientosClomplejosHijos> ToEntiMantenimientosComplejosHijosList<T>(this IList<T> list) where T:IEntiMantenimientosClomplejosHijos
         {
             return list.Select(variable => (IEntiMantenimientosClomplejosHijos) variable).ToList();
         }
         public static IList<T> ToEntiMantenimientos<T>(this IList<IEntiMantenimientosClomplejosHijos> list) where T : IEntiMantenimientosClomplejosHijos
         {
             return list.Select(entiMantenimientosClomplejosHijose => (T) entiMantenimientosClomplejosHijose).ToList();
         }
    }
}