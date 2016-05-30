using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDay.Assignment.Core.ActionExecuter
{
    public class AddCommision : ActionExecuter
    {
        public AddCommision(string description) : base(description)
        {
        }

        public override void Execute(Payment.Payment payment)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("Add some commission, {0} <br />", Description));
          
            Console.WriteLine(sb.ToString());
        }
    }
}
