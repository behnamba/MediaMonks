using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDay.Assignment.Core.PaymentRule
{
    public class CriteriaRuleHandler : ICriteriaRuleHandler
    {
        public bool IsMatched(Payment.Payment payment, Criteria cirteria)
        {
            bool criteriaMatched = false;

            // check the CriteriaType 
            switch (cirteria.CriteriaType)
            {
                case CriteriaType.ProductTag:
                    {
                        if (cirteria.CriteriaOperator == CriteriaOperator.Equal)
                        {
                            // if payment is done for this productTag
                            if (payment.Product.ProductTag.Where(p => p.Id == int.Parse(cirteria.Value)).Count() > 0)
                            {
                                criteriaMatched = true;
                            }
                        }
                        break;
                    }
                case CriteriaType.ProductId:
                    {
                        if (cirteria.CriteriaOperator == CriteriaOperator.Equal)
                        {
                            // if payment is done for this product
                            if (payment.Product.Id == int.Parse(cirteria.Value))
                            {
                                criteriaMatched = true;
                            }
                        }
                        break;
                    }
                case CriteriaType.ProductPrice:
                    {
                        if (cirteria.CriteriaOperator == CriteriaOperator.Equal)
                        {
                            // if payment price is equal with criteria value
                            if (payment.Product.Price == decimal.Parse(cirteria.Value.ToString()))
                            {
                                criteriaMatched = true;
                            }
                        }
                        else if (cirteria.CriteriaOperator == CriteriaOperator.BiggerThan)
                        {
                            // if payment price is equal with criteria value
                            if (payment.Product.Price > decimal.Parse(cirteria.Value.ToString()))
                            {
                                criteriaMatched = true;
                            }
                        }
                        else if (cirteria.CriteriaOperator == CriteriaOperator.LessThan)
                        {
                            // if payment price is equal with criteria value
                            if (payment.Product.Price < decimal.Parse(cirteria.Value.ToString()))
                            {
                                criteriaMatched = true;
                            }
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            return criteriaMatched;
        }
    }
}
