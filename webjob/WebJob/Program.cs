using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using WebJobLibrary;

namespace MyWebJob
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await WebJobHelper.Run(services =>
            {
                services.AddScoped<IMyService, MyService>();
                services.AddDbContext<MyDbContext>();
            });
        }
    }
}
