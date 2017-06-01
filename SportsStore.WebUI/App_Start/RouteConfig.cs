using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SportsStore.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: null,
                url: "{category}",
                defaults: new {controller = "Products", action = "List", page = 1}
                );

            routes.MapRoute(
                name: null,
                url: "page/{page}",
                defaults: new {controller = "Products", action = "List", category = (string) null}
                );

            routes.MapRoute(
                name: null,
                url: "{category}/page/{page}",
                defaults: new {controller = "Products", action = "List"}
                );

            routes.MapRoute(
                name: null,
                url: "{controller}/{action}/{category}",
                defaults: new {controller = "Products", action = "List", page = 1}
                );

            routes.MapRoute(
                name: null,
                url: "{controller}/{action}/{category}/page/{page}",
                defaults: new {controller = "Products", action = "List"}
                );

            routes.MapRoute(
                name: null,
                url: "{controller}/{action}",
                defaults: new {controller = "Products", action = "List"}
                );

            routes.MapRoute(
                name: "Default",
                url: "",
                defaults: new {controller = "Products", action = "List", category = (string) null, page = 1}
                );
        }
    }
}
