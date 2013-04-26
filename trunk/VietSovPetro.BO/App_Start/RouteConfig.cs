﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace VietSovPetro.BO
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Localization", // Route name
                "{lang}/{controller}/{action}/{id}", // URL with parameters
                new { controller = "VietSovPetro", action = "Index", id = UrlParameter.Optional }, // Parameter defaults
                new { lang = "[a-z]{2}-[a-z]{2}" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "VietSovPetro", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}