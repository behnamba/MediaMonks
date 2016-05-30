using PlanDay.Assignment.Core.PaymentRule;
using PlanDay.Assignment.Core.Product;
using PlanDay.Assignment.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDay.Assignment.Service
{
    public class PaymentRuleService : Base.AssignmentService<PaymentRule>, IPaymentRuleService
    {
        public PaymentRuleService(IUnitOfWork unitofWork) : base(unitofWork)
        {
        }
    }
}
