using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDay.Assignment.Core.ActionExecuter.Factories
{
    public interface IActionExecuterFactory
    {
        ActionExecuter CreateActionExecuter(string typeName, string description);
    }
}
