using ApiTestProject.Interfaces;

namespace ApiTestProject.Services
{
    public static class ServiceExtentions
    {
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

    }
}
