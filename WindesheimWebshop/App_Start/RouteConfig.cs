using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WindesheimWebshop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Product",
                url: "Product/{productId}",
                defaults: new { controller = "Product", action = "Details" }
            );

            routes.MapRoute(
                name: "Categorie",
                url: "Categorie/{categorieId}",
                defaults: new { controller = "Categorie", action = "Details" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "DefaultNoAction",
                url: "{controller}",
                defaults: new { controller = "Home", action = "Index" }
            );
        }
    }
}
