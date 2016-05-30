using PlanDay.Assignment.Common.Cache;
using PlanDay.Assignment.Common.IO;
using PlanDay.Assignment.Core.ActionExecuter;
using PlanDay.Assignment.Core.Payment;
using PlanDay.Assignment.Core.PaymentRule;
using PlanDay.Assignment.Core.Product;
using PlanDay.Assignment.Core.RuleEngine;
using PlanDay.Assignment.Data.Base;
using PlanDay.Assignment.Service;
using PlanDay.Assignment.Web.Helper;
using PlanDay.Assignment.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVC = System.Web.Mvc;



namespace PlanDay.Assignment.Web.Controllers
{
    public class PaymentController : ApiController
    {
        IProductTagService _ProductTagservice;
        IPaymentRuleService _PaymentRuleService;
        ICacheProvider _CacheProvider;
        IPathMapper _PathMapper;
        PaymentRuleEngine _RuleEngine;

        public PaymentController(IProductTagService productTagservice, IPaymentRuleService paymentRuleService, ICacheProvider cacheProvider, IPathMapper pathMapper)
        {
            _ProductTagservice = productTagservice;
            _PaymentRuleService = paymentRuleService;
            _CacheProvider = cacheProvider;
            _PathMapper = pathMapper;

            // Temp
            LoadTemperoryRuleEngine(cacheProvider);
        }

        [HttpPost]
        public PaymentProcessViewModel Post(PaymentViewModel model)
        {
            // validation
            if (ModelState.IsValid == false)
            {
                throw new HttpRequestException();
            }

            // map the payment
            Payment payment = new Payment
            {
                CreatedDate = model.CreatedDate,
                Id = 1,
                Price = model.Price,
                Product = _ProductTagservice.FindInclude(x => x.Id == model.ProductTagId, x => x.Products).SingleOrDefault().Products.Find(x => x.Id == model.ProductId),
                Status = model.Status
            };

            // process the payment 
            _RuleEngine.ProcessPayment(payment, model.Description);

            // read the log and delete it 
            string content = Logger.ReadLog(_PathMapper);

            return new Models.PaymentProcessViewModel
            {
                Content = content,
                CreatedDate = DateTime.Now
            };
        }

        private void LoadTemperoryRuleEngine(ICacheProvider cacheProvider)
        {
            _RuleEngine = PaymentRuleEngine.Engine(cacheProvider);

            _RuleEngine.Rules.Clear();
            var rules = _PaymentRuleService.GetAllInclude(p => p.Criterias, p => p.Actions);
            if (rules != null)
            {
                foreach (var item in rules)
                {
                    _RuleEngine.Rules.Add(item);
                }
            }
        }
    }
}
