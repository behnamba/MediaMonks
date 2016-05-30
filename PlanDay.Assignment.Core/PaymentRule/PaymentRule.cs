using PlanDay.Assignment.Common.DDD;
using PlanDay.Assignment.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDay.Assignment.Core.PaymentRule
{
    public class PaymentRule : EntityBase, IAggregateRoot
    {
        IPaymentRuleHandler _RuleHandler;

        public PaymentRule(IPaymentRuleHandler handler)
        {
            _RuleHandler = handler;
        }

        public PaymentRule()
        {
            _RuleHandler = new PaymentRuleHandler();
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
        public List<Criteria> Criterias { get; set; }
        public List<Action> Actions { get; set; }

        public bool IsRuleMatchForPayment(Payment.Payment payment)
        {
            return _RuleHandler.IsRuleMatchForPayment(payment, this.Criterias);
        }

        protected override void Validate()
        {
            if (Actions == null || Actions.Count == 0)
            {
                throw new RequiredException("Actions is required");
            }
        }
    }
}
