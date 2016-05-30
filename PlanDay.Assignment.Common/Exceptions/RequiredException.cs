using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDay.Assignment.Common.Exceptions
{
    public class RequiredException : Exception
    {
        public RequiredException(string message)
            : base(string.Format("{0} {1}", message, " - No value is not allowed for this property"))
        { }
    }
}
