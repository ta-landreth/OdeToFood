using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace OdeToFood.Web
{
    public class ContainerConfig
    {
        internal static void RegisterContainer(HttpConfiguration httpConfiguration)
        {
            // Autofac specific API for IOC container
            var builder = new ContainerBuilder();
            // Scan through controllers to register them -- tell Autofac what ASSEMBLY has the controllers
            // MvcApplication is the class defined in Global.asax.cs
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            // Use InMemoryRestaurantData whenever app asks for IRestaurantData
            // good to help decouple DI

            //Register WebAPI controllers
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<InMemoryRestaurantData>()
                .As<IRestaurantData>()
                .SingleInstance();  //InstancePerHttpRequest (new instance of InMemory with each HTTP request)
                                    // this is a singleton; will help with our InMemoryRestaurantData to persist changes

            // Create container
            var container = builder.Build();
            // Set the container as the dependency resolver for entire application
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            // WEB API--- 
            // Also need dependency resolver for Web API framework
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}