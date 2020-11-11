using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs;

namespace WebJobLibrary
{
    public class WebJobHelper
    {
        public static async Task Run(Action<IServiceCollection> configureServices)
        {
            var builder = new HostBuilder();

            builder.ConfigureWebJobs(b =>
            {
                b.AddAzureStorageCoreServices();
                b.AddServiceBus();
            });

            builder.ConfigureLogging((context, b) =>
            {
                b.AddApplicationInsightsWebJobs(options =>
                    {
                        options.InstrumentationKey = "...not needed for error reproduction purposes since the app is not loading...";
                    });
            });
            
            builder.ConfigureServices(services => {
                services.AddSingleton<ITypeLocator, EntryAssemblyTypeLocator>();
                configureServices(services);
            });
            
            var host = builder.Build();
            using (host)
            {
                await host.RunAsync();
            }
        }
    }
}
