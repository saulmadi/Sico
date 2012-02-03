using System.Collections.Generic;

namespace SicoWeb.Dominio.Core.Entidades
{
    public interface IEntiBaseComplejosPadre<T>:IEntiBase 
    {
        IList<T> Hijos { get; set; }
    }
}