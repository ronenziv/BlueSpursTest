using System;
using System.Web;
using System.Web.Http;

namespace BlueSpursTest.WebAPI
{
    /// <summary>WebAPI Globals</summary>
    /// <seealso cref="HttpApplication" />
    /// <seealso cref="HttpApplication" />
    public class WebApiApplication : HttpApplication
    {
        /// <summary>Applications start</summary>
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        /// <summary>Strip Server Headers</summary>
        protected void Application_PreSendRequestHeaders()
        {
            //Those headers are not removed when set in config
            Response.Headers.Remove("Server");
            Response.Headers.Remove("X-AspNet-Version");
        }
    }
}
