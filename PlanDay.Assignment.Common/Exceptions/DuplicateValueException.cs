using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDay.Assignment.Common.Exceptions
{
    public class DuplicatevalueException : Exception
    {
        public DuplicatevalueException(string message)
            : base(string.Format("{0} {1}", message, " - Duplicate value is not allowed for this object"))
        { }
    }
}