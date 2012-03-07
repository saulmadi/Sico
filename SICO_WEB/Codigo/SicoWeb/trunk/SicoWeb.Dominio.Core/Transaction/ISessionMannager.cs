using NHibernate;

namespace SicoWeb.Dominio.Core.Transaction
{
    public interface ISessionMannager
    {

        ISession GetSession();
        ISessionFactory GetSessionFactory();
    }
}