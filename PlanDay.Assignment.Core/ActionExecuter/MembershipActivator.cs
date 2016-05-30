using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDay.Assignment.Core.ActionExecuter
{
    public class MembershipActivator : ActionExecuter
    {
        public MembershipActivator(string description) : base(description)
        {
        }

        public override void Execute(Payment.Payment payment)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("Membership active for, {0} <br />", Description));

            // log
            string path = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
            Common.IO.FileHelper.Writefile(string.Format("{0}\\log.txt", path), sb.ToString());
        }
    }
}
