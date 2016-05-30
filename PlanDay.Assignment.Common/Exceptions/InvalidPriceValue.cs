using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDay.Assignment.Common.Exceptions
{
    public class InvalidPriceValue : Exception
    {
        public InvalidPriceValue(string message)
            : base(string.Format("{0} {1}", message, " - Invalid price value"))
        { }

    }
}
