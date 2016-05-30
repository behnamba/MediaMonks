using PlanDay.Assignment.Common.DDD;
using PlanDay.Assignment.Data.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PlanDay.Assignment.Service.Base
{
    public class AssignmentService<T> : IAssignmentService<T> where T : class
    {
        public bool IsDisposed { get; private set; }

        protected IUnitOfWork UnitOfWork { get; private set; }
        protected IDbSet<T> Entities { get; private set; }

        protected AssignmentService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            Entities = UnitOfWork.Set<T>();
        }

        #region Implementation of IPartikanService<T>
        public virtual long GetCount()
        {
            return Entities.Count();
        }
        public virtual long GetCount(Expression<Func<T, bool>> predicate)
        {
            return Entities.Count(predicate);
        }
        public virtual IList<T> GetAll()
        {
            return GetAll(false);
        }
        public virtual IList<T> GetAll(bool withTracking)
        {
            return withTracking ? Entities.ToList() : Entities.AsNoTracking().ToList();
        }
        public virtual IList<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return GetAll(predicate, false);
        }
        public virtual IList<T> GetAll(Expression<Func<T, bool>> predicate, bool withTracking)
        {
            return withTracking ? Entities.Where(predicate).ToList() : Entities.AsNoTracking().Where(predicate).ToList();
        }
        public IList<T> GetAll(Expression<Func<T, bool>> predicate, int? row, int? max)
        {
            return GetAll(predicate, row, max, false);
        }
        public IList<T> GetAll(Expression<Func<T, bool>> predicate, int? row, int? max, bool withTracking)
        {
            var query = withTracking ? Entities : Entities.AsNoTracking();
            if (max.HasValue && row.HasValue)
            {
                return query.Where(predicate).Take(max.Value).Skip(row.Value).ToList();
            }

            if (!max.HasValue && row.HasValue)
            {
                return query.Where(predicate).Skip(row.Value).ToList();
            }
            return query.Where(predicate).ToList();
        }

        public List<T> GetAllInclude(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> set = Entities;

            foreach (var includeExpression in includes)
            {
                set = set.Include(includeExpression);
            }
            return set.ToList();
        }

        public virtual T Add(T entity)
        {
            return Entities.Add(entity);
        }

        public virtual void Delete(object key)
        {
            var entity = Entities.Find(key);
            if (entity != null)
                Delete(entity);
        }

        public virtual void Clear()
        {
            foreach (var item in Entities)
            {
                Entities.Remove(item);
            }
        }

        public virtual void Delete(Expression<Func<T, bool>> predicate)
        {
            var q = Entities.Where(predicate);
            foreach (var entity in q)
            {
                Entities.Remove(entity);
            }
        }

        public virtual void Update(T entity)
        {
            UnitOfWork.Entry(entity).State = EntityState.Modified;
        }

        public virtual IList<T> Find(Expression<Func<T, bool>> predicate, bool withTracking)
        {
            return withTracking ? Entities.Where(predicate).ToList() : Entities.AsNoTracking().Where(predicate).ToList();
        }
        public virtual IList<T> Find(Expression<Func<T, bool>> predicate)
        {
            return Find(predicate, false);
        }

        public virtual List<T> Find(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            var set = Entities.Where(predicate);

            foreach (var includeExpression in includes)
            {
                set = set.Include(includeExpression);
            }

            return set.ToList();
        }

        public virtual List<T> FindInclude(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> includeExpression)
        {
            var set = Entities.Where(predicate);

            set = set.Include(includeExpression);

            return set.ToList();
        }


        public virtual void Save()
        {
            try
            {
                UnitOfWork.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {

                    }
                }
            }
        }

        #endregion

        protected virtual void Dispose(bool disposing)
        {
            if (IsDisposed) return;
            if (disposing)
            {
                UnitOfWork.RejectChanges();

                //perform cleanup here
            }

            IsDisposed = true;
        }

        ~AssignmentService()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
