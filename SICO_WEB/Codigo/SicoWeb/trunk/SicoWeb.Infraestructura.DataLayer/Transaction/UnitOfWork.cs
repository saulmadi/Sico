using System.Data;
using SicoWeb.Dominio.Core.Transaction;

namespace SicoWeb.Infraestructura.DataLayer.Transaction
{
    public class UnitOfWork : IUnitOfWork 
    {
        private readonly IGenericTransactionFactory _factory;
        private readonly ISessionMannager _sessionMannager;
        

        public UnitOfWork(IGenericTransactionFactory  factory, ISessionMannager sessionMannager )
        {
            _factory = factory;
            _sessionMannager = sessionMannager;
         
        }

        public void Dispose()
        {
           
        }
        

        public void Flush()
        {
            _sessionMannager.GetSession().Flush();
        }

        public bool IsInActiveTransaction
        {
            get { return _sessionMannager.GetSession().Transaction.IsActive; }
        }
        
        public IGenericTransaction BeginTransaction()
        {
            return _factory.GetGenericTransaction(_sessionMannager.GetSession().BeginTransaction());
        }

        public IGenericTransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            return _factory.GetGenericTransaction(_sessionMannager.GetSession().BeginTransaction(isolationLevel));
        }

        public void TransactionalFlush()
        {
            TransactionalFlush(IsolationLevel.ReadCommitted);
        }

        public void TransactionalFlush(IsolationLevel isolationLevel)
        {
            // $$$$$$$$$$$$$$$$ gns: take this, when making thread safe! $$$$$$$$$$$$$$
            //IUoWTransaction tx = UnitOfWork.Current.BeginTransaction(isolationLevel);   

            var tx = BeginTransaction(isolationLevel);
            try
            {
                //forces a flush of the current unit of work
                tx.Commit();
            }
            catch
            {
                tx.Rollback();
                throw;
            }
            finally
            {
                tx.Dispose();
            }
        }
    }
}