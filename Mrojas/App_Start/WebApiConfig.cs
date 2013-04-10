using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Mrojas
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "GetProfileApi",
                routeTemplate: "api/profile/{token}",
                defaults: new { controller = "Profile", token = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "LogoutApi",
                routeTemplate: "api/logout/{token}",
                defaults: new { controller = "Account", token = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "LoginApi",
                routeTemplate: "api/{action}",
                defaults: new { controller = "Account"}
            );
        }
    }
}
