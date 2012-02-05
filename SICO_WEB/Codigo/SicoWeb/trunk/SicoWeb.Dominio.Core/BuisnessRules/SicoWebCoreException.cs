﻿using System;
using SicoWeb.Dominio.Core.Repositorio.Errores;

namespace SicoWeb.Dominio.Core.BuisnessRules
{
    public class SicoWebCoreException : Exception
    {
        private readonly IRepositorioEntiErrores _repositorioErrores;

        public SicoWebCoreException(int errorCode, IRepositorioEntiErrores repositorioErrores)
        {
            _repositorioErrores = repositorioErrores;
            ErrorCode = errorCode;
            SetErrorDescripcion();
        }

        public int ErrorCode { get; set; }
        public string ErrorDescripcion { get; set; }

        public override string Message
        {
            get { return string.Format("Error {0}# \n {1}", ErrorCode, ErrorDescripcion); }
        }

        private void SetErrorDescripcion()
        {
            ErrorDescripcion = GetDescripcionError();
        }

        private string GetDescripcionError()
        {
            var error = _repositorioErrores.Get(ErrorCode);
            if (error != null)
                return string.IsNullOrEmpty(error.Descripcion) ? error.Descripcion : "El error no tiene una descripción";
            return "Error desconocido";
        }
    }
}