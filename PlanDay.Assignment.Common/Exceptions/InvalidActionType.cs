using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDay.Assignment.Common.Exceptions
{
    public class InvalidActionType : Exception
    {
        public InvalidActionType(string message)
            : base(string.Format("{0} {1}", message, " - Invalid action type!"))
        { }
    }
}
