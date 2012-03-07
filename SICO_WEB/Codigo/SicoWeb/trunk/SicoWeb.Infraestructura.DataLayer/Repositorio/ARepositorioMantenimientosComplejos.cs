using NHibernate;
using SicoWeb.Dominio.Core.Repositorio.Mantenimientos;
using SicoWeb.Dominio.Core.Entidades.Mantenimientos;
using SicoWeb.Dominio.Core.Transaction;

namespace SicoWeb.Infraestructura.DataLayer.Repositorio
{
    public abstract class ARepositorioMantenimientosComplejos<TPadre,THijo>:ARepository<TPadre>,IRepositorioMantenimientosComplejos<TPadre,THijo> 
        where TPadre: class, IEntiMantenimientosComplejosPadres 
        where THijo:IEntiMantenimientosClomplejosHijos  
    {
        protected ARepositorioMantenimientosComplejos(ISessionMannager sessionMannager)
            : base(sessionMannager)
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