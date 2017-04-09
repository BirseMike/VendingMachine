namespace VendingMachine
{
    using System.Web.Http;
    using DataServices;
    using Helpers;
    using Microsoft.Practices.Unity;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<IProductRepository, ProductRepository>(new ContainerControlledLifetimeManager());
            //container.RegisterType<ICreditCard, ProductRepository>(new PerResolveLifetimeManager());
            container.RegisterType<IMachineCashRepository, MachineCashRepository>(new ContainerControlledLifetimeManager());
            container.RegisterType<ICustomerCashRepository, CustomerCashRepository>(new ContainerControlledLifetimeManager());
            config.DependencyResolver = new UnitResolver(container);

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
