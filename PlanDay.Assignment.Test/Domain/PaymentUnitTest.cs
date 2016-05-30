using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlanDay.Assignment.Common.Exceptions;
using PlanDay.Assignment.Core.Payment;

namespace PlanDay.Test.UnitTest.Domain
{
    /// <summary>
    /// Summary description for PaymentRuleUnitTest
    /// </summary>
    [TestClass]
    public class PaymentUnitTest
    {
        public PaymentUnitTest()
        {
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPriceValue))]
        public void Payment_NegetivePrice_Fail()
        {
            // Arrange
            Payment p = new Payment();

            // Action 
            p.Price = -1;
        }
    }
}
