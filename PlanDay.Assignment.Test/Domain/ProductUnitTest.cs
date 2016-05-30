using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlanDay.Assignment.Core.Product;
using PlanDay.Assignment.Common.Exceptions;

namespace PlanDay.Test.UnitTest.Domain
{
    [TestClass]
    public class ProductUnitTest
    {
        public ProductUnitTest()
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
            Product p = new Product();

            // Action 
            p.Title = "";
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPriceValue))]
        public void Product_NegetivePrice_Fail()
        {
            // Arrange
            Product p = new Product();

            // Action 
            p.Price = -1;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPriceValue))]
        public void Product_ZeroPrice_Fail()
        {
            // Arrange
            Product p = new Product();

            // Action 
            p.Price = 0;
        }
    }
}
