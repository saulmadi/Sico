using SicoWeb.Dominio.Core.Repositorio.Errores;

namespace SicoWeb.Dominio.Core.BuisnessRules
{
    public interface ISicoWebExceptionFactory
    {
        SicoWebCoreException CreateSicoWebCoreException(int erroCode, IRepositorioEntiErrores repositorioEntiErrores);
    }
}