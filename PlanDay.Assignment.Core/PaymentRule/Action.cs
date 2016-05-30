using PlanDay.Assignment.Common.DDD;
using PlanDay.Assignment.Common.Exceptions;
using System;

namespace PlanDay.Assignment.Core.PaymentRule
{
    public class Action : EntityBase
    {
        string _Name;
        public String Name
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

        string _Type;
        public string Type
        {
            get
            {
                return _Type;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new RequiredException("Title is required");
                }
                _Type = value;
            }
        }

        public PaymentRule PaymentRule { get; set; }

        protected override void Validate()
        {
        }
    }
}