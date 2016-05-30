using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlanDay.Assignment.Core.Product;
using PlanDay.Assignment.Common.Exceptions;

namespace PlanDay.Test.UnitTest.Domain
{
    [TestClass]
    public class ProductTagUnitTest
    {
        public ProductTagUnitTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [TestMethod]
        [ExpectedException(typeof(RequiredException))]
        public void Product_EmptyName_Fail()
        {
            // Arrange
            ProductTag p = new ProductTag();

            // Action 
            p.Name = "";
        }
    }
}
