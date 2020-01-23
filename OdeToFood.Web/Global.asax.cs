using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Http;
using System.Web.Routing;

namespace OdeToFood.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            // WebAPI -- Used when adding a Web API --- must go above RouteConfig
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // WebAPI ---
            // Pass in the configuration for WebAPI framework dependency resolver
            // Reuse register container method, register containers for MVC & Web API
            // Pass in WebAPI ___configuration___ that register container method needs to modify
            ContainerConfig.RegisterContainer(GlobalConfiguration.Configuration);
                    // in the method argument, we specify the HttpConfiguration type
        }
    }
}
