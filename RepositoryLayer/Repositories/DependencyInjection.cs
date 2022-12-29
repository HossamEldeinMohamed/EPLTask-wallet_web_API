

using Microsoft.Extensions.DependencyInjection;
using Repositories.Interface;
using RepositoryLayer.Interface;

namespace Repositories.Repositories
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IWallet, WalletRepository>();
            services.AddTransient<ILog, LogRepository>();
            return services;
        }
    }
}
