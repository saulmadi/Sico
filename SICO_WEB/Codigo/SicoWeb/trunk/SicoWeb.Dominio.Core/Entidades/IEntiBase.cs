using System;

namespace SicoWeb.Dominio.Core.Entidades
{
    public interface IEntiBase
    {
        int Id { get; set; }
        int Usu { get; set; }
        DateTime Fmodif { get; set; }
    }
}