namespace SicoWeb.Dominio.Core.Entidades
{
    public interface IEntiBaseComplejosHijo<T>:IEntiBase 
    {
        T Padre { get; set; }
    }
}