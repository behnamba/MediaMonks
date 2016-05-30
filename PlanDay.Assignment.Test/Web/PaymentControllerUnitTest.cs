using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PlanDay.Assignment.Common.Cache;
using PlanDay.Assignment.Common.IO;
using PlanDay.Assignment.Core.Product;
using PlanDay.Assignment.Service;
using PlanDay.Assignment.Web.Controllers;
using PlanDay.Assignment.Web.Helper;
using PlanDay.Assignment.Web.Models;
//using PlanDay.Assignment.Web.Controllers;
//using PlanDay.Assignment.Web.Helper;
//using PlanDay.Assignment.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PlanDay.Assignment.Test.Web
{
    [TestClass]
    public class PaymentControllerTest
    {
        public PaymentControllerTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        PaymentController sut;
        Mock<IProductTagService> _ProductTagservice;
        Mock<IPaymentRuleService> _PaymentRuleService;
        Mock<ICacheProvider> _CacheProvider;
        Mock<IPathMapper> _PathMapper;

        [TestInitialize()]
        public void Initialize()
        {
            _CacheProvider = new Mock<ICacheProvider>();
            _ProductTagservice = new Mock<IProductTagService>();
            _PaymentRuleService = new Mock<IPaymentRuleService>();

            // log file arrange 
            _PathMapper = new Mock<IPathMapper>();
            _PathMapper.Setup(p => p.MapPath(It.IsAny<string>())).Returns(Environment.CurrentDirectory);

            // create the file for test purpose
            using (TextWriter txtWriter = new StreamWriter(new FileInfo(string.Format("{0}\\{1}", _PathMapper.Object.MapPath(""), Logger.FileName)).Open(FileMode.OpenOrCreate)))
            {
                txtWriter.Write("");
            }
        }

        [TestCleanup()]
        public void Cleanup()
        {
            Common.IO.FileHelper.Delete(string.Format("{0}\\{1}", _PathMapper.Object.MapPath(""), Logger.FileName));
        }
        
        [TestMethod]
        [ExpectedException(typeof(HttpRequestException))]
        public void Throw_Exception_If_ModelInput_IsNotValid()
        {
            // arrange
            _PaymentRuleService.Setup(p => p.GetAllInclude(null)).Returns(new List<Core.PaymentRule.PaymentRule>());

            sut = new PaymentController(_ProductTagservice.Object, _PaymentRuleService.Object, _CacheProvider.Object, _PathMapper.Object);

            sut.ModelState.AddModelError("test", "test");

            // assert   
            sut.Post(new PaymentViewModel());
        }

        [TestMethod]
        public void Post_NewPaymentRequest_Need_CallFindProductCategoryMethod_OnTime()
        {
            // arrange
            ProductTag pTag = new ProductTag()
            {
                Id = 1,
                Name = "test",
                Products = new List<Product> { new Product { Id = 1, ProductTag = new List<ProductTag> { new ProductTag { Id = 1, Name = "test" } }, Price = 100, Title = "test" } }
            };

            _ProductTagservice.Setup(p => p.FindInclude(It.IsAny<Expression<Func<ProductTag, bool>>>(), It.IsAny<Expression<Func<ProductTag, object>>>()))
                .Returns(new List<Core.Product.ProductTag> { pTag }).Verifiable();

            _PaymentRuleService.Setup(p => p.GetAllInclude(null)).Returns(new List<Core.PaymentRule.PaymentRule>());

            sut = new PaymentController(_ProductTagservice.Object, _PaymentRuleService.Object, _CacheProvider.Object, _PathMapper.Object);

            // action   
            sut.Post(new PaymentViewModel
            {
                CreatedDate = DateTime.Now,
                Description = "a",
                Price = 100,
                ProductId = 1,
                ProductTagId = 1,
                Status = Core.Payment.PaymentStatus.Confirmed
            });


            // assert 
            _ProductTagservice.Verify(mock => mock.FindInclude(It.IsAny<Expression<Func<ProductTag, bool>>>(), It.IsAny<Expression<Func<ProductTag, object>>>()), Times.Once());
        }

        [TestMethod]
        public void Post_NewPaymentRequest_WithValidInput_Will_Return_NotNull_OutPut()
        {
            // arrange
            ProductTag pTag = new ProductTag()
            {
                Id = 1,
                Name = "test",
                Products = new List<Product> { new Product { Id = 1, ProductTag = new List<ProductTag> { new ProductTag { Id = 1, Name = "test" } }, Price = 100, Title = "test" } }
            };

            _ProductTagservice.Setup(p => p.FindInclude(It.IsAny<Expression<Func<ProductTag, bool>>>(), It.IsAny<Expression<Func<ProductTag, object>>>()))
                .Returns(new List<Core.Product.ProductTag> { pTag });

            _PaymentRuleService.Setup(p => p.GetAllInclude(null)).Returns(new List<Core.PaymentRule.PaymentRule>());

            sut = new PaymentController(_ProductTagservice.Object, _PaymentRuleService.Object, _CacheProvider.Object, _PathMapper.Object);

            // action   
            var actual = sut.Post(new PaymentViewModel
            {
                CreatedDate = DateTime.Now,
                Description = "a",
                Price = 100,
                ProductId = 1,
                ProductTagId = 1,
                Status = Core.Payment.PaymentStatus.Confirmed
            });


            // assert 
            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.Content);
            Assert.IsNotNull(actual.CreatedDate);
        }
    }
}