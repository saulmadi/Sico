using System;
using SicoWeb.Dominio.Core.Entidades;

namespace SicoWeb.Aplicacion.ServiceLayer.Helper
{
    public  static class EntityServicioHelper
    {
        public  static T ToEntidadServicio<T>(this IEntiBase entiBase)  where T: IEntidadServicio, new()
        {

            return new T().Asignador(c => c.Fmodif = entiBase.Fmodif,
                                     d => d.Id = entiBase.Id,
                                     k => k.Usu = entiBase.Usu);
        }

        public static T  ToEntiBase<T>(this  IEntidadServicio entidadServicio) where T:IEntiBase, new()
        {
            return new T().Asignador(c => c.Fmodif = entidadServicio.Fmodif,
                                                j => j.Id = entidadServicio.Id ,
                                                l => l.Usu = entidadServicio.Usu);
        }

        public  static T Asignador<T>(this T obj, params Action<T>[] actions)
        {
        
            foreach (var action in actions)
                action(obj);
            return obj;
        }

        
    }
}