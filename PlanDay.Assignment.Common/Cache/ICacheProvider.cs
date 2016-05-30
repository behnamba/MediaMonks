using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDay.Assignment.Common.Cache
{
    public interface ICacheProvider 
    {
        int CacheExpirationMinutes { get; set; }

        void Add<T>(T o, string key) where T : class;

        T Get<T>(string key) where T : class;

        bool Exists(string key);
    }
}
