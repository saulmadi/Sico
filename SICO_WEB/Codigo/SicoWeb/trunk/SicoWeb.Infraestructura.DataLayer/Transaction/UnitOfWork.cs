using System;
using System.Data;
using NHibernate;
using SicoWeb.Dominio.Core.Transaction;

namespace SicoWeb.Infraestructura.DataLayer.Transaction
{
    public class UnitOfWork : IUnitOfWork 
    {
        private readonly IGenericTransactionFactory _factory;
        private readonly ISession _session;

        public UnitOfWork(IGenericTransactionFactory  factory, ISession session)
        {
            _factory = factory;
            _session = session;
        }

        public void Dispose()
        {
           
        }
        

        public void Flush()
        {
            _session.Flush();
        }

        public bool IsInActiveTransaction
        {
            get
            {
                return _session.Transaction.IsActive;
            }
        }
        
        public IGenericTransaction BeginTransaction()
        {
            return _factory.GetGenericTransaction(_session.BeginTransaction());
        }

        public IGenericTransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            return _factory.GetGenericTransaction(_session.BeginTransaction(isolationLevel));
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