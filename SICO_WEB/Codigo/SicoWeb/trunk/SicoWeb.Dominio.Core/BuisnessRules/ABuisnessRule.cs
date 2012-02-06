using SicoWeb.Dominio.Core.Repositorio.Errores;

namespace SicoWeb.Dominio.Core.BuisnessRules
{
    public abstract class ABuisnessRule<TEnti> : IBuisnessRule<TEnti>
    {
        private readonly ISicoWebCoreExceptionFactory _coreCoreExceptionFactory;
        private readonly IRepositorioEntiErrores _repositorioEntiErrores;


        protected ABuisnessRule(ISicoWebCoreExceptionFactory coreCoreExceptionFactory,
                                IRepositorioEntiErrores repositorioEntiErrores)
        {
            _coreCoreExceptionFactory = coreCoreExceptionFactory;
            _repositorioEntiErrores = repositorioEntiErrores;
        }

        #region IBuisnessRule<TEnti> Members

        public abstract void Comportamiento(TEnti entidad);

        #endregion

        protected void ThrowError(int erroCode)
        {
            throw _coreCoreExceptionFactory.CreateSicoWebCoreException(erroCode, _repositorioEntiErrores);
        }
    }
}