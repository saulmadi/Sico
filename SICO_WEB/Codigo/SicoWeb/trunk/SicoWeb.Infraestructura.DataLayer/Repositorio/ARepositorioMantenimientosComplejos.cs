using NHibernate;
using SicoWeb.Dominio.Core.Repositorio.Mantenimientos;
using SicoWeb.Dominio.Core.Entidades.Mantenimientos;
namespace SicoWeb.Infraestructura.DataLayer.Repositorio
{
    public abstract class ARepositorioMantenimientosComplejos<TPadre,THijo>:ARepository<TPadre>,IRepositorioMantenimientosComplejos<TPadre,THijo> 
        where TPadre:IEntiMantenimientosComplejosPadres 
        where THijo:IEntiMantenimientosClomplejosHijos  
    {
        protected ARepositorioMantenimientosComplejos(ISession session, ISessionFactory factory) : base(session, factory)
        {
        }
        
        public void AgregarHijo(TPadre padre, THijo hijos)
        {
            padre.Hijos.Add(hijos);

            SaveOrUpdate(padre);
        }
        
       public new void SaveOrUpdate(TPadre padre )
       {
           foreach (var hijo in padre.Hijos)
               hijo.Padre = padre;

           base.SaveOrUpdate(padre);
       }
    }
}