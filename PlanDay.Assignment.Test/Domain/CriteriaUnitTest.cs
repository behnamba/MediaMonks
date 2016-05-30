using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlanDay.Assignment.Core.PaymentRule;
using PlanDay.Assignment.Core.Payment;

namespace PlanDay.Test.UnitTest.Domain
{
    /// <summary>
    /// Summary description for CriteriaUnitTest
    /// </summary>
    [TestClass]
    public class CriteriaUnitTest
    {
        public CriteriaUnitTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        ICriteriaRuleHandler sut;

        [TestInitialize()]
        public void Initialize()
        {
            sut = new CriteriaRuleHandler();
        }

        [TestCleanup()]
        public void Cleanup()
        {
            sut = null;
        }


        [TestMethod]
        public void CriteriaRulehandler_IsMatched_If_ProductTag_Equal_To_Payment_ProductTag()
        {
            // arrange
            Criteria criteria = new Criteria(sut);
            criteria.CriteriaType = CriteriaType.ProductTag;
            criteria.CriteriaOperator = CriteriaOperator.Equal;
            criteria.Value = "1";

            Payment payment = new Payment
            {
                Product = new PlanDay.Assignment.Core.Product.Product
                {
                    ProductTag = new List<PlanDay.Assignment.Core.Product.ProductTag>
                    {
                        new PlanDay.Assignment.Core.Product.ProductTag
                        {
                            Id = 1
                        }
                    }
                }
            };

            // action
            var result = sut.IsMatched(payment, criteria);

            // assert
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void CriteriaRulehandler_IsMatched_Return_False_If_ProductTag_Not_Equal_To_Payment_ProductTag()
        {
            // arrange
            Criteria criteria = new Criteria(sut);
            criteria.CriteriaType = CriteriaType.ProductTag;
            criteria.CriteriaOperator = CriteriaOperator.Equal;
            criteria.Value = "1";

            Payment payment = new Payment
            {
                Product = new PlanDay.Assignment.Core.Product.Product
                {
                    ProductTag = new List<PlanDay.Assignment.Core.Product.ProductTag>
                    {
                        new PlanDay.Assignment.Core.Product.ProductTag
                        {
                            Id = 2
                        }
                    }
                }
            };

            // action
            var result = sut.IsMatched(payment, criteria);

            // assert
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void CriteriaRulehandler_IsMatched_If_ProductId_Equal_To_Payment_ProductId()
        {
            // arrange
            Criteria criteria = new Criteria(sut);
            criteria.CriteriaType = CriteriaType.ProductId;
            criteria.CriteriaOperator = CriteriaOperator.Equal;
            criteria.Value = "1";

            Payment payment = new Payment
            {
                Product = new PlanDay.Assignment.Core.Product.Product
                {
                    Id = 1
                }
            };

            // action
            var result = sut.IsMatched(payment, criteria);

            // assert
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void CriteriaRulehandler_IsMatched_Return_False_If_ProductId_Not_Equal_To_Payment_ProductId()
        {
            // arrange
            Criteria criteria = new Criteria(sut);
            criteria.CriteriaType = CriteriaType.ProductId;
            criteria.CriteriaOperator = CriteriaOperator.Equal;
            criteria.Value = "1";

            Payment payment = new Payment
            {
                Product = new PlanDay.Assignment.Core.Product.Product
                {
                    Id = 2
                }
            };

            // action
            var result = sut.IsMatched(payment, criteria);

            // assert
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void CriteriaRulehandler_IsMatched_If_Price_Equal_To_Payment_ProductPrice()
        {
            // arrange
            Criteria criteria = new Criteria(sut);
            criteria.CriteriaType = CriteriaType.ProductPrice;
            criteria.CriteriaOperator = CriteriaOperator.Equal;
            criteria.Value = "10";

            Payment payment = new Payment
            {
                Product = new PlanDay.Assignment.Core.Product.Product
                {
                    Price = 10
                }
            };

            // action
            var result = sut.IsMatched(payment, criteria);

            // assert
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void CriteriaRulehandler_IsMatched_Return_False_If_Price_Not_Equal_To_Payment_ProductPrice()
        {
            // arrange
            Criteria criteria = new Criteria(sut);
            criteria.CriteriaType = CriteriaType.ProductPrice;
            criteria.CriteriaOperator = CriteriaOperator.Equal;
            criteria.Value = "1";

            Payment payment = new Payment
            {
                Product = new PlanDay.Assignment.Core.Product.Product
                {
                    Price = 10
                }
            };

            // action
            var result = sut.IsMatched(payment, criteria);

            // assert
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void CriteriaRulehandler_IsMatched_If_Payment_ProductPrice_Bigger_Than_Criteria_Price()
        {
            // arrange
            Criteria criteria = new Criteria(sut);
            criteria.CriteriaType = CriteriaType.ProductPrice;
            criteria.CriteriaOperator = CriteriaOperator.BiggerThan;
            criteria.Value = "10";

            Payment payment = new Payment
            {
                Product = new PlanDay.Assignment.Core.Product.Product
                {
                    Price = 11
                }
            };

            // action
            var result = sut.IsMatched(payment, criteria);

            // assert
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void CriteriaRulehandler_IsMatched_Return_False_If_Payment_ProductPrice_IsNot_Bigger_Than_Criteria_Price()
        {
            // arrange
            Criteria criteria = new Criteria(sut);
            criteria.CriteriaType = CriteriaType.ProductPrice;
            criteria.CriteriaOperator = CriteriaOperator.BiggerThan;
            criteria.Value = "10";

            Payment payment = new Payment
            {
                Product = new PlanDay.Assignment.Core.Product.Product
                {
                    Price = 9
                }
            };

            // action
            var result = sut.IsMatched(payment, criteria);

            // assert
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void CriteriaRulehandler_IsMatched_If_Payment_ProductPrice_Less_Than_Criteria_Price()
        {
            // arrange
            Criteria criteria = new Criteria(sut);
            criteria.CriteriaType = CriteriaType.ProductPrice;
            criteria.CriteriaOperator = CriteriaOperator.LessThan;
            criteria.Value = "10";

            Payment payment = new Payment
            {
                Product = new PlanDay.Assignment.Core.Product.Product
                {
                    Price = 9
                }
            };

            // action
            var result = sut.IsMatched(payment, criteria);

            // assert
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void CriteriaRulehandler_IsMatched_Return_False_If_Payment_ProductPrice_IsNot_Less_Than_Criteria_Price()
        {
            // arrange
            Criteria criteria = new Criteria(sut);
            criteria.CriteriaType = CriteriaType.ProductPrice;
            criteria.CriteriaOperator = CriteriaOperator.LessThan;
            criteria.Value = "10";

            Payment payment = new Payment
            {
                Product = new PlanDay.Assignment.Core.Product.Product
                {
                    Price = 11
                }
            };

            // action
            var result = sut.IsMatched(payment, criteria);

            // assert
            Assert.AreEqual(result, false);
        }
    }
}
