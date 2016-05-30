using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDay.Assignment.Common.DDD
{
    public abstract class ValueObjectBase
    {
        public ValueObjectBase()
        {
        }

        protected abstract void Validate();        
    }
}
