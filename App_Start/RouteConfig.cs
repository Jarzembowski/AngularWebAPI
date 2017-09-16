using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace webAPIAngular
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /*
            // Route override to work with Angularjs and HTML5 routing
            routes.MapRoute(
                name: "Application1Override",
                url: "SubscriberForm/subscribers",
                defaults: new { controller = "SubscriberForm", action = "Index" }
            );*/

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


           
        }
    }
}
