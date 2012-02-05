using SicoWeb.Dominio.Core.Repositorio.Errores;

namespace SicoWeb.Dominio.Core.BuisnessRules
{
    public abstract class ABuisnessRule<TEnti> : IBuisnessRule<TEnti>
    {
        private readonly ISicoWebExceptionFactory _coreExceptionFactory;
        private readonly IRepositorioEntiErrores _repositorioEntiErrores;


        protected ABuisnessRule(ISicoWebExceptionFactory coreExceptionFactory,
                                IRepositorioEntiErrores repositorioEntiErrores)
        {
            _coreExceptionFactory = coreExceptionFactory;
            _repositorioEntiErrores = repositorioEntiErrores;
        }

        #region IBuisnessRule<TEnti> Members

        public abstract void Comportamiento(TEnti entidad);

        #endregion

        protected void ThrowError(int erroCode)
        {
            throw _coreExceptionFactory.CreateSicoWebCoreException(erroCode, _repositorioEntiErrores);
        }
    }
}