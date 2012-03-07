using System;
using System.Collections.Generic;
using SicoWeb.Dominio.Core.Entidades;
using SicoWeb.Dominio.Core.BuisnessRules;
using SicoWeb.Dominio.Core.Transaction;

namespace SicoWeb.Aplicacion.ServiceLayer
{
    public abstract class AServicio<TEntidadMantenimiento>:IServicio where TEntidadMantenimiento :IEntiBase 
    {
        private readonly IBuisnessRulesMannager<TEntidadMantenimiento> _buisnessRulesMannager;
        private readonly IUnitOfWork _unitOfWork;

        protected AServicio( IBuisnessRulesMannager< TEntidadMantenimiento>  buisnessRulesMannager,IUnitOfWork unitOfWork  )
        {
            _buisnessRulesMannager = buisnessRulesMannager;
            _unitOfWork = unitOfWork;
            Errores = new List<IError>();
            Cambios = new List<Func<TEntidadMantenimiento>>();
        }

        public IList<IError> Errores { get; set; }
        private IList<Func<TEntidadMantenimiento>> Cambios { get; set; }

        public bool HasError()
        {
            return Errores.Count > 0;
        }

        protected T GetEntidadWithTransaction<T>(Func<T> ejecucionQuery  )
        {
            using (var transaccion = _unitOfWork.BeginTransaction())
            {
                var entidad = ejecucionQuery();
                transaccion.Commit();
                return entidad;
            }
        }

        protected IList<TLista> GetListaWithTransaction<TLista>(Func<IList<TLista>> ejecucionQuery)
        {
            return GetEntidadWithTransaction(ejecucionQuery);
        }

        protected  void SetCambios(Func<TEntidadMantenimiento> cambio )
        {
            Cambios.Add(cambio);
        }

        private void ComitCambios()
        {
               foreach (var cambio in Cambios)
                {
                    cambio();
                }
            
        }

        protected void RunRules(TEntidadMantenimiento entidadMantenimiento )
        {
            try
            {
                using (var transacion = _unitOfWork.BeginTransaction())
                {
                    try
                    {
                        _buisnessRulesMannager.RunComportamiento(entidadMantenimiento);
                        ComitCambios();
                        transacion.Commit();
                        
                    }
                    catch (SicoWebCoreException coreException)
                    {
                        transacion.Rollback();
                       
                        Errores.Add(new Error
                        {
                            Excepcion=coreException,
                            CodigoError = coreException.ErrorCode,
                            Descripcion = coreException.ErrorDescripcion
                        });
                    }
                }

            }
            catch (Exception exception )
            {
                
                
                throw new SiCoWebAplicattionException(exception) ;
            } 

            
        }
        
    }
}