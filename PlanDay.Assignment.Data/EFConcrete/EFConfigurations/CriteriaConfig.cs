using PlanDay.Assignment.Core.PaymentRule;
using PlanDay.Assignment.Core.Product;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDay.Assignment.Data.EFConfigurations
{
    public class CriteriaConfig : EntityTypeConfiguration<Criteria>
    {
        public CriteriaConfig()
        {
            this.Property(p => p.CriteriaType).IsRequired();
        }
    }
}
