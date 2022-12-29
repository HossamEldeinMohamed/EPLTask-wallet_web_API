


using BusinessLayer.IService;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITransformationService, TransformationService>();
            services.AddScoped<ILogService, LogService>();
            return services;
        }
    }
}
