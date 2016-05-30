using PlanDay.Assignment.Core;
using PlanDay.Assignment.Core.Payment;
using PlanDay.Assignment.Core.PaymentRule;
using PlanDay.Assignment.Core.Product;
using PlanDay.Assignment.Data.Base;
using PlanDay.Assignment.Data.EFConfigurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDay.Assignment.Data.EFConcrete
{
    public class TestDataContext : DbContext, IUnitOfWork
    {
        public TestDataContext() : base()
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentRule> PaymentRules { get; set; }
        public DbSet<Criteria> Criterias { get; set; }
        public DbSet<PlanDay.Assignment.Core.PaymentRule.Action> Actions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // load the configurations 
            modelBuilder.Configurations.Add(new ProductConfig()); 
            modelBuilder.Configurations.Add(new ProductTagConfig()); 
            modelBuilder.Configurations.Add(new PaymentConfig()); 
        }

        IDbSet<TEntity> IUnitOfWork.Set<TEntity>()
        {
            return Set<TEntity>();
        }

        public void RejectChanges()
        {
            //throw new NotImplementedException();
        }
    }
}
