using System;
using System.Data;

namespace SicoWeb.Dominio.Core.Transaction
{
    public interface IUnitOfWork : IDisposable
    {
        void Flush();
        bool IsInActiveTransaction { get; }

        IGenericTransaction BeginTransaction();
        IGenericTransaction BeginTransaction(IsolationLevel isolationLevel);
        void TransactionalFlush();
        void TransactionalFlush(IsolationLevel isolationLevel);
    }
}