using Microsoft.Practices.Unity;
using ParkAssist.Models;
using System.Web.Http;

namespace ParkAssist
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var container = new UnityContainer();
            container.RegisterType<IOrderService, OrderService>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container); 
        }
    }
}
