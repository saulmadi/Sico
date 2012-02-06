using SicoWeb.Dominio.Core.Repositorio.Errores;

namespace SicoWeb.Dominio.Core.BuisnessRules
{
    public interface ISicoWebCoreExceptionFactory
    {
        SicoWebCoreException CreateSicoWebCoreException(int errorCode, IRepositorioEntiErrores repositorioErrores);
    }
}