using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LogWrapper
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceCollection = new ServiceCollection()
                .AddTransient<SampleApplication>()
                .AddLogging(config => { config.AddConsole(); })
                .AddLogWrapper(); // Registers the ILog service

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var sampleApplication = serviceProvider.GetService<SampleApplication>();
            sampleApplication.Start();
            
            // Wait for log buffer to flush
            await Task.Delay(2000);
        }
    }
}
