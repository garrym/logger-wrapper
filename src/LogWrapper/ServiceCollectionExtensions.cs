using Microsoft.Extensions.DependencyInjection;

namespace LogWrapper
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddLogWrapper(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddSingleton(typeof(ILog<>), typeof(Log<>));
        }
    }
}