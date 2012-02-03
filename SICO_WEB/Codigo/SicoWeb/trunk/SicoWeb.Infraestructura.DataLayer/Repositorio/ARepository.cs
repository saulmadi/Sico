using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transform;
using NHibernateRepository;
using SicoWeb.Dominio.Core.Entidades;
using SicoWeb.Dominio.Core.Repositorio;

namespace SicoWeb.Infraestructura.DataLayer.Repositorio
{
    public abstract class  ARepository<T> : IRepository<T> where T:IEntiBase

    {
        private readonly ISession _session;
        private readonly ISessionFactory _factory;

        protected ARepository(ISession session, ISessionFactory factory   )
        {
            if (session == null) throw new ArgumentNullException("session");
            if (factory == null) throw new ArgumentNullException("factory");
            _session = session;
            _factory = factory;
        }

        protected virtual ISession Session
        {
            get { return _session; }
        }

        protected virtual ISessionFactory SessionFactory
        {
            get { return _factory; }
        }

        public T Get(object id)
        {
            
            return (T)Session.Get(typeof(T), id);
        }

        public T Load(object id)
        {
            return (T)Session.Load(typeof(T), id);
        }

        public void Delete(T entity)
        {
            Session.Delete(entity);
        }

        public void DeleteAll()
        {
            Session.Delete(string.Format("from {0}", typeof(T).Name));
        }

        public void DeleteAll(DetachedCriteria where)
        {
            foreach (object entity in where.GetExecutableCriteria(Session).List())
            {
                Session.Delete(entity);
            }
        }

        public T Save(T entity)
        {
            Session.Save(entity);
            return entity;
        }

        public T SaveOrUpdate(T entity)
        {
            Session.SaveOrUpdate(entity);
            return entity;
        }

        public void Update(T entity)
        {
            Session.Update(entity);
        }

        public long Count(DetachedCriteria criteria)
        {
            var crit = RepositoryHelper<T>.GetExecutableCriteria(Session, criteria, null);
            crit.SetProjection(Projections.RowCount());
            var countMayBeInt32OrInt64DependingOnDatabase = crit.UniqueResult();
            return Convert.ToInt64(countMayBeInt32OrInt64DependingOnDatabase);
        }

        public long Count()
        {
            return Count(null);
        }

        public bool Exists(DetachedCriteria criteria)
        {
            return 0 != Count(criteria);
        }

        public bool Exists()
        {
            return Exists(null);
        }

        public ICollection<T> FindAll(DetachedCriteria criteria, params Order[] orders)
        {
            var crit = RepositoryHelper<T>.GetExecutableCriteria(Session, criteria, orders);
            return crit.List<T>();
        }

        public ICollection<T> FindAll(Order order, params ICriterion[] criteria)
        {
            return FindAll(new[] { order }, criteria);
        }

        public ICollection<T> FindAll(Order[] orders, params ICriterion[] criteria)
        {
            var crit = RepositoryHelper<T>.CreateCriteriaFromArray(Session, criteria, orders);
            return crit.List<T>();
        }

        public T FindFirst(params Order[] orders)
        {
            return FindFirst(null, orders);
        }

        public T FindFirst(DetachedCriteria criteria, params Order[] orders)
        {
            var crit = RepositoryHelper<T>.GetExecutableCriteria(Session, criteria, orders);
            crit.SetFirstResult(0);
            crit.SetMaxResults(1);
            return crit.UniqueResult<T>();
        }

        public T FindOne(params ICriterion[] criteria)
        {
            var crit = RepositoryHelper<T>.CreateCriteriaFromArray(Session, criteria, null);
            return crit.UniqueResult<T>();
        }

        public T FindOne(DetachedCriteria criteria)
        {
            var crit = RepositoryHelper<T>.GetExecutableCriteria(Session, criteria, null);
            return crit.UniqueResult<T>();
        }

        public TProjT ReportOne<TProjT>(ProjectionList projectionList)
        {
            var crit = RepositoryHelper<T>.GetExecutableCriteria(Session, null, null);
            return DoReportOne<TProjT>(crit, projectionList);
        }

        public TProjT ReportOne<TProjT>(DetachedCriteria criteria, ProjectionList projectionList)
        {
            var crit = RepositoryHelper<T>.GetExecutableCriteria(Session, criteria, null);
            return DoReportOne<TProjT>(crit, projectionList);
        }

        public ICollection<TProjT> ReportAll<TProjT>(ProjectionList projectionList)
        {
            return ReportAll<TProjT>(false, projectionList);
        }

        public ICollection<TProjT> ReportAll<TProjT>(bool distinctResults, ProjectionList projectionList)
        {
            var crit = RepositoryHelper<T>.GetExecutableCriteria(Session, null, null);
            return DoReportAll<TProjT>(crit, projectionList, distinctResults);
        }

        public ICollection<TProjT> ReportAll<TProjT>(ProjectionList projectionList, params Order[] orders)
        {
            return ReportAll<TProjT>(false, projectionList, orders);
        }

        public ICollection<TProjT> ReportAll<TProjT>(bool distinctResults, ProjectionList projectionList, params Order[] orders)
        {
            var crit = RepositoryHelper<T>.GetExecutableCriteria(Session, null, orders);
            return DoReportAll<TProjT>(crit, projectionList, distinctResults);
        }

        public ICollection<TProjT> ReportAll<TProjT>(DetachedCriteria criteria, ProjectionList projectionList, params Order[] orders)
        {
            return ReportAll<TProjT>(false, criteria, projectionList, orders);
        }

        public ICollection<TProjT> ReportAll<TProjT>(bool distinctResults, DetachedCriteria criteria, ProjectionList projectionList, params Order[] orders)
        {
            var crit = RepositoryHelper<T>.GetExecutableCriteria(Session, criteria, orders);
            return DoReportAll<TProjT>(crit, projectionList, distinctResults);
        }

        private static TProjT DoReportOne<TProjT>(ICriteria criteria, ProjectionList projectionList)
        {
            BuildProjectionCriteria<TProjT>(criteria, projectionList, false);
            return criteria.UniqueResult<TProjT>();
        }

        private static ICollection<TProjT> DoReportAll<TProjT>(ICriteria criteria, ProjectionList projectionList, bool distinctResults)
        {
            BuildProjectionCriteria<TProjT>(criteria, projectionList, distinctResults);
            return criteria.List<TProjT>();
        }

        private static void BuildProjectionCriteria<TProjT>(ICriteria criteria, IProjection projectionList, bool distinctResults)
        {
            criteria.SetProjection(distinctResults ? Projections.Distinct(projectionList) : projectionList);

            // if we are not returning a tuple, then we need the result transformer
            if (typeof (TProjT) != typeof (object[]))
                criteria.SetResultTransformer(new TypedResultTransformer<TProjT>());
        }

        /// <summary>This is used to convert the resulting tuples into strongly typed objects.</summary>
        private class TypedResultTransformer<T1> : IResultTransformer
        {
            public object TransformTuple(object[] tuple, string[] aliases)
            {
                return tuple.Length == 1 ? tuple[0] : Activator.CreateInstance(typeof (T1), tuple);
            }

            IList IResultTransformer.TransformList(IList collection)
            {
                return collection;
            }
        }
    }
}
