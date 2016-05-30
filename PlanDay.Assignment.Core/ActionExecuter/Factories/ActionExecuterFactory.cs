using PlanDay.Assignment.Common.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PlanDay.Assignment.Core.ActionExecuter.Factories
{
    public class ActionExecuterFactory : IActionExecuterFactory
    {
        const string CacheKey = "ActionList";

        Dictionary<string, Type> _Actions;

        public ActionExecuterFactory(ICacheProvider cacheProvider)
        {
            LoadTypesICanReturn(cacheProvider);
        }

        public ActionExecuter CreateActionExecuter(string typeName, string description)
        {
            Type t = GetTypeToCreate(typeName);

            if (t == null)
                throw new InvalidOperationException("Action type name is not valid");
            return Activator.CreateInstance(t, description) as ActionExecuter;
        }

        private Type GetTypeToCreate(string typeName)
        {
            if (_Actions.Count(p => p.Key.Equals(typeName)) == 0)
                return null;

            return _Actions.Single(p => p.Key.Equals(typeName)).Value;
        }

        private void LoadTypesICanReturn(ICacheProvider cacheProvider)
        {
            _Actions = new Dictionary<string, Type>();

            // check if actions are availble in cache 
            if (cacheProvider.Exists(CacheKey))
            {
                _Actions = (Dictionary<string, Type>)cacheProvider.Get<Dictionary<string, Type>>(CacheKey);
                return;
            }

            // load actions and save in cache 
            Type[] typesInThisAssembly = Assembly.GetExecutingAssembly().GetTypes().Where(p => p.IsClass && p.IsSubclassOf(typeof(ActionExecuter))).ToArray();

            foreach (Type type in typesInThisAssembly)
            {
                _Actions.Add(type.ToString(), type);
            }

            cacheProvider.Add<Dictionary<string, Type>>(_Actions, CacheKey);
        }
    }
}
