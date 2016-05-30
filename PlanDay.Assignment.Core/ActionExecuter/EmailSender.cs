using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDay.Assignment.Core.ActionExecuter
{
    public class EmailSender : ActionExecuter
    {
        public EmailSender(string description) : base(description)
        {
        }

        public override void Execute(Payment.Payment payment)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("Send email, {0} <br />", Description));
                       Console.WriteLine(sb.ToString());
        }
    }
}
