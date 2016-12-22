using Microsoft.Practices.Unity;
using OnlineShop.API.Models;
using OnlineShop.API.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace OnlineShop.API
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

            RegisterIOC(config);
        }

        private static void RegisterIOC(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<IOrderService, OrderService>(new HierarchicalLifetimeManager());
            container.RegisterType<ShopContext, ShopContext>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);
        }
    }
}
