using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDay.Assignment.Core.ActionExecuter
{
    public class PackageSlip : ActionExecuter
    {
        public PackageSlip(string description) : base(description)
        {
        }

        public override void Execute(Payment.Payment payment)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("Issue a package slip, {0} <br />", Description));

            string path = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
            Common.IO.FileHelper.Writefile(string.Format("{0}\\log.txt", path), sb.ToString());
        }
    }
}
