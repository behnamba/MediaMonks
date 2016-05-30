using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanDay.Assignment.Common.DDD;
using PlanDay.Assignment.Common.Exceptions;

namespace PlanDay.Assignment.Core.Payment
{
    public enum PaymentStatus
    {
        Confirmed,
        Rejected
    }

    public class Payment : EntityBase, IAggregateRoot
    {
        public DateTime CreatedDate { get; set; }
        public PaymentStatus Status { get; set; }
        public Product.Product Product { get; set; }

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

        protected override void Validate()
        {
        }
    }
}
