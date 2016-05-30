using PlanDay.Assignment.Core.Product;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDay.Assignment.Data.EFConfigurations
{
    public class ProductConfig : EntityTypeConfiguration<Product>
    {
        public ProductConfig()
        {
            this.Property(p => p.Price).IsRequired();
            this.Property(p => p.Title).IsRequired();
        }
    }
}
