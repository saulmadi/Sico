using System.Linq;
using NHibernate;
using NHibernate.Criterion;

namespace SicoWeb.Infraestructura.DataLayer.Repositorio
{
    public class RepositoryHelper<T>
    {
        public static ICriteria GetExecutableCriteria(ISession session, DetachedCriteria criteria, Order[] orders)
        {
            var executableCriteria = criteria != null
                                               ? criteria.GetExecutableCriteria(session)
                                               : session.CreateCriteria(typeof (T));
            

            if (orders != null)
            {
                foreach (var order in orders)
                    executableCriteria.AddOrder(order);
            }
            return executableCriteria;
        }

        public static ICriteria CreateCriteriaFromArray(ISession session, ICriterion[] criteria, Order[] orders)
        {
            var crit = session.CreateCriteria(typeof(T));
            foreach (var criterion in criteria.Where(criterion => criterion != null))
            {
                crit.Add(criterion);
            }
            if (orders != null)
            {
                foreach (var order in orders)
                    crit.AddOrder(order);
            }
            return crit;
        }
    }
}