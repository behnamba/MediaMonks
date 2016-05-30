using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlanDay.Assignment.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDay.Assignment.Test.Web
{
    [TestClass]
    public class PaymentViewModelUnitTest
    {
        PaymentViewModel sut;

        public PaymentViewModelUnitTest()
        {

        }

        [TestInitialize()]
        public void Initialize()
        {

        }

        [TestCleanup()]
        public void Cleanup()
        {
            sut = null;
        }

        [TestMethod]
        public void PaymentViewModel_WithNegetivePrice_IsNotValid()
        {
            // arrange
            var sut = new PaymentViewModel { Price = -1 };
            var context = new ValidationContext(sut, null, null);
            var results = new List<ValidationResult>();
            TypeDescriptor.AddProviderTransparent(new AssociatedMetadataTypeTypeDescriptionProvider(typeof(PaymentViewModel), typeof(PaymentViewModel)), typeof(PaymentViewModel));

            // action
            var isModelStateValid = Validator.TryValidateObject(sut, context, results, true);

            // Assert here
            Assert.IsFalse(isModelStateValid);
        }

        [TestMethod]
        public void PaymentViewModel_WithEmptyFields_IsNotValid()
        {
            // arrange
            var sut = new PaymentViewModel {  };
            var context = new ValidationContext(sut, null, null);
            var results = new List<ValidationResult>();
            TypeDescriptor.AddProviderTransparent(new AssociatedMetadataTypeTypeDescriptionProvider(typeof(PaymentViewModel), typeof(PaymentViewModel)), typeof(PaymentViewModel));

            // action
            var isModelStateValid = Validator.TryValidateObject(sut, context, results, true);

            // Assert here
            Assert.IsFalse(isModelStateValid);
        }

        [TestMethod]
        public void PaymentViewModel_WithNotEmptyFields_IsValid()
        {
            // arrange
            var sut = new PaymentViewModel
            {
                CreatedDate = DateTime.Now,
                Description = "a",
                Price = 100,
                ProductId = 10,
                ProductTagId = 1,
                Status = Core.Payment.PaymentStatus.Confirmed
            };

            var context = new ValidationContext(sut, null, null);
            var results = new List<ValidationResult>();
            TypeDescriptor.AddProviderTransparent(new AssociatedMetadataTypeTypeDescriptionProvider(typeof(PaymentViewModel), typeof(PaymentViewModel)), typeof(PaymentViewModel));

            // action
            var isModelStateValid = Validator.TryValidateObject(sut, context, results, true);

            // Assert here
            Assert.IsTrue(isModelStateValid);
        }       
    }
}

