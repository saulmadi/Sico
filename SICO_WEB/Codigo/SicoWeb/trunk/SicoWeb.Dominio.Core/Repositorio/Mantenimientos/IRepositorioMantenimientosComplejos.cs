﻿using SicoWeb.Dominio.Core.Entidades.Mantenimientos;
namespace SicoWeb.Dominio.Core.Repositorio.Mantenimientos
{
    public interface IRepositorioMantenimientosComplejos<TPadre, THijo> : IRepositorioMantimientos<TPadre>,
                                                                          IRepositoryComplejo<TPadre, THijo>
        where TPadre : IEntiMantenimientosComplejosPadres
        where THijo : IEntiMantenimientosClomplejosHijos
    {

    }
}