using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDay.Assignment.Common.IO
{
    public interface IPathMapper
    {
        string MapPath(string relativePath);
    }
}
