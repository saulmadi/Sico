using System;
using SicoWeb.Dominio.Core.BuisnessRules;

namespace SicoWeb.Aplicacion.ServiceLayer
{
    public interface IError
    {
        int CodigoError { get; set; }
        string Descripcion { get; set;}
        Exception  Excepcion { get; set; }
    }

    class Error : IError
    {
        public int CodigoError { get; set; }
        public string Descripcion { get; set; }

        public Exception Excepcion { get; set; }

        public override string ToString()
        {
            return Excepcion.Message ;
        } 
    }
}