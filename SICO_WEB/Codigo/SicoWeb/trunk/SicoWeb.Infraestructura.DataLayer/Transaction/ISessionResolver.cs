using NHibernate;

namespace SicoWeb.Infraestructura.DataLayer.Transaction
{
    public interface ISessionResolver
    {
        ISession GetSession();
    }
}