namespace SicoWeb.Aplicacion.ServiceLayer
{
    public interface IError
    {
        int CodigoError { get; set; }
        string Descripcion { get; set;}
    }

    class Error : IError
    {
        public int CodigoError { get; set; }
        public string Descripcion { get; set; }
    }
}