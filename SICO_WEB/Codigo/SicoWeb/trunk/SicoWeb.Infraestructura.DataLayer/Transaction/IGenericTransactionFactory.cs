using NHibernate;
using SicoWeb.Dominio.Core.Transaction;

namespace SicoWeb.Infraestructura.DataLayer.Transaction
{
    public interface IGenericTransactionFactory
    {
        IGenericTransaction GetGenericTransaction(ITransaction transaction);
    }
}