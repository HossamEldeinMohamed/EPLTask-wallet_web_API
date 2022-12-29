
using Auth.IService;
using Auth.IService.Service;
using DataAccessLayer.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;


namespace Authentication.Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAuthentecationServices(this IServiceCollection services)
        {
            services.AddScoped<IAuth, AuthService>();
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
            }
           ).AddEntityFrameworkStores<ApplicationDbContext>();

            return services;
        }
    }
}
