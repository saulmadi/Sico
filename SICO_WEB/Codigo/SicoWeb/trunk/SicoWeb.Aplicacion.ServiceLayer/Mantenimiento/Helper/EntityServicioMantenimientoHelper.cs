using System.Collections.Generic;
using System.Linq;
using SicoWeb.Aplicacion.ServiceLayer.Helper;
using SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Entidades;
using SicoWeb.Dominio.Core.Entidades.Mantenimientos;

namespace SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Helper
{

    public static class EntityServicioMantenimientoHelper
    {
        public static T ToEntidadServicioMantenimiento<T>(this IEntiMantenimientos mantenimientos)
            where T : IEntidadServicioMantenimiento, new()
        {
            return mantenimientos.ToEntidadServicio<T>().
                Asignador(c => c.Descripcion = mantenimientos.Descripcion,
                          d => d.Habilitado = mantenimientos.Habilitado);
        }

        public static THijo ToEntidadServicioMantenimientoHijo<THijo, TPadre>(
            this IEntiMantenimientosClomplejosHijos mantenimientos)
            where THijo : IEntidadServicioMantenimientoHijo<TPadre>, new()
            where TPadre : IEntidadServicioMantenimiento, new()
        {
            return mantenimientos.ToEntidadServicioMantenimiento<THijo>().
                Asignador(c => c.Padre = mantenimientos.Padre.ToEntidadServicioMantenimiento<TPadre>());
        }


        public static IList<T> ToListOfEntidadMantenimiento<T, TEntiM>(this ICollection<TEntiM> mantenimientos)
            where T : IEntidadServicioMantenimiento, new()
            where TEntiM : IEntiMantenimientos
        {

            return mantenimientos.Select(entiMantenimientose => ToEntidadServicioMantenimiento<T>(entiMantenimientose))
                .ToList();
        }

        public static IList<THijo> ToListOfEntidadMantenimientoHijo<THijo, TPadre, TEntiM>(
            this ICollection<TEntiM> mantenimientos)
            where THijo : IEntidadServicioMantenimientoHijo<TPadre>, new()
            where TEntiM : IEntiMantenimientosClomplejosHijos
            where TPadre : IEntidadServicioMantenimiento, new()
        {

            return
                mantenimientos.Select(
                    entiMantenimientose => ToEntidadServicioMantenimientoHijo<THijo, TPadre>(entiMantenimientose))
                    .ToList();
        }



        public static T ToEntiMantenimientos<T>(this IEntidadServicioMantenimiento entidadServicioMantenimiento)
            where T : IEntiMantenimientos, new()
        {
            return entidadServicioMantenimiento.ToEntiBase<T>().Asignador(
                c => c.Descripcion = entidadServicioMantenimiento.Descripcion,
                d => d.Habilitado = entidadServicioMantenimiento.Habilitado);
        }

        public static THijo ToEntiMantenimientosComplejosHijos<THijo, TEntiPadre, TPadre>(this IEntidadServicioMantenimientoHijo<TPadre> entidadServicioMantenimiento)
            where THijo : IEntiMantenimientosClomplejosHijos, new()
            where TPadre : IEntidadServicioMantenimiento, new()
            where TEntiPadre :IEntiMantenimientosComplejosPadres, new ()
        {
            return
                entidadServicioMantenimiento.ToEntiMantenimientos<THijo>().Asignador(c=>c.Padre.Id = entidadServicioMantenimiento.PadreId);
        }

    }
}