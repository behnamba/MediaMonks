using System;
using System.Linq;
using PlanDay.Assignment.Common.DDD;

namespace PlanDay.Assignment.Core.PaymentRule
{
    public enum CriteriaType
    {
        ProductTag = 0,
        ProductId = 1,
        ProductPrice = 2
    }

    public enum CriteriaOperator
    {
        Equal = 0,
        BiggerThan = 1,
        LessThan = 2
    }

    public enum ChainedCriteria
    {
        And = 0,
        Or = 1
    }

    public class Criteria : EntityBase
    {
        ICriteriaRuleHandler _CriteriaRuleHandler;

        public CriteriaType CriteriaType { get; set; }
        public CriteriaOperator CriteriaOperator { get; set; }
        public string Value { get; set; }
        public ChainedCriteria ChainedCriteria { get; set; }
        public PaymentRule PaymentRule { get; set; }

        public Criteria(ICriteriaRuleHandler criteriaRuleHandler)
        {
            _CriteriaRuleHandler = criteriaRuleHandler;
        }

        public Criteria()
        {
            _CriteriaRuleHandler = new CriteriaRuleHandler();
        }

        public bool IsMatched(Payment.Payment payment)
        {
            return _CriteriaRuleHandler.IsMatched(payment, this);
        }

        protected override void Validate()
        {
        }
    }
}