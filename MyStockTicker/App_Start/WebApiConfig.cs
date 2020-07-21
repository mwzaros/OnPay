using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;

namespace MyStockTicker
{
    public static class WebApiConfig
    {
        public class CustomJSonFormatter : JsonMediaTypeFormatter
        {
            //Custom Formmatter class for text/html header type
            public CustomJSonFormatter()
            {
                this.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));
            }

            //Override the default content header to return json
            public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
            {
                base.SetDefaultContentHeaders(type, headers, mediaType);
                headers.ContentType = new MediaTypeHeaderValue("application/json");
            }
        }
        public static void Register(HttpConfiguration config)
        {

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{ticker}/{days}",
                defaults: new { days = RouteParameter.Optional }
            );

            //Register the custom formatter
            config.Formatters.Add(new CustomJSonFormatter());

        }
    }
}
