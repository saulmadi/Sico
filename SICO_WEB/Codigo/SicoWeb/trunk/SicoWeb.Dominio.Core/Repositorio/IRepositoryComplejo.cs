using SicoWeb.Dominio.Core.Entidades;

namespace SicoWeb.Dominio.Core.Repositorio
{
    public interface IRepositoryComplejo<TPadre, in THijo> : IRepository<TPadre>
        where TPadre : IEntiBase
        where THijo : IEntiBase
    {
        void AgregarHijo(TPadre padre, THijo hijo);
    }
}