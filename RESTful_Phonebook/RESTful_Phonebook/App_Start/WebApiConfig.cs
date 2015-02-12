using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace RESTful_Phonebook
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApiRoute",
                routeTemplate: "api/{controller}/{number}",
                defaults: new { number = RouteParameter.Optional }
            );
        }
    }
}
