using PlanDay.Assignment.Core.Payment;
using PlanDay.Assignment.Core.PaymentRule;
using PlanDay.Assignment.Core.Product;
using PlanDay.Assignment.Data.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDay.Assignment.Data.InMemoeryConcret
{
    public class TestDataContext : IUnitOfWork
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentRule> PaymentRules { get; set; }
        public DbSet<Criteria> Criterias { get; set; }
        public DbSet<PlanDay.Assignment.Core.PaymentRule.Action> Actions { get; set; }

        IDbSet<TEntity> IUnitOfWork.Set<TEntity>()
        {
            if (typeof(TEntity) == typeof(Product))
            {
                var list = new FakeDbSet<Product>();
                return (IDbSet<TEntity>)list;
            }
            else if (typeof(TEntity) == typeof(ProductTag))
            {
                var list = new FakeDbSet<ProductTag>();
                return (IDbSet<TEntity>)list;
            }
            else if (typeof(TEntity) == typeof(Payment))
            {
                var list = new FakeDbSet<Payment>();
                return (IDbSet<TEntity>)list;
            }
            else if (typeof(TEntity) == typeof(PaymentRule))
            {
                var list = new FakeDbSet<PaymentRule>();
                return (IDbSet<TEntity>)list;
            }
            else if (typeof(TEntity) == typeof(Criteria))
            {
                var list = new FakeDbSet<Criteria>();
                return (IDbSet<TEntity>)list;
            }
            else if (typeof(TEntity) == typeof(PlanDay.Assignment.Core.PaymentRule.Action))
            {
                var list = new FakeDbSet<PlanDay.Assignment.Core.PaymentRule.Action>();
                return (IDbSet<TEntity>)list;
            }

            throw new NotImplementedException();
        }

        public void RejectChanges()
        {
            throw new NotImplementedException();
        }

        public DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
