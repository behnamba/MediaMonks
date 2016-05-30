using PlanDay.Assignment.Common.DDD;
using PlanDay.Assignment.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDay.Assignment.Core.Product
{
    public class ProductTag : EntityBase, IAggregateRoot
    {
        public ProductTag()
        {
            Products = new List<Product>();
        }

        string _Name;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new RequiredException("Title is required");
                }
                _Name = value;
            }
        }

        public List<Product> Products { get; set; }

        protected override void Validate()
        {

        }
    }
}
