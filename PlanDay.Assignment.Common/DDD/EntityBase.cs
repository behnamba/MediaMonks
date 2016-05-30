using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDay.Assignment.Common.DDD
{
    public abstract class EntityBase
    {
        public int Id { get; set; }

        public override bool Equals(object entity)
        {
            if (entity != null && this == (EntityBase)entity)
            {
                return true;
            }

            return false;
        }

        protected abstract void Validate();

        public static bool operator ==(EntityBase entity1, EntityBase entity2)
        {
            if ((object)entity1 == null && (object)entity2 == null)
            {
                return true;
            }

            if ((object)entity1 == null || (object)entity2 == null)
            {
                return false;
            }

            if (entity1.Id.ToString() == entity2.Id.ToString())
            {
                return true;
            }

            return false;
        }

        public static bool operator !=(EntityBase entity1, EntityBase entity2)
        {
            if ((entity1 == entity2) == false)
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
