using PlanDay.Assignment.Core.Payment;
using System.Data.Entity.ModelConfiguration;

namespace PlanDay.Assignment.Data.EFConfigurations
{
    public class PaymentConfig : EntityTypeConfiguration<Payment>
    {
        public PaymentConfig()
        {
            this.Property(p => p.Price).IsRequired();
            this.Property(p => p.Status).IsRequired();
        }
    }
}
