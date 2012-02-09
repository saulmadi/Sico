using System.Collections.Generic;
using SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Helper;
using SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Entidades;
using SicoWeb.Dominio.Core.BuisnessRules.Mantenimientos;
using SicoWeb.Dominio.Core.Entidades.Mantenimientos;
using SicoWeb.Dominio.Core.Querys;
using SicoWeb.Dominio.Core.Repositorio.Mantenimientos;
using SicoWeb.Dominio.Core.Transaction;

namespace SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Servicios
{
    public abstract class AServicioMantenimientoHijo<TEntidadServicioHijo, TEntidadServicioPadre,
                                                     TEntidadMantenimientoHijo> :
                                                         AServicioMantenimiento
                                                             <TEntidadServicioHijo, TEntidadMantenimientoHijo>,
                                                         IServicioMantenimientoHijo
                                                             <TEntidadServicioHijo, TEntidadServicioPadre>
        where TEntidadServicioHijo : IEntidadServicioMantenimientoHijo<TEntidadServicioPadre>, new()
        where TEntidadMantenimientoHijo : IEntiMantenimientosClomplejosHijos, new()
        where TEntidadServicioPadre : IEntidadServicioMantenimiento, new()
    {
        private readonly IServicioMantenimiento<TEntidadServicioPadre> _servicioMantenimiento;


        protected AServicioMantenimientoHijo(
            IRepositorioMantimientos<TEntidadMantenimientoHijo> repositorioMantimientos,
            IEntiMantenimientosFactory entiMantenimientosFactory,
            IQuery queryDeshabilitado,
            IQuery queryHabilitado, IUnitOfWork unitOfWork,
            IBuisnessRulesMannagerMantenimientos<TEntidadMantenimientoHijo>
                buisnessRulesMannagerMantenimientos,
            IServicioMantenimiento<TEntidadServicioPadre> servicioMantenimiento)
            : base(
                repositorioMantimientos, entiMantenimientosFactory, queryDeshabilitado, queryHabilitado, unitOfWork,
                buisnessRulesMannagerMantenimientos)
        {
            _servicioMantenimiento = servicioMantenimiento;
        }

        public IList<TEntidadServicioPadre> GetPosiblesPadres()
        {
            return _servicioMantenimiento.GetHabilitados();
        }

        public new IList<TEntidadServicioHijo> GetTodos()
        {
            return GetList(RunQuery(null));
        }
        protected override IList<TEntidadServicioHijo> GetList(ICollection<TEntidadMantenimientoHijo> collection)
        {
            return collection.ToListOfEntidadMantenimientoHijo<TEntidadServicioHijo,TEntidadServicioPadre,TEntidadMantenimientoHijo>();
        }
    }


}
    