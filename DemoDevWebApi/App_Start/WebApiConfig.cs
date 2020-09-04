using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using System.Web.Http.Cors;

namespace DemoDevWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            //Formateo salida en Json
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            //Habilitando Cors
            var urlPermitidas = new EnableCorsAttribute("*"
                                                ,"*","*");
            config.EnableCors(urlPermitidas);

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            //se debe configurar antes de la ruta default
            // nueva route  le ponemso de nombre direcciones
            //cuando se lo llame desde el browser cleinte sera http://localhost:19272/api/midireccion/0919172551001


            config.Routes.MapHttpRoute(
                name: "direcciones",
                routeTemplate: "api/midireccion/{IdCliente}",
                defaults: new { controller = "clientes2", IdCliente = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "cedula",
                routeTemplate: "api/consultacedula/{Cedula}",
                defaults: new { controller = "clientes2", Cedula = RouteParameter.Optional }
            );


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}/{IdCliente}",
                defaults: new { id = RouteParameter.Optional, IdCliente = RouteParameter.Optional }
            );

        }
    }
}
