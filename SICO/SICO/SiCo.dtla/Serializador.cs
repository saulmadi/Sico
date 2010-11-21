using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace SiCo.dtla
{
    public class Serializador
    {
        #region Declaraciones
        private BinaryFormatter _Serializador = new BinaryFormatter();
        private object _Objeto = new object();
        public event ErroresEventArgs Errores;
        
        #endregion 
        
        #region Propiedades

        public object Objeto
        {
            get { return _Objeto; }
            set { _Objeto = value; }
        }

        public string  Directorio
        {
            get;
            set;
        }    


        #endregion

        public Serializador() 
        {
            
        }

        
        #region Metodos

        /// <summary>
        /// Serializa un objeto de en un archivo de configuración
        /// </summary>
        public object Cargar()
        {
            
            try
            {
                Stream _Archivo = new FileStream(Directorio, FileMode.Open , FileAccess.ReadWrite, FileShare.ReadWrite);
                _Objeto= _Serializador.Deserialize(_Archivo);
                _Archivo.Close();

                
                
            }
            catch (Exception ex)
            {
                if(Errores!=null)
               Errores(ex.Message);

            }
            return _Objeto;            

        }

        /// <summary>
        /// Deserializa un objeto de un archivo de configuración
        /// </summary>
        public void Guardar()
        {
            try
            {
                Stream _Archivo = new FileStream(Directorio, FileMode.Create , FileAccess.ReadWrite, FileShare.ReadWrite);
                _Serializador.Serialize (_Archivo,Objeto);
                _Archivo.Close();
            }
            catch (Exception ex)
            {
                if (Errores != null)
                Errores (ex.Message);
            }
        }


        #endregion
        
    }
}
