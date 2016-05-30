using PlanDay.Assignment.Core.Product;
using PlanDay.Assignment.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace PlanDay.Assignment.Service
{
    public class ProductTagService : Base.AssignmentService<ProductTag>, IProductTagService
    {
        public ProductTagService(IUnitOfWork unitofWork) : base(unitofWork)
        {
        }

       
    }
}
