using System;
using System.Web.Http;
using Microsoft.Owin.Hosting;
using Owin;

namespace TS.API
{
    public class SampleService
    {
        protected IDisposable WebApplication;

        /// <summary>
        /// Launches the WebApplication using Owin
        /// </summary>
        public void Start()
        {
            WebApplication = WebApp.Start<WebPipeline>("http://localhost:8080");
        }

        /// <summary>
        /// Kills the web application if/when the Topshelf service stops
        /// </summary>
        public void Stop()
        {
            WebApplication.Dispose();
        } 
    }

    public class WebPipeline
    {
        public void Configuration(IAppBuilder application)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            application.UseWebApi(config);
        }
    }
}