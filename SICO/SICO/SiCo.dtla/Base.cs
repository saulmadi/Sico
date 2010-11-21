using System;
using System.Collections.Generic;
using System.Text;

namespace SiCo.dtla
{
    [Serializable]public abstract class Base
    {
        public Base()
        { 
        }

        public event ErroresEventArgs Errores;

        protected void LLamadoErrores(string Mensaje)
        {
            Errores(Mensaje);  
        }
    
    }

   
}
