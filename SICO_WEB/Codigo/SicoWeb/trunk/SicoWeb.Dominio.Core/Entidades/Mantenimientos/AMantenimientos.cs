namespace SicoWeb.Dominio.Core.Entidades.Mantenimientos
{
    public abstract partial class Mantenimientos :  IEntiMantenimientos 
    {
        partial void OnCreated()
        {
            Habilitado =true ;
           
        }

       
    }
}

