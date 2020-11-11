using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Text;
using System.Threading.Tasks;

namespace MyWebJob
{
    public class JobFunction
    {
        public JobFunction(IMyService myService)
        {
            MyService = myService;
        }

        public IMyService MyService { get; }

        public async Task GetFooBarAsync([ServiceBusTrigger("test")] Message message, ILogger logger)
        {
            var text = Encoding.UTF8.GetString(message.Body);
            logger.LogInformation("GetFooBarAsync received message {Message}", text);
            await MyService.DoSqlStuff($"message={text}," + DateTime.Now.ToString());
        }
    }
}