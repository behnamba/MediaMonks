using PlanDay.Assignment.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDay.Assignment.Core.PaymentRule
{
    public class PaymentRuleHandler : IPaymentRuleHandler
    {
        public bool IsRuleMatchForPayment(Payment.Payment payment, List<Criteria> criterias)
        {
            if (criterias == null || criterias.Count == 0)
            {
                throw new RequiredException("Criteria's is required");
            }

            // if one criteria is available 
            if (criterias.Count == 1)
            {
                return criterias[0].IsMatched(payment);
            }

            // chained criteria    
            bool ruleMatchedToPayment = true;
            foreach (var item in criterias)
            {
                bool criteriaMtched = item.IsMatched(payment);

                if (item.ChainedCriteria == ChainedCriteria.And)
                {
                    ruleMatchedToPayment = ruleMatchedToPayment && criteriaMtched;
                }
                else if (item.ChainedCriteria == ChainedCriteria.Or)
                {
                    ruleMatchedToPayment = ruleMatchedToPayment || criteriaMtched;
                }

                // not matched
                if (ruleMatchedToPayment == false)
                {
                    break;
                }
            }

            return ruleMatchedToPayment;
        }
    }
}
