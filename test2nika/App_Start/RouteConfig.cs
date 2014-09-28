using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace test2nika
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.EnableFriendlyUrls();

            RouteTable.Routes.MapHttpRoute(
                "DefaultApi",
                "{controller}/{action}",
                new[] { "test2nika.Controllers" });
        }
    }
}
