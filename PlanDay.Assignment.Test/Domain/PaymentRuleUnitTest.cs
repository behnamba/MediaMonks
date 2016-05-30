using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlanDay.Assignment.Common.Exceptions;
using PlanDay.Assignment.Core.Payment;
using PlanDay.Assignment.Core.PaymentRule;
using Moq;

namespace PlanDay.Test.UnitTest.Domain
{
    [TestClass]
    public class PaymentRuleUnitTest
    {
        public PaymentRuleUnitTest()
        {
        }

        PaymentRule sut;

        [TestInitialize()]
        public void Initialize()
        {
            sut = new PaymentRule(new PaymentRuleHandler());
            sut.Criterias = new List<Criteria>();
            sut.Actions = new List<PlanDay.Assignment.Core.PaymentRule.Action>();
        }

        [TestCleanup()]
        public void Cleanup()
        {
            sut = null;
        }

        [TestMethod]
        [ExpectedException(typeof(RequiredException))]
        public void PaymentRule_EmptyName_Fail()
        {
            // Action 
            sut.Name = "";
        }

        [TestMethod]
        [ExpectedException(typeof(RequiredException))]
        public void PaymentRule_IsRuleMatched_Failed_For_NoCriteria()
        {
            // Action 
            sut.IsRuleMatchForPayment(new Payment());
        }

        [TestMethod]
        public void IsRuleMatched_Return_True_If_Single_Criteria_IsMatched()
        {
            // Arrange
            Mock<ICriteriaRuleHandler> criteriaRuleHandler = new Mock<ICriteriaRuleHandler>();
            criteriaRuleHandler.Setup(x => x.IsMatched(It.IsAny<Payment>(), It.IsAny<Criteria>())).Returns(true);

            sut.Criterias.Add(new Criteria(criteriaRuleHandler.Object));

            var a = sut.Criterias[0].IsMatched(new Payment());

            // Action and assert
            Assert.AreEqual(sut.IsRuleMatchForPayment(new Payment()), true);
        }

        [TestMethod]
        public void IsRuleMatched_Return_False_If_Single_Criteria_IsMatched()
        {
            // Arrange
            Mock<ICriteriaRuleHandler> criteriaRuleHandler = new Mock<ICriteriaRuleHandler>();
            criteriaRuleHandler.Setup(x => x.IsMatched(It.IsAny<Payment>(), It.IsAny<Criteria>())).Returns(false);

            sut.Criterias.Add(new Criteria(criteriaRuleHandler.Object));

            // Action and assert
            Assert.AreEqual(sut.IsRuleMatchForPayment(new Payment()), false);
        }

        [TestMethod]
        public void IsRuleMatched_Return_True_If_Multiple_Criteria_Chained_With_OR_And_All_IsMatched()
        {
            // Arrange
            Mock<ICriteriaRuleHandler> criteriaRuleHandler = new Mock<ICriteriaRuleHandler>();
            criteriaRuleHandler.Setup(x => x.IsMatched(It.IsAny<Payment>(), It.IsAny<Criteria>())).Returns(true);

            Criteria c1 = new Criteria(criteriaRuleHandler.Object);
            c1.ChainedCriteria = ChainedCriteria.Or;
            sut.Criterias.Add(c1);

            Criteria c2 = new Criteria(criteriaRuleHandler.Object);
            c2.ChainedCriteria = ChainedCriteria.Or;
            sut.Criterias.Add(c2);

            Criteria c3 = new Criteria(criteriaRuleHandler.Object);
            c3.ChainedCriteria = ChainedCriteria.Or;
            sut.Criterias.Add(c3);

            // Action and assert
            Assert.AreEqual(sut.IsRuleMatchForPayment(new Payment()), true);
        }

        [TestMethod]
        public void IsRuleMatched_Return_True_If_Multiple_Criteria_Chained_With_And_And_All_IsMatched()
        {
            // Arrange
            Mock<ICriteriaRuleHandler> criteriaRuleHandler = new Mock<ICriteriaRuleHandler>();
            criteriaRuleHandler.Setup(x => x.IsMatched(It.IsAny<Payment>(), It.IsAny<Criteria>())).Returns(true);

            Criteria c1 = new Criteria(criteriaRuleHandler.Object);
            c1.ChainedCriteria = ChainedCriteria.And;
            sut.Criterias.Add(c1);

            Criteria c2 = new Criteria(criteriaRuleHandler.Object);
            c2.ChainedCriteria = ChainedCriteria.And;
            sut.Criterias.Add(c2);

            Criteria c3 = new Criteria(criteriaRuleHandler.Object);
            c3.ChainedCriteria = ChainedCriteria.And;
            sut.Criterias.Add(c3);

            // Action and assert
            Assert.AreEqual(sut.IsRuleMatchForPayment(new Payment()), true);
        }

        [TestMethod]
        public void IsRuleMatched_Return_False_If_Multiple_Criteria_Chained_With_And_All_Not_IsMatched()
        {
            // Arrange
            Mock<ICriteriaRuleHandler> criteriaRuleHandler = new Mock<ICriteriaRuleHandler>();
            criteriaRuleHandler.Setup(x => x.IsMatched(It.IsAny<Payment>(), It.IsAny<Criteria>())).Returns(true);

            Mock<ICriteriaRuleHandler> criteriaRuleHandlerIsNotMatched = new Mock<ICriteriaRuleHandler>();
            criteriaRuleHandlerIsNotMatched.Setup(x => x.IsMatched(It.IsAny<Payment>(), It.IsAny<Criteria>())).Returns(false);

            Criteria c1 = new Criteria(criteriaRuleHandler.Object);
            c1.ChainedCriteria = ChainedCriteria.And;
            sut.Criterias.Add(c1);

            Criteria c2 = new Criteria(criteriaRuleHandler.Object);
            c2.ChainedCriteria = ChainedCriteria.And;
            sut.Criterias.Add(c2);

            Criteria c3 = new Criteria(criteriaRuleHandlerIsNotMatched.Object);
            c3.ChainedCriteria = ChainedCriteria.And;
            sut.Criterias.Add(c3);

            // Action and assert
            Assert.AreEqual(sut.IsRuleMatchForPayment(new Payment()), false);
        }

        [TestMethod]
        public void IsRuleMatched_Return_True_If_Multiple_Criteria_Chained_OR_And_One_Not_IsMatched()
        {
            // Arrange
            Mock<ICriteriaRuleHandler> criteriaRuleHandler = new Mock<ICriteriaRuleHandler>();
            criteriaRuleHandler.Setup(x => x.IsMatched(It.IsAny<Payment>(), It.IsAny<Criteria>())).Returns(true);

            Mock<ICriteriaRuleHandler> criteriaRuleHandlerIsNotMatched = new Mock<ICriteriaRuleHandler>();
            criteriaRuleHandlerIsNotMatched.Setup(x => x.IsMatched(It.IsAny<Payment>(), It.IsAny<Criteria>())).Returns(false);

            Criteria c1 = new Criteria(criteriaRuleHandler.Object);
            c1.ChainedCriteria = ChainedCriteria.Or;
            sut.Criterias.Add(c1);

            Criteria c2 = new Criteria(criteriaRuleHandler.Object);
            c2.ChainedCriteria = ChainedCriteria.Or;
            sut.Criterias.Add(c2);

            Criteria c3 = new Criteria(criteriaRuleHandlerIsNotMatched.Object);
            c3.ChainedCriteria = ChainedCriteria.Or;
            sut.Criterias.Add(c3);

            // Action and assert
            Assert.AreEqual(sut.IsRuleMatchForPayment(new Payment()), true);
        }
    }
}
