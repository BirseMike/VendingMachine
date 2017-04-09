namespace VendingMachine
{
    using System.Web.Http;
    using DataServices;
    using DataServices.CashRepositories;
    using DataServices.PaymentService;
    using ExternalServices;
    using Helpers;
    using Microsoft.Practices.Unity;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            //These services are "singletons" as they are doubling as datastores
            container.RegisterType<IProductRepository, ProductRepository>(new ContainerControlledLifetimeManager());
            container.RegisterType<IMachineCashRepository, MachineCashRepository>(new ContainerControlledLifetimeManager());
            container.RegisterType<ICustomerCashRepository, CustomerCashRepository>(new ContainerControlledLifetimeManager());

            container.RegisterType<ICreditCardService, CreditCardService>(new PerResolveLifetimeManager());
            container.RegisterType<IPaymentService, PaymentService>(new PerResolveLifetimeManager());
            config.DependencyResolver = new UnitResolver(container);

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "ControllerAndAction",
                routeTemplate: "api/{controller}/{action}"
            );
        }
    }
}
