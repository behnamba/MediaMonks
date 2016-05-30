using PlanDay.Assignment.Core.Product;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDay.Assignment.Data.EFConfigurations
{
    public class ProductTagConfig : EntityTypeConfiguration<ProductTag>
    {
        public ProductTagConfig()
        {
            this.Property(p => p.Name).IsRequired();
            this.Property(p => p.Name).HasMaxLength(20);
        }
    }
}
