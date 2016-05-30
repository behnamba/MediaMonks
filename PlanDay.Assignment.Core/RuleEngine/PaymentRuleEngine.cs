using PlanDay.Assignment.Common.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDay.Assignment.Core.RuleEngine
{
    public class PaymentRuleEngine
    {
        private PaymentRuleEngine(ICacheProvider cacheProvider)
        {
            Rules = new List<PaymentRule.PaymentRule>();
            _CacheProvider = cacheProvider;
        }

        private static readonly Lazy<PaymentRuleEngine> lazy = new Lazy<PaymentRuleEngine>(() => new PaymentRuleEngine(_CacheProvider));

        public static ICacheProvider _CacheProvider;

        private static PaymentRuleEngine _Engine;
        public static PaymentRuleEngine Engine(ICacheProvider cahceProvider)
        {
            if (_Engine == null)
            {
                _CacheProvider = cahceProvider;
                return lazy.Value;
            }

            return _Engine;
        }

        public List<PaymentRule.PaymentRule> Rules { get; set; }

        public void ProcessPayment(Payment.Payment payment, string description)
        {
            // TODO: support transactions !!!
            foreach (var rule in Rules)
            {
                if (rule.IsRuleMatchForPayment(payment))
                {
                    foreach (var item in rule.Actions)
                    {
                        var action = new ActionExecuter.Factories.ActionExecuterFactory(_CacheProvider).CreateActionExecuter(item.Type, description);
                        action.Execute(payment);
                    }
                }
            }
        }
    }
}
