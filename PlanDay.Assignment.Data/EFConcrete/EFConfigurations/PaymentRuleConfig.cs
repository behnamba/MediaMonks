using PlanDay.Assignment.Core.Payment;
using PlanDay.Assignment.Core.PaymentRule;
using System.Data.Entity.ModelConfiguration;

namespace PlanDay.Assignment.Data.EFConfigurations
{
    public class PaymentRuleConfig : EntityTypeConfiguration<PaymentRule>
    {
        public PaymentRuleConfig()
        {
            this.Property(p => p.Name).IsRequired();
        }
    }
}
