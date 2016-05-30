using System.Web.Http;
using PlanDay.Assignment.Core.PaymentRule;
using PlanDay.Assignment.Data.Base;
using PlanDay.Assignment.Service;
using PlanDay.Assignment.Core.ActionExecuter.Factories;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using PlanDay.Assignment.Core.RuleEngine;
using PlanDay.Assignment.Common.Cache;
using PlanDay.Assignment.Common.IO;

namespace PlanDay.Assignment.Web.Helper
{
    //    public class Bootstraper : DefaultControllerFactory
    //    {
    //        static IKernel _kernel = new StandardKernel();

    //        public Bootstraper()
    //        {
    //            InitialDependencyMappings();
    //        }

    //        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
    //        {
    //            return controllerType == null
    //                       ? null
    //                       : (IController)_kernel.Get(controllerType);
    //        }

    //        public static void InitialDependencyMappings()
    //        {
    //            _kernel.Bind<IPaymentRuleHandler>().To<PaymentRuleHandler>();
    //            _kernel.Bind<ICriteriaRuleHandler>().To<CriteriaRuleHandler>();
    //            _kernel.Bind<IUnitOfWork>().To<Data.EFConcrete.TestDataContext>();

    //            _kernel.Bind<IProductTagService>().To<ProductTagService>();
    //            _kernel.Bind<IPaymentRuleService>().To<PaymentRuleService>();
    //        }

    //        public static IProductTagService IProductTagService
    //        {
    //            get
    //            {
    //                return _kernel.Get<IProductTagService>();
    //            }
    //        }

    //        public static IPaymentRuleService IPaymentRuleService
    //        {
    //            get
    //            {
    //                return _kernel.Get<IPaymentRuleService>();
    //            }
    //        }

    //        public static IPaymentRuleHandler IPaymentRuleHandler
    //        {
    //            get
    //            {
    //                return _kernel.Get<IPaymentRuleHandler>();
    //            }
    //        }

    //        public static ICriteriaRuleHandler ICriteriaRuleHandler
    //        {
    //            get
    //            {
    //                return _kernel.Get<ICriteriaRuleHandler>();
    //            }
    //        }
    //    }
    //}

    public class Bootstraper
    {
        public Bootstraper()
        {

        }

        public static void InitialDependencyMappings()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);



            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);

        }

        private static void InitializeContainer(Container container)
        {
            container.Register<IPaymentRuleHandler, PaymentRuleHandler>(Lifestyle.Scoped);
            container.Register<ICriteriaRuleHandler, CriteriaRuleHandler>(Lifestyle.Scoped);

            container.Register<IUnitOfWork, Data.EFConcrete.TestDataContext>(Lifestyle.Scoped);
            container.Register<IProductTagService, ProductTagService>(Lifestyle.Scoped);
            container.Register<IPaymentRuleService, PaymentRuleService>(Lifestyle.Scoped);

            container.Register<ICacheProvider, WebCacheProvider>(Lifestyle.Scoped);
            container.Register<IActionExecuterFactory>(() => new ActionExecuterFactory(container.GetInstance<ICacheProvider>()), (Lifestyle.Scoped));

            // single tone thread safe
            // container.RegisterSingleton<PaymentRuleEngine>(PaymentRuleEngine.Engine);

            container.Register<IPathMapper, MVCPathMapper>(Lifestyle.Scoped);
        }
    }
}