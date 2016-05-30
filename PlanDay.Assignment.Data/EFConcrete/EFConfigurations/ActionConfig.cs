using PlanDay.Assignment.Core.PaymentRule;
using PlanDay.Assignment.Core.Product;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDay.Assignment.Data.EFConfigurations
{
    public class ActionConfig : EntityTypeConfiguration<Action>
    {
        public ActionConfig()
        {
            this.Property(p => p.Name).IsRequired();
            this.Property(p => p.Type).IsRequired();
        }
    }
}
