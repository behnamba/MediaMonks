using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlanDay.Assignment.Core.RuleEngine;
using PlanDay.Assignment.Core.PaymentRule;
using Moq;
using PlanDay.Assignment.Core.Payment;
using PlanDay.Assignment.Core.ActionExecuter;

namespace PlanDay.Test.UnitTest.Domain
{
    /// <summary>
    /// Summary description for RuleEngineUnitTest
    /// </summary>
    [TestClass]
    public class RuleEngineUnitTest
    {
        public RuleEngineUnitTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        PaymentRuleEngine sut;
        Mock<IPaymentRuleHandler> positivePaymentRuleHandler;

        [TestInitialize()]
        public void Initialize()
        {
                        positivePaymentRuleHandler = new Mock<IPaymentRuleHandler>();
            positivePaymentRuleHandler.Setup(x => x.IsRuleMatchForPayment(It.IsAny<Payment>(), It.IsAny<List<Criteria>>())).Returns(true);
        }

        [TestCleanup()]
        public void Cleanup()
        {
            sut = null;
        }

        //[TestMethod]
        //public void Action_Execute_Per_IsMatchedRule()
        //{
        //    int count = 1;

        //    Mock<ActionExecuter> actionExecuter = new Mock<ActionExecuter>();
        //    actionExecuter.Setup(p => p.Execute(It.IsAny<Payment>())).Callback(() => count++);

        //    PaymentRule paymentRule = new PaymentRule(positivePaymentRuleHandler.Object);
        //    paymentRule.Actions = new List<Assignment.Core.PaymentRule.Action>();
        //    paymentRule.Actions.Add(actionExecuter.Object);
        //    paymentRule.Actions.Add(actionExecuter.Object);

        //}
    }
}
