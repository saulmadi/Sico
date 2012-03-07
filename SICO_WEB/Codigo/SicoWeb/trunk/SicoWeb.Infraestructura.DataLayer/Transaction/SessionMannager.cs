using System;
using NHibernate;
using SicoWeb.Dominio.Core.Transaction;

namespace SicoWeb.Infraestructura.DataLayer.Transaction
{
    public class SessionMannager : ISessionMannager
    {
        private ISession _session;
        private readonly ISessionFactory _factory;
        private readonly ISessionResolver _sessionResolver;

        public SessionMannager(ISession session, ISessionFactory factory, ISessionResolver sessionResolver)
        {
            if (session == null) throw new ArgumentNullException("session");
            if (factory == null) throw new ArgumentNullException("factory");
            _session = session;
            _factory = factory;
            _sessionResolver = sessionResolver;
        }

        public ISession GetSession()
        {
            return /*_session.IsOpen && _session.IsConnected ?*/ _session;// : (_session = _factory.OpenSession());
        }

        public ISessionFactory GetSessionFactory()
        {
            return _factory;
        }
    }
}