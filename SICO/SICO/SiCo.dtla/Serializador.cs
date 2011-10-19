using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SiCo.dtla
{
    public class Serializador
    {
        #region Declaraciones

        private readonly BinaryFormatter _Serializador = new BinaryFormatter();
        private object _Objeto = new object();

        #endregion

        #region Propiedades

        public object Objeto
        {
            get { return _Objeto; }
            set { _Objeto = value; }
        }

        public string Directorio { get; set; }

        #endregion

        #region Metodos

        /// <summary>
        /// Serializa un objeto de en un archivo de configuración
        /// </summary>
        public object Cargar()
        {
            try
            {
                Stream _Archivo = new FileStream(Directorio, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
                _Objeto = _Serializador.Deserialize(_Archivo);
                _Archivo.Close();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error en la configuración del sistema. \n Vuelva a configurar.", ex);
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
                Stream _Archivo = new FileStream(Directorio, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                _Serializador.Serialize(_Archivo, Objeto);
                _Archivo.Close();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al guardar el archivo. \n la configuración no se realizó", ex);
            }
        }

        #endregion
    }
}