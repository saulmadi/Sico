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
                        _unitOfWork.Flush();
                    }
                    catch (SicoWebCoreException coreException)
                    {
                        transacion.Rollback();
                       _unitOfWork.Flush();
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
                _unitOfWork.Flush();
                
                throw new SiCoWebAplicattionException(exception) ;
            } 

            
        }
        
    }
}