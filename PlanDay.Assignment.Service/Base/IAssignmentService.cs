using PlanDay.Assignment.Common.DDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PlanDay.Assignment.Service.Base
{
    public interface IAssignmentService<T> : IDisposable where T : class
    {
        long GetCount();
        long GetCount(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
        IList<T> GetAll(bool withTracking);
        IList<T> GetAll();
        IList<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> predicate, bool withTracking);
        IList<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
        List<T> GetAllInclude(params Expression<Func<T, object>>[] includes);
        T Add(T entity);
        void Delete(object key);
        void Delete(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
        void Clear();
        void Update(T entity);
        IList<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate, bool withTracking);
        IList<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
        List<T> FindInclude(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> includeExpression);
        List<T> Find(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

        void Save();
    }
}

