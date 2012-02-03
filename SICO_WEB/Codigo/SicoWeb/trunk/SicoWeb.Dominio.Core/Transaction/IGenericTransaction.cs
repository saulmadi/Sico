using System;

namespace SicoWeb.Dominio.Core.Transaction
{
    public interface IGenericTransaction : IDisposable
    {
        void Commit();
        void Rollback();
    }
}