using OpenTelemetry;
using OpenTelemetry.Exporter;
using OpenTelemetry.Trace;
using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebApplication2
{
    public class WebApiApplication : HttpApplication
    {
        private IDisposable tracerProvider;

        void Application_Start(object sender, EventArgs e)
        {
            //add APM trace for OpenTelemetry
            var builder = Sdk.CreateTracerProviderBuilder()
                .AddAspNetInstrumentation()
                .AddHttpClientInstrumentation()
                .AddConsoleExporter(options => options.Targets = ConsoleExporterOutputTargets.Debug)
                .AddConsoleExporter(options => options.Targets = ConsoleExporterOutputTargets.Console);

            this.tracerProvider = builder.Build();            

            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}