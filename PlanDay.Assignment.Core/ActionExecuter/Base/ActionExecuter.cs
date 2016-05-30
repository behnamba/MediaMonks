using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDay.Assignment.Core.ActionExecuter
{
    public abstract class ActionExecuter
    {
        public string Description { get; set; }

        public ActionExecuter(string description)
        {
            this.Description = description;
        }

        public abstract void Execute(Payment.Payment payment);
    }
}
