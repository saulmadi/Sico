using System;
using System.Collections.Generic;

namespace SicoWeb.Aplicacion.ServiceLayer
{
    public class AServicio<T>:IServicio
    {
        public IList<IError> Errores { get; set; }
        public IList<Func<T>> Cambios { get; set; }

        public bool HasError()
        {
            return Errores.Count > 0;
        }

        public void CommitCambios()
        {
            if (!HasError())

                foreach (var cambio in Cambios)
                {
                    cambio();
                }
            else
                throw new SiCoWebAplicattionException(Errores);
        }
    }
}