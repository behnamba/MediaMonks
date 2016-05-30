using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDay.Assignment.Core.PaymentRule
{
    public interface ICriteriaRuleHandler
    {
        bool IsMatched(Payment.Payment payment, Criteria cirteria);
    }
}
