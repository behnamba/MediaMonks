using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PlanDay.Assignment.Common.Cache
{
    public class WebCacheProvider : Common.Cache.ICacheProvider
    {
        int _CacheExpirationMinutes = 120;
        public int CacheExpirationMinutes
        {
            get
            {
                return _CacheExpirationMinutes;
            }
            set
            {
                _CacheExpirationMinutes = value;
            }
        }

        public bool Exists(string key)
        {
            return HttpContext.Current.Cache[key] != null;
        }


        public void Add<T>(T o, string key) where T : class
        {
            System.Web.HttpRuntime.Cache.Insert(key, o, null, DateTime.Now.AddMinutes(CacheExpirationMinutes), System.Web.Caching.Cache.NoSlidingExpiration);
        }

        public void Clear(string key)
        {
            System.Web.HttpRuntime.Cache.Remove(key);
        }

        public T Get<T>(string key) where T : class
        {
            try
            {
                return (T)System.Web.HttpRuntime.Cache[key];
            }
            catch
            {
                return null;
            }
        }
    }
}
