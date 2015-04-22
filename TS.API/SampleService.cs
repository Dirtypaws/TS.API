using System;
using System.Web.Http;
using Hangfire;
using Hangfire.SqlServer;
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
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            app.UseWebApi(config);
            GlobalConfiguration.Configuration.UseSqlServerStorage(
                @"Data Source=(localDb)\ProjectsV12;Integrated Security=True;Pooling=False",
                new SqlServerStorageOptions
                {
                    QueuePollInterval = TimeSpan.FromSeconds(10)
                });

            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
    }
}