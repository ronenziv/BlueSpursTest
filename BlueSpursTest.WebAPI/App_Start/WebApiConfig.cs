using System.Web.Http;
using WebApiThrottle;

namespace BlueSpursTest.WebAPI
{
    /// <summary>web api congigurations</summary>
    internal static class WebApiConfig
    {
        /// <summary>Registers web api configurations</summary>
        /// <param name="config">The current configuration</param>
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(name: "DefaultApi", routeTemplate: "api/{controller}/{id}", defaults: new { id = RouteParameter.Optional });

            //Apply Throttling Policy on all Controllers - from web.config
            //see more configs here: https://github.com/stefanprodan/WebApiThrottle
            config.MessageHandlers.Add(new ThrottlingHandler(
                policy: ThrottlePolicy.FromStore(new PolicyConfigurationProvider()),
                policyRepository: null,
                repository: new CacheRepository(),
                logger: null
            ));
        }
    }
}
