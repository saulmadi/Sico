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
                                                     TEntidadMantenimientoHijo,TEntidadMantenimientoPadre> :
                                                         AServicioMantenimiento
                                                             <TEntidadServicioHijo, TEntidadMantenimientoHijo>,
                                                         IServicioMantenimientoHijo
                                                             <TEntidadServicioHijo, TEntidadServicioPadre>
        where TEntidadServicioHijo : IEntidadServicioMantenimientoHijo<TEntidadServicioPadre>, new()
        where TEntidadMantenimientoHijo : IEntiMantenimientosClomplejosHijos, new()
        where TEntidadServicioPadre : IEntidadServicioMantenimiento, new()
        where TEntidadMantenimientoPadre :IEntiMantenimientosComplejosPadres ,new()
    {
        private readonly IServicioMantenimiento<TEntidadServicioPadre> _servicioMantenimiento;
        private readonly IRepositorioMantimientos<TEntidadMantenimientoPadre> _repositorioMantimientosPadre;


        protected AServicioMantenimientoHijo(
            IRepositorioMantimientos<TEntidadMantenimientoHijo> repositorioMantimientos,
            IEntiMantenimientosFactory entiMantenimientosFactory,
            IQuery queryDeshabilitado,
            IQuery queryHabilitado, IUnitOfWork unitOfWork,
            IBuisnessRulesMannagerMantenimientos<TEntidadMantenimientoHijo>
                buisnessRulesMannagerMantenimientos,
            IServicioMantenimiento<TEntidadServicioPadre> servicioMantenimiento,
            IRepositorioMantimientos<TEntidadMantenimientoPadre> repositorioMantimientosPadre)
            : base(
                repositorioMantimientos, entiMantenimientosFactory, queryDeshabilitado, queryHabilitado, unitOfWork,
                buisnessRulesMannagerMantenimientos)
        {
            _servicioMantenimiento = servicioMantenimiento;
            _repositorioMantimientosPadre = repositorioMantimientosPadre;
        }

        public IList<TEntidadServicioPadre> GetPosiblesPadres()
        {
            return GetListaWithTransaction(() =>_servicioMantenimiento.GetHabilitados());
        }

        public new IList<TEntidadServicioHijo> GetTodos()
        {
            return GetListaWithTransaction(()=> GetList(RunQuery(null)));
        }
        protected override IList<TEntidadServicioHijo> GetList(ICollection<TEntidadMantenimientoHijo> collection)
        {
            return collection.ToListOfEntidadMantenimientoHijo<TEntidadServicioHijo,TEntidadServicioPadre,TEntidadMantenimientoHijo>();
        }

       
        protected override TEntidadMantenimientoHijo Convert(TEntidadServicioHijo entidadServicio)
        {
            var entidad= entidadServicio.ToEntiMantenimientosComplejosHijos<TEntidadMantenimientoHijo,TEntidadMantenimientoPadre,TEntidadServicioPadre>();
            
            return entidad;
        }
    }


}
    