using System;

namespace SiCo.dtla
{
    [Serializable]
    public abstract class Base
    {
        public event ErroresEventArgs Errores;

        protected void LLamadoErrores(string Mensaje)
        {
            Errores(Mensaje);
        }
    }
}