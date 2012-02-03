namespace SicoWeb.Dominio.Core.Entidades.Mantenimientos
{
    public interface IEntiMantenimientosFactory
    {
        T CreateEnti<T>() where T : IEntiMantenimientos;
    }
}