using PlanDay.Assignment.Common.DDD;
using PlanDay.Assignment.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDay.Assignment.Core.Product
{
    public class Product : EntityBase
    {
        public Product()
        {
            ProductTag = new List<Core.Product.ProductTag>();
        }

        string _Title;
        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new RequiredException("Title is required");
                }
                _Title = value;
            }
        }

        decimal _Price;
        public decimal Price
        {
            get
            {
                return _Price;
            }
            set
            {
                if (value <= 0)
                {
                    throw new InvalidPriceValue("Negative value is not allowed");
                }
                _Price = value;
            }
        }
        public List<ProductTag> ProductTag { get; set; }

        protected override void Validate()
        {
        }
    }
}
